using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;
using ivrdating.Log;
using System.Web.Http.Controllers;
using System.Diagnostics;
using System.Net.Http;
using ivrdating.Logic.Helpers;
using System.Net;
using System.Reflection;
using System.Web.Http.ModelBinding;
using ivrdating.Domain.VM;
using System.IO;

namespace ivrdating.Web.Filter
{
    public class LogActionFilter : ActionFilterAttribute
    {

        LogRequestResponse _logRequestResponse;
        public LogActionFilter()
        {
            _logRequestResponse = new LogRequestResponse();
        }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            bool postValidationDoneDontCheckForAccAndArea = false;

            string jsonResp = "";


            string rawRequest = string.Empty;
            var request = HttpContext.Current.Request;
            string[] dateField = null;
            bool isDateValide = true;
            if (request.HttpMethod == "POST")
            {
                var inputStream = request.InputStream;
                inputStream.Position = 0;
                using (var reader = new StreamReader(inputStream))
                {
                    string headers = request.Headers.ToString();
                    string body = reader.ReadToEnd();
                    rawRequest = body;

                    foreach (string str in rawRequest.Split(new char[] { ',' }))
                    {
                        if (str.Contains("PlanExpiresOn") || str.Contains("RegisteredDate") || str.Contains("Old_Expiry") || str.Contains("New_Expiry") || str.Contains("LastTimeStamp"))
                        {

                            dateField = str.Split(new char[] { ':' });
                            if (dateField == null || dateField.Length < 2 || dateField[1].Split(new char[] { '-' }).Length < 3)
                            {
                                isDateValide = false;
                                jsonResp = "Invalid " + dateField[0] + " it should be YYYY-MM-DD format";

                                break;
                            }
                        }
                    }
                }
            }
            else if (request.HttpMethod == "GET")
            {
                rawRequest = request.QueryString.ToString();

                foreach (string str in rawRequest.Split(new char[] { '&' }))
                {
                    if (str.Contains("PlanExpiresOn") || str.Contains("RegisteredDate") || str.Contains("Old_Expiry") || str.Contains("New_Expiry") || str.Contains("LastTimeStamp"))
                    {

                        dateField = str.Split(new char[] { '=' });
                        if (dateField == null || dateField.Length < 2 || dateField[1].Split(new char[] { '-' }).Length < 3)
                        {
                            isDateValide = false;
                            jsonResp = "Invalid " + dateField[0] + " it should be YYYY-MM-DD format";

                            break;
                        }
                    }
                }
            }



            InvalidDataAttemp invalid = new InvalidDataAttemp();
            PropertyInfo[] pf = invalid.GetType().GetProperties();
            if (!actionContext.ModelState.IsValid || !isDateValide)
            {
                if (actionContext.Request.Method.Method == "POST")
                {
                    // jsonResp = ExtensionMethods.SerializeToPlainText(actionContext.ModelState.Values.GetType().GetProperties(), actionContext.ModelState.Values);

                    foreach (ModelState ms in actionContext.ModelState.Values)
                    {
                        if (ms.Errors.Count > 0)
                        {
                            jsonResp = ExtensionMethods.SerializeToJson(ms.Errors);
                            foreach (PropertyInfo p in pf)
                            {
                                if (jsonResp.Contains(p.Name))
                                {
                                    jsonResp = invalid.GetType().GetProperty(p.Name).GetValue(invalid, null).ToString();
                                    postValidationDoneDontCheckForAccAndArea = true;
                                    break;
                                }
                            }
                            break;
                        }
                    }
                    try
                    {
                        if (!string.IsNullOrEmpty(jsonResp) && !postValidationDoneDontCheckForAccAndArea)
                        {
                            if (jsonResp.Contains("PlanExpiresOn"))
                            {
                                jsonResp = "Invalid PlanExpiresOn it should be YYYY-MM-DD format";
                                postValidationDoneDontCheckForAccAndArea = true;
                            }
                            else if (jsonResp.Contains("RegisteredDate"))
                            {
                                jsonResp = "Invalid RegisteredDate it should be YYYY-MM-DD format";
                                postValidationDoneDontCheckForAccAndArea = true;
                            }
                            else if (jsonResp.Contains("Old_Expiry"))
                            {
                                jsonResp = "Invalid Old_Expiry it should be YYYY-MM-DD format";
                                postValidationDoneDontCheckForAccAndArea = true;
                            }
                            else if (jsonResp.Contains("New_Expiry"))
                            {
                                jsonResp = "Invalid New_Expiry it should be YYYY-MM-DD format";
                                postValidationDoneDontCheckForAccAndArea = true;
                            }

                            else if (jsonResp.Contains("LastTimeStamp"))
                            {
                                jsonResp = "Invalid LastTimeStamp it should be YYYY-MM-DD HH:MM:SS format";
                                postValidationDoneDontCheckForAccAndArea = true;
                            }
                        }
                        //actionContext.ActionArguments["_request"] = new  { AuthKey = "Model Validation faild " + jsonResp };
                        Type[] types = Assembly.Load(new AssemblyName("ivrdating.Domain")).GetTypes();
                        foreach (Type t in types)
                        {
                            string nm = t.Name;
                            nm = nm.Replace("Request", "").Replace("_", "").ToUpper();
                            if (nm == actionContext.ActionDescriptor.ActionName.Replace("_", "").ToUpper())
                            {
                                dynamic dobj = t.GetConstructor(Type.EmptyTypes).Invoke(new object[0]);
                                dobj.AuthKey = "Model Validation failed" + jsonResp.Replace("[", "").Replace("{", "").Replace("{", "\"").Replace("]", "").Replace("}", "").Replace("\"", ""); ;
                                actionContext.ActionArguments["_Request"] = dobj;
                                break;
                            }
                        }

                    }
                    catch
                    {
                    }

                }
                else
                {
                    int cnt = -1;
                    foreach (ModelState ms in actionContext.ModelState.Values)
                    {
                        if (!isDateValide)
                        {
                            actionContext.ActionArguments["AuthKey"] = "Model Validation failed " + jsonResp;
                            break;
                        }
                        cnt++;
                        if (ms.Errors.Count > 0)
                        {
                            jsonResp = ExtensionMethods.SerializeToJson(ms.Errors);

                            //object newval = 0;
                            string key = actionContext.ModelState.Keys.ElementAt(cnt);

                            KeyValuePair<string, object> o = new KeyValuePair<string, object>();
                            foreach (KeyValuePair<string, object> k in actionContext.ActionArguments)
                            {
                                if (k.Key == key)
                                {
                                    o = k;
                                    break;
                                }
                            }
                            string dateValidationFialed = string.Empty;
                            if (o.Key != null)
                            {
                                if ("PlanExpiresOn RegisteredDate Old_Expiry New_Expiry LastTimeStamp".Contains(o.Key.ToString()))
                                {
                                    dateValidationFialed = "Model Validation failedInvalid " + o.Key.ToString() + " it should be YYYY-MM-DD format";
                                    if (o.Key.ToString() == "LastTimeStamp")
                                    {
                                        dateValidationFialed = "Model Validation failedInvalid " + o.Key.ToString() + " it should be YYYY-MM-DD HH:MM:SS format";
                                    }
                                    actionContext.ActionArguments[o.Key] = DateTime.Now;
                                }
                                else
                                {
                                    if (!o.Key.Contains("Amount"))
                                    {
                                        actionContext.ActionArguments[o.Key] = 0;
                                    }
                                }
                            }
                            foreach (KeyValuePair<string, object> args in actionContext.ActionArguments.ToList())
                            {
                                if (args.Key.Contains("AuthKey"))
                                {
                                    //object objectT = actionContext.ActionArguments["_request"];
                                    if (!string.IsNullOrEmpty(dateValidationFialed))
                                    {
                                        actionContext.ActionArguments["AuthKey"] = dateValidationFialed;
                                        break;
                                    }
                                    try
                                    {
                                        foreach (PropertyInfo p in pf)
                                        {
                                            if (p.Name == o.Key)
                                            {
                                                if (o.Key.Contains("Amount"))
                                                {
                                                    decimal d = 0.0M;
                                                    actionContext.ActionArguments[o.Key] = d;
                                                }
                                                jsonResp = invalid.GetType().GetProperty(p.Name).GetValue(invalid, null).ToString();
                                                postValidationDoneDontCheckForAccAndArea = true;
                                                actionContext.ActionArguments["AuthKey"] = "Model Validation failed " + jsonResp.Replace("[", "").Replace("{", "").Replace("{", "\"").Replace("]", "").Replace("}", "").Replace("\"", "");
                                                break;

                                            }
                                        }
                                    }
                                    catch { }
                                    break;
                                }
                            }
                        }
                    }

                }
            }

            if (!postValidationDoneDontCheckForAccAndArea)
            {
                //Area code and Acc_Number validation
                int rs = 0;
                foreach (KeyValuePair<string, object> args in actionContext.ActionArguments.ToList())
                {
                    if (args.Key.Contains("Request"))
                    {
                        object objectT = actionContext.ActionArguments["_Request"];
                        object vall;
                        try
                        {
                            vall = args.Value.GetType().GetProperty("Acc_Number").GetValue(objectT);

                            if (vall == null || !int.TryParse(vall.ToString(), out rs))
                            {
                                rs = -1;
                            }
                            if ((rs < 99999 || rs > 999999))
                            {
                                args.Value.GetType().GetProperty("Acc_Number").SetValue(objectT, -1, null);
                                if (actionContext.ActionDescriptor.ActionName == "get_member_details" || actionContext.ActionDescriptor.ActionName == "member_forgot_passcode")
                                {
                                    if (vall.ToString() == "0")
                                    {
                                        args.Value.GetType().GetProperty("Acc_Number").SetValue(objectT, 0, null);
                                    }
                                    else
                                    {
                                        args.Value.GetType().GetProperty("Acc_Number").SetValue(objectT, -2, null);
                                    }
                                }
                            }
                        }
                        catch { }

                        try
                        {
                            vall = args.Value.GetType().GetProperty("Area_Code").GetValue(objectT);
                            if (vall == null || !int.TryParse(vall.ToString(), out rs))
                            {
                                rs = -1;
                            }
                            if (rs <= 0)
                            {
                                args.Value.GetType().GetProperty("Area_Code").SetValue(objectT, "-1", null);
                            }
                        }
                        catch { }
                    }
                    if (args.Key == "Acc_Number" && (args.Value == null || !int.TryParse(args.Value.ToString(), out rs)))
                    {
                        actionContext.ActionArguments["Acc_Number"] = -1;
                    }
                    else if ((rs < 99999 || rs > 999999) && args.Key == "Acc_Number")
                    {

                        actionContext.ActionArguments["Acc_Number"] = -1;
                        if (actionContext.ActionDescriptor.ActionName == "get_member_details" || actionContext.ActionDescriptor.ActionName == "member_forgot_passcode")
                        {
                            if (args.Value.ToString() == "0")
                            {
                                actionContext.ActionArguments["Acc_Number"] = 0;
                            }
                            else
                            {
                                actionContext.ActionArguments["Acc_Number"] = -2;
                            }
                        }
                    }

                    if (args.Key == "Area_Code" && (args.Value == null || !int.TryParse(args.Value.ToString(), out rs)))
                    {
                        actionContext.ActionArguments["Area_Code"] = "-1";
                    }
                }


            }
            _logRequestResponse.LogData(string.Format("\r\n Executing controller {0}, action {1}\r\n{2}\r\n",
                    actionContext.ActionDescriptor.ControllerDescriptor.ControllerName,
                    actionContext.ActionDescriptor.ActionName, ExtensionMethods.SerializeToJson(actionContext.ActionArguments)), "Info");

        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Response != null)
            {
                var objectContent = actionExecutedContext.Response.Content as ObjectContent;
                if (objectContent != null)
                {
                    try
                    {
                        System.Web.Http.HttpError err = (((System.Web.Http.HttpError)(objectContent.Value)));

                        System.Collections.Generic.KeyValuePair<string, object> data = err.LastOrDefault();
                        if (err["MessageDetail"].ToString().Contains("Acc_Number' of non-nullable type 'System.Int32"))
                        {
                            err["MessageDetail"] = "Invalid Acc_Number";
                        }
                    }
                    catch { }

                    _logRequestResponse.LogData(string.Format("\r\n Executed controller {0}, action {1}\r\n{2}\r\n",
                       actionExecutedContext.ActionContext.ControllerContext.ControllerDescriptor.ControllerName,
                       actionExecutedContext.ActionContext.ActionDescriptor.ActionName,
                       ExtensionMethods.SerializeToJson(objectContent.Value)), "Info");
                    //var type = objectContent.ObjectType; //type of the returned object
                    //var value = objectContent.Value; //holding the returned value
                }
                //((System.Net.Http.ObjectContent)actionExecutedContext.ActionContext.Response.Content).Value
            }
            else if (actionExecutedContext.Exception != null)
            {
                _logRequestResponse.LogData(string.Format("\r\n Executed controller {0}, action {1}\r\n{2}\r\n",
                       actionExecutedContext.ActionContext.ControllerContext.ControllerDescriptor.ControllerName,
                       actionExecutedContext.ActionContext.ActionDescriptor.ActionName,
                       ExtensionMethods.SerializeToJson(actionExecutedContext.Exception)), "Info");
            }


        }
    }

    public class InvalidDataAttemp
    {
        public string Acc_Number { get { return "Invalid Acc_Number it can 6 digit numeric only"; } }
        public string CallerId { get { return "Invalid CallerId it has 10 digit numeric only"; } }
        public string Plan_Id { get { return "Invalid Plan_Id, it can be numeric only"; } }
        public string Plan_Validity { get { return "Invalid Payment Plan_Validity"; } }
        public string Minutes_In_Package { get { return "Invalid Payment Minutes_In_Package"; } }
        public string PassCode { get { return "Invalid PassCode it has 4 digit numeric only"; } }
        public string Service_Source { get { return "Invalid Service_Source"; } }
        public string Plan_Amount { get { return "Invalid Plan_Amount"; } }
        public string SMS_Id { get { return "Invalid SMS_Id"; } }
        public string App1Del2 { get { return "Invalid App1Del2 it can be 1 OR 2 only"; } }
        public string Charged_Amount { get { return "Invalid Charged_Amount"; } }
        public string Response_Code { get { return "Invalid Response_Code"; } }
        public string CarrierId { get { return "Invalid CarrierId, it can be numeric only"; } }
    }
}
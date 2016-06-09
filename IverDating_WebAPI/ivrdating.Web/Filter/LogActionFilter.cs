﻿using System;
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

            InvalidDataAttemp invalid = new InvalidDataAttemp();
            PropertyInfo[] pf = invalid.GetType().GetProperties();
            if (!actionContext.ModelState.IsValid)
            {
                string jsonResp = "";
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

                        //actionContext.ActionArguments["_request"] = new  { AuthKey = "Model Validation faild " + jsonResp };
                        Type[] types = Assembly.Load(new AssemblyName("ivrdating.Domain")).GetTypes();
                        foreach (Type t in types)
                        {
                            string nm = t.Name;
                            nm = nm.Replace("Request", "").Replace("_", "").ToUpper();
                            if (nm == actionContext.ActionDescriptor.ActionName.Replace("_", "").ToUpper())
                            {
                                dynamic dobj = t.GetConstructor(Type.EmptyTypes).Invoke(new object[0]);
                                dobj.AuthKey = "Model Validation faild" + jsonResp.Replace("[", "").Replace("{", "").Replace("{", "\"").Replace("]", "").Replace("}", "").Replace("\"", ""); ;
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
                        cnt++;
                        if (ms.Errors.Count > 0)
                        {
                            jsonResp = ExtensionMethods.SerializeToJson(ms.Errors);

                            //object newval = 0;
                            KeyValuePair<string, object> o = actionContext.ActionArguments.ElementAt(cnt);
                           
                            actionContext.ActionArguments[o.Key] = 0;
                            foreach (KeyValuePair<string, object> args in actionContext.ActionArguments.ToList())
                            {
                                if (args.Key.Contains("AuthKey"))
                                {
                                    //object objectT = actionContext.ActionArguments["_request"];

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
                                                actionContext.ActionArguments["AuthKey"] = "Model Validation faild " + jsonResp.Replace("[", "").Replace("{", "").Replace("{", "\"").Replace("]", "").Replace("}", "").Replace("\"", "");
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
        public string Plan_Id { get { return "Invalid Payment Plan_Id"; } }
        public string Plan_Validity { get { return "Invalid Payment Plan_Validity"; } }
        public string Minutes_In_Package { get { return "Invalid Payment Minutes_In_Package"; } }
        public string PassCode { get { return "Invalid PassCode it has 4 digit numeric only"; } }
        public string Service_Source { get { return "Invalid Service_Source"; } }
        public string Plan_Amount { get { return "Invalid Plan_Amount"; } }
        public string SMS_Id { get { return "Invalid SMS_Id"; } }
        public string App1Del2 { get { return "Invalid App1Del2"; } }
        public string Charged_Amount { get { return "Inavlid Charged_Amount"; } }
        public string Response_Code { get { return "Inavlid Response_Code"; } }
    }
}
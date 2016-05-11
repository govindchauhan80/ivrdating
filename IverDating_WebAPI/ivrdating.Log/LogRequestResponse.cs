using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Config;
using System.IO;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace ivrdating.Log
{
    public class LogRequestResponse
    {
        // private static readonly ILog logger =  LogManager.GetLogger(typeof(LogRequestResponse));
        public LogRequestResponse()
        {
            log4net.GlobalContext.Properties["LogName"] = String.Format("{0:MMM-yyyy}.text", DateTime.UtcNow);
        }

        public void LogData(string data, string logType)
        {
            ILog logger = LogManager.GetLogger(typeof(LogRequestResponse));
            BasicConfigurator.Configure();
            switch (logType)
            {
                case "Info":
                    logger.Info(data);
                    break;
                case "Warn":
                    logger.Warn(data);
                    break;
                case "Error":
                    logger.Error(data);
                    break;
                case "Debug":
                    logger.Debug(data);
                    break;
                default:
                    logger.Info(data);
                    break;
            }
        }
    }
}

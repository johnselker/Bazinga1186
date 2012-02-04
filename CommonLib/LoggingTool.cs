/// LoggingTool.cs
/// Jeremy Nelson
/// Bazinga! Industries

using System;
using System.IO;
using System.Reflection;
using log4net;
using log4net.Repository.Hierarchy;

namespace CommonLib
{
    public class LoggingTool
    {
        private ILog m_log;

        // METHOD: LoggingTool()
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Class constructor. Initialize Log4net library and Log object.
        /// </summary>
        /// 
        /// <param name="callingMethod">Calling method creating the logging tool object</param>
        //--------------------------------------------------------------------------------------  
        public LoggingTool(MethodBase callingMethod)
        {
            if (callingMethod == null)
                return;
            
            try
            {
                if (!LogManager.GetRepository().Configured)
                {
                    //Set the working directory in case it's a windows service trying to run out of system32
                    Environment.CurrentDirectory = System.AppDomain.CurrentDomain.BaseDirectory;

                    //Now configure log4net from the app.config file (as renamed by compiler)...
                    string configName = AppDomain.CurrentDomain.FriendlyName + ".config";
                    FileInfo fi = new FileInfo(configName);

                    //AndWatch allows any edits to the .config file made while running to be automatically loaded 
                    //without having to restart the application... very nice.
                    log4net.Config.XmlConfigurator.ConfigureAndWatch(fi);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error creating Log4net repository" + e.Message);
            }    

            m_log = LogManager.GetLogger(callingMethod.DeclaringType);
        }

        // METHOD: LogDebug()
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Logs the specified message if debug build
        /// </summary>
        /// 
        /// <param name="message">Log message</param>
        //--------------------------------------------------------------------------------------  
        public void LogDebug(object message)
        {
#if DEBUG
            m_log.Info(message);
#endif
        }

        // METHOD: LogDebugFormat()
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Logs the specified message with formatting if debug build
        /// </summary>
        /// 
        /// <param name="format">Log format</param>
        /// <param name="args">Message formatting arguments</param>
        //--------------------------------------------------------------------------------------  
        public void LogDebugFormat(string format, params object[] args)
        {
#if DEBUG
            m_log.InfoFormat(format, args);
#endif
        }

        // METHOD: LogInfo()
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Logs info message
        /// </summary>
        /// 
        /// <param name="message">Log message</param>
        //--------------------------------------------------------------------------------------  
        public void LogInfo(object message)
        {
            m_log.Info(message);
        }

        // METHOD: LogInfoFormat
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Logs formatted info message 
        /// </summary>
        /// 
        /// <param name="format">Log format</param>
        /// <param name="args">Message formatting arguments</param>
        //--------------------------------------------------------------------------------------  
        public void LogInfoFormat(string format, params object[] args)
        {
            m_log.InfoFormat(format, args);
        }

        // METHOD: LogError
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Logs error message
        /// </summary>
        /// 
        ///<param name="message">Error message</param>
        //--------------------------------------------------------------------------------------  
        public void LogError(object message)
        {
            m_log.Error(message);
        }

        // METHOD: LogError
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Logs error message with an exception
        /// </summary>
        /// 
        /// <param name="message">Error message</param>
        /// <param name="exception">Exception</param>
        //--------------------------------------------------------------------------------------  
        public void LogError(object message, Exception exception)
        {
            m_log.Error(message, exception);
        }

        // METHOD: LogErrorFormat
        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Logs formatted error message 
        /// </summary>
        /// 
        /// <param name="format">Log format</param>
        /// <param name="args">Message formatting arguments</param>
        //--------------------------------------------------------------------------------------  
        public void LogErrorFormat(string format, params object[] args)
        {
            m_log.ErrorFormat( format, args );
        }
    }
}

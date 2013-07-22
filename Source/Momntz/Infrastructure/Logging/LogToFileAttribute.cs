using System;
using Momntz.Infrastructure.Configuration;
using Newtonsoft.Json;
using PostSharp.Aspects;

namespace Momntz.Infrastructure.Logging
{
    [Serializable]
    public class LogToFileAttribute : OnMethodBoundaryAspect
    {
        private static ILog _log;
        private static readonly object _lock = new object();

        /// <summary>
        /// Logs this instance.
        /// </summary>
        /// <returns>ILog.</returns>
        private static ILog Log()
        {
            var settings = MomntzConfiguration.GetSettings();
            return new LogToFile(settings.LogToFile);
        }

        /// <summary>
        /// Gets the log.
        /// </summary>
        /// <returns>ILog.</returns>
        private ILog GetLog()
        {
            if (_log == null)
            {
                lock (_lock)
                {
                    if (_log == null)
                    {
                        _log = Log();
                    }
                }
            }

            return _log;
        }

        /// <summary>
        /// Writes the specified log.
        /// </summary>
        /// <param name="log">The log.</param>
        public void Write(string log)
        {
            _log = GetLog();
            _log.Debug(log);
        }

        public string Message { get; set; }

        /// <summary>
        /// Method executed <b>before</b> the body of methods to which this aspect is applied.
        /// </summary>
        /// <param name="args">Event arguments specifying which method
        /// is being executed, which are its arguments, and how should the execution continue
        /// after the execution of <see cref="M:PostSharp.Aspects.IOnMethodBoundaryAspect.OnEntry(PostSharp.Aspects.MethodExecutionArgs)" />.</param>
        public override void OnEntry(MethodExecutionArgs args)
        {
            string log = string.Empty;

            if (!string.IsNullOrEmpty(Message))
            {
                log += Message + Environment.NewLine;
            }

            log += string.Format("Entering method {0}.{1}", args.Method.DeclaringType, args.Method.Name);

            if (args.Arguments != null && args.Arguments.Count > 0)
            {
                log += string.Format(" with parameters: {0}", Environment.NewLine);

                foreach (var parameter in args.Arguments)
                {
                    bool isParameterNull = parameter == null;
                    string typeName = (!isParameterNull ? parameter.GetType().Name : "null");

                    if (!isParameterNull && parameter.GetType() != typeof(byte[]))
                    {
                        log += "parameter type: " + typeName + ", value:" + JsonConvert.SerializeObject(parameter) + Environment.NewLine;
                    }
                    else if (!isParameterNull)
                    {
                        log += "parameter type: " + typeName + ", size:" + ((byte[])parameter).Length + Environment.NewLine;
                    }
                    else
                    {
                        log += "parameter type: " + typeName + Environment.NewLine;
                    }
                }
            }
            else
            {
                log += Environment.NewLine;
            }

            Write(log + Environment.NewLine);
            base.OnEntry(args);
        }
    }
}

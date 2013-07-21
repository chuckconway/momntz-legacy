using System;
using Newtonsoft.Json;
using PostSharp.Aspects;

namespace Momntz.Infrastructure.Logging
{
    [Serializable]
    public class LogAspectAttribute : OnMethodBoundaryAspect 
    {
        /// <summary>
        /// Method executed <b>before</b> the body of methods to which this aspect is applied.
        /// </summary>
        /// <param name="args">Event arguments specifying which method
        /// is being executed, which are its arguments, and how should the execution continue
        /// after the execution of <see cref="M:PostSharp.Aspects.IOnMethodBoundaryAspect.OnEntry(PostSharp.Aspects.MethodExecutionArgs)" />.</param>
        public override void OnEntry(MethodExecutionArgs args)
        {
            string log = string.Format("Entering method {0}.{1}", args.Method.DeclaringType, args.Method.Name);

            if (args.Arguments != null && args.Arguments.Count > 0)
            {
                log += string.Format(" with parameters: {0}", Environment.NewLine);

                foreach (var parameter in args.Arguments)
                {
                    bool isParameterNull = parameter == null;
                    string typeName = (!isParameterNull ? parameter.GetType().Name : "null");

                    if (!isParameterNull && parameter.GetType() != typeof (byte[]))
                    {
                        log += "parameter type: " + typeName + ", value:" + JsonConvert.SerializeObject(parameter) +
                               Environment.NewLine;
                    }
                    else if (!isParameterNull)
                    {
                        log += "parameter type: " + typeName + ", size:" + ((byte[]) parameter).Length +
                               Environment.NewLine;
                    }
                    else
                    {
                        log += "parameter type: " + typeName + Environment.NewLine;
                    }
                }
            }

            Console.WriteLine(log);
            base.OnEntry(args);
        }
    }
}

using System;
using System.Web.Mvc;

namespace Momntz.UI.Core.ActionResults
{
    public class QueryResult<TArgs, TReturn> : ActionResult
    {
        /// <summary> Gets or sets the success. </summary>
        /// <value> The success. </value>
        public ActionResult Success { get; set; }

        /// <summary> Gets or sets the error. </summary>
        /// <value> The error. </value>
        public ActionResult Error { get; set; }
        
        private readonly TArgs _args;

        /// <summary> Constructor. </summary>
        /// <param name="args">    The arguments. </param>
        /// <param name="success"> The success. </param>
        /// <param name="error">   The error. </param>
        public QueryResult(TArgs args, ActionResult success, ActionResult error)
        {
            Success = success;
            Error = error;
            _args = args;
        }

        /// <summary> Executes the result operation. </summary>
        /// <param name="context"> The context. </param>
        public override void ExecuteResult(ControllerContext context)
        {
            if (!context.Controller.ViewData.ModelState.IsValid)
            {
                Error.ExecuteResult(context);
            }
            else
            {
                var handler = DependencyResolver.Current.GetService<IQueryHandler<TArgs, TReturn>>();
                handler.Controller = context.Controller;

                TryHandler(_args, handler, context);
            }
        }

        /// <summary> Handler, called when the try. </summary>
        /// <param name="args">    The arguments. </param>
        /// <param name="handler"> The handler. </param>
        /// <param name="context"> The context. </param>
        private void TryHandler(TArgs args, IQueryHandler<TArgs, TReturn> handler, ControllerContext context)
        {
            try
            {
                handler.Handle(args);
                Success.ExecuteResult(context);
            }
            catch (Exception)
            {
                Error.ExecuteResult(context);
            }
        }
    }
}
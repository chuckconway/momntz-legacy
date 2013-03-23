using System;
using System.Web.Mvc;

namespace Momntz.UI.Core.ActionResults
{
    public class FormResult<T> : ActionResult
    {
        private readonly T _args;

        /// <summary> Constructor. </summary>
        /// <param name="args">    The arguments. </param>
        /// <param name="success"> The success. </param>
        /// <param name="error">   The error. </param>
        public FormResult(T args, ActionResult success, ActionResult error)
        {
            _args = args;
            Success = success;
            Error = error;
        }

        /// <summary> Gets or sets the success handler. </summary>
        /// <value> The success handler. </value>
        public ActionResult Success { get; set; }

        /// <summary> Gets or sets the error handler. </summary>
        /// <value> The error handler. </value>
        public ActionResult Error { get; set; }

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
                var handler = DependencyResolver.Current.GetService<IFormHandler<T>>();
                handler.Controller = context.Controller;

                TryHandler(_args, handler, context);
            }
        }

        /// <summary> Handler, called when the try. </summary>
        /// <param name="args">    The arguments. </param>
        /// <param name="handler"> The handler. </param>
        /// <param name="context"> The context. </param>
        private void TryHandler(T args, IFormHandler<T> handler, ControllerContext context)
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
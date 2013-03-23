using System.Web.Mvc;

namespace Momntz.UI.Core
{
    public interface IQueryHandler<in TArgs, out TReturn>
    {
        /// <summary> Gets or sets the controller. </summary>
        /// <value> The controller. </value>
        ControllerBase Controller { get; set; }

        /// <summary> Handles. </summary>
        /// <param name="args"> The arguments. </param>
        /// <returns> . </returns>
        TReturn Handle(TArgs args);
    }
}
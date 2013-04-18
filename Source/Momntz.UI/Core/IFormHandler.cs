using System.Web.Mvc;

namespace Momntz.UI.Core
{
    public interface IFormHandler<in T> 
    {
        /// <summary> Gets or sets the controller. </summary>
        /// <value> The controller. </value>
        ControllerBase Controller { get; set; }

        /// <summary> Handles. </summary>
        /// <param name="args"> The arguments. </param>
        void Handle(T args);
    }
}
using System;
using System.Web.Mvc;
using Momntz.UI.Areas.Api.Models;

namespace Momntz.UI.Core.Binders
{
    public class NewTagModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            NewTag tag = new NewTag();
            tag.Left = Convert.ToDecimal(controllerContext.HttpContext.Request["left"]);
            tag.Top = Convert.ToDecimal(controllerContext.HttpContext.Request["top"]);
            tag.Height = Convert.ToDecimal(controllerContext.HttpContext.Request["height"]);
            tag.Width = Convert.ToDecimal(controllerContext.HttpContext.Request["width"]);
            tag.MomentoId = Convert.ToInt32(controllerContext.HttpContext.Request.QueryString["image_id"]);
            tag.Name = controllerContext.HttpContext.Request["name"];

            return tag;
        }
    }
}
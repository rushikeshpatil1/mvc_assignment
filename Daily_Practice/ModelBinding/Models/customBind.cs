using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ModelBinding.Models
{
    public class customBind : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            int cid = Convert.ToInt32(controllerContext.HttpContext.Request.Form["id"]);
            string firstname = controllerContext.HttpContext.Request.Form["firstname"];
            string lastname = controllerContext.HttpContext.Request.Form["lastname"];

            return new Class1() { id = cid, name = firstname + " " + lastname };
        }
    }
    
    
}
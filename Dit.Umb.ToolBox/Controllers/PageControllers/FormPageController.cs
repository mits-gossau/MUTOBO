using Dit.Umb.ToolBox.Models.PageModels;
using Dit.Umb.ToolBox.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Models;

namespace Dit.Umb.ToolBox.Controllers.PageControllers
{
    public class FormPageController : BasePageController
    {
        private readonly IFormPageService _formPageService;

        public FormPageController(IFormPageService formPageService)
        {
            _formPageService = formPageService;
        }


        // GET: FormPage
        public override ActionResult Index(ContentModel model)
        {            
            return base.Index<FormPage>(new FormPage(model.Content));
        }
    }
}




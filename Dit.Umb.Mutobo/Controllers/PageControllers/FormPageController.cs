using System.Web.Mvc;
using Dit.Umb.Mutobo.Interfaces;
using Dit.Umb.Mutobo.PageModels;
using Umbraco.Web.Models;

namespace Dit.Umb.Mutobo.Controllers.PageControllers
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




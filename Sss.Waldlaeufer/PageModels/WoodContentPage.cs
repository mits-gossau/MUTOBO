using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Dit.Umb.Mutobo.Controllers.PageControllers;
using Dit.Umb.Mutobo.Interfaces;
using Dit.Umb.Mutobo.PageModels;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web.Models;

namespace Sss.Waldlaeufer.PageModels
{
    public class WoodContentPage : ContentPage
    {
        public WoodContentPage(IPublishedContent content) : base(content)
        {



        }
    }
}

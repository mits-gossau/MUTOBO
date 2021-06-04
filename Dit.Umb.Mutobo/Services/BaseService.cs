using System.Web.Mvc;
using Umbraco.Core.Logging;
using Umbraco.Web;
using Umbraco.Web.Composing;

namespace Dit.Umb.Mutobo.Services
{
    public abstract class BaseService
    {
        protected UmbracoHelper Helper => Current.UmbracoHelper;
        protected UmbracoContext Context => Current.UmbracoContext;
        protected readonly ILogger _logger;
        //protected readonly string _loggingPrefix = "DIT-LogEntry:";

        protected BaseService()
        {
            _logger = (ILogger)DependencyResolver.Current.GetService(typeof(ILogger));
        }

    }
}

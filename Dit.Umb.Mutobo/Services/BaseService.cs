using System.Web.Mvc;
using Umbraco.Core.Logging;
using Umbraco.Core.Scoping;
using Umbraco.Web;
using Umbraco.Web.Composing;

namespace Dit.Umb.Mutobo.Services
{
    public abstract class BaseService
    {

        protected readonly IScopeProvider ScopeProvider;
        protected readonly IUmbracoContextFactory ContextFactory;
        



        protected UmbracoHelper Helper => Current.UmbracoHelper;
        protected UmbracoContext Context => Current.UmbracoContext;
        protected readonly ILogger Logger;
        //protected readonly string _loggingPrefix = "DIT-LogEntry:";

        protected BaseService()
        {
            ContextFactory = (IUmbracoContextFactory)DependencyResolver.Current.GetService(typeof(IUmbracoContextFactory));
            ScopeProvider = (IScopeProvider)DependencyResolver.Current.GetService(typeof(IScopeProvider));
            Logger = (ILogger)DependencyResolver.Current.GetService(typeof(ILogger));
        }

    }
}

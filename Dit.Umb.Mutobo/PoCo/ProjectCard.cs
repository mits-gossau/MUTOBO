using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dit.Umb.Mutobo.Constants;
using Dit.Umb.Mutobo.Enum;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace Dit.Umb.Mutobo.PoCo
{
    public class ProjectCard : Card
    {
        private EProjectStatus Status => this.HasValue(DocumentTypes.ProjectCard.Fields.Status)
            ? (EProjectStatus) System.Enum.Parse(typeof(EProjectStatus), this.Value<string>(DocumentTypes.ProjectCard.Fields.Status))
            : EProjectStatus.None;


        public ProjectCard(IPublishedElement content) : base(content)
        {
        }
    }
}

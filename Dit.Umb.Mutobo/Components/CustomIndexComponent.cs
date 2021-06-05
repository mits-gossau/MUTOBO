
using Examine;
using Umbraco.Core.Composing;

namespace Dit.Umb.Mutobo.Components
{
    public class CustomIndexComponent : IComponent
    {
        private readonly IExamineManager _examineManager;


        public CustomIndexComponent(IExamineManager examineManager)
        {
            _examineManager = examineManager;

        }

        public void Initialize()
        {
            // Because the Create method returns a collection of indexes,
            // we have to loop through them.


            
        }

        public void Terminate() { }
    }
}
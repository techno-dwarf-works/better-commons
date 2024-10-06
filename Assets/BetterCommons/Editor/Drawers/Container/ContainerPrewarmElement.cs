using System.Collections.Generic;
using System.Linq;

namespace Better.Commons.EditorAddons.Drawers.Container
{
    public class ContainerPrewarmElement : SubPrewarmElement
    {
        private List<SubPrewarmElement> PrewarmChildren { get; }

        public ContainerPrewarmElement() : base()
        {
            PrewarmChildren = new List<SubPrewarmElement>();
        }

        public void Add(SubPrewarmElement prewarmElement)
        {
            PrewarmChildren.Add(prewarmElement);
            base.Add(prewarmElement);
        }
        
        public IEnumerable<SubPrewarmElement> GetByTags(IEnumerable<object> tag)
        {
            return PrewarmChildren.Where(x => x.ContainsAnyTags(tag));
        }

        public bool TryGetByTag(object tag, out SubPrewarmElement element)
        {
            element = PrewarmChildren.FirstOrDefault(x => x.ContainsTag(tag));
            return element != null;
        }
    }
}
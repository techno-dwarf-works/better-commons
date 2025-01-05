using System.Collections.Generic;
using System.Linq;
using Better.Commons.EditorAddons.Drawers.Handlers;

namespace Better.Commons.EditorAddons.Drawers.HandlerBinding.Filters
{
    public abstract class HandlersFilter
    {
        public bool TryFilter(HashSet<Binding> bindings, out Binding filteredBinding)
        {
            var candidates = new HashSet<Binding>();

            foreach (var binding in bindings)
            {
                if (!TryFilter(binding)) continue;
                candidates.Add(binding);
            }

            var sortedCandidates = SortCandidates(candidates);

            filteredBinding = sortedCandidates.FirstOrDefault();
            return filteredBinding != null;
        }

        protected virtual IEnumerable<Binding> SortCandidates(IEnumerable<Binding> candidates)
        {
            candidates = candidates.OrderByDescending(GetBindingPriority);
            return candidates;
        }

        protected abstract int GetBindingPriority(Binding bind);


        protected abstract bool TryFilter(Binding binding);
    }
}
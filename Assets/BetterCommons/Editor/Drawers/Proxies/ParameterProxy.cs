using System.Reflection;
using Better.Commons.Runtime.Extensions;

namespace Better.Commons.EditorAddons.Drawers.Proxies
{
    public class ParameterProxy : SimpleProxy
    {
        public ParameterProxy(ParameterInfo info)
            : base(info.ParameterType, info.Name, info.HasDefaultValue ? info.DefaultValue : info.ParameterType.GetDefault())
        {
        }
    }
}
using GpgKee.Providers;
using KeePass.Plugins;

namespace GpgKee
{
    public class GpgKeeExt : Plugin
    {
        public override bool Initialize(IPluginHost host)
        {
            if (host == null)
                return false;

            host.KeyProviderPool.Add(new GpgKeeProvider());
            return true;
        }
    }
}

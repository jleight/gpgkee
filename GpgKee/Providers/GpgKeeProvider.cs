using GpgKee.Encryption;
using KeePassLib.Keys;
using KeePassLib.Utility;
using System.IO;

namespace GpgKee.Providers
{
    internal class GpgKeeProvider : KeyProvider
    {
        private const string ProviderName = "GPG Authentication";
        private const string ProviderAuxExt = ".gpgkee";


        public override string Name
        {
            get { return ProviderName; }
        }


        public override byte[] GetKey(KeyProviderQueryContext ctx)
        {
            return DecryptKey(ctx);
        }

        private static byte[] DecryptKey(KeyProviderQueryContext ctx)
        {
            return Gpg.Decrypt(GetAuxFile(ctx)).GetBuffer();
        }

        private static Stream GetAuxFile(KeyProviderQueryContext ctx)
        {
            var auxPath = UrlUtil.StripExtension(ctx.DatabasePath) + ProviderAuxExt;
            return File.OpenRead(auxPath);
        }
    }
}

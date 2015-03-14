using GpgKee.ExtensionMethods;
using System.Diagnostics;
using System.IO;

namespace GpgKee.Encryption
{
    internal static class Gpg
    {
        public static MemoryStream Decrypt(Stream ciphertext)
        {
            var process = new Process
            {
                EnableRaisingEvents = false,
                StartInfo = new ProcessStartInfo
                {
                    FileName = @"C:\Program Files (x86)\GNU\GnuPG\pub\gpg2.exe",
                    Arguments = @"--decrypt",
                    WindowStyle = ProcessWindowStyle.Hidden,
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true
                }
            };
            process.Start();

            var stdin = process.StandardInput;
            ciphertext.CopyTo(stdin.BaseStream);
            stdin.Close();

            var stdout = new MemoryStream();
            process.WaitForExit();
            process.StandardOutput.BaseStream.CopyTo(stdout);

            return stdout;
        }
    }
}

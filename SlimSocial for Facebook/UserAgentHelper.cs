using System.Runtime.InteropServices;

namespace SlimSocial_for_Facebook
{
    public class UserAgentHelper
    {
        [DllImport("urlmon.dll", CharSet = CharSet.Ansi, ExactSpelling = true)]
        private static extern int UrlMkSetSessionOption(int dwOption, string pBuffer, int dwBufferLength, int dwReserved);

        private const int URLMON_OPTION_USERAGENT = 0x10000001;

        public static void SetDefaultUserAgent(string userAgent)
        {
            UrlMkSetSessionOption(URLMON_OPTION_USERAGENT, userAgent, userAgent.Length, 0);
        }
    }
}
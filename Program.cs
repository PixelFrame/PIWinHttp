using System;
using System.Runtime.InteropServices;

namespace PIWinHttp
{
    class Program
    {
        static void Main(string[] args)
        {
            IntPtr hSession = WinHttp.WinHttpOpen("PINVOKE WINHTTP CLIENT/1.0", AccessType.WINHTTP_ACCESS_TYPE_NO_PROXY, "", "", 0);

            WINHTTP_AUTOPROXY_OPTIONS winHttpAutoProxyOptions = new WINHTTP_AUTOPROXY_OPTIONS();
            WINHTTP_PROXY_INFO winHttpProxyInfo = new WINHTTP_PROXY_INFO();

            winHttpAutoProxyOptions.dwFlags = AutoProxyFlag.WINHTTP_AUTOPROXY_AUTO_DETECT;
            winHttpAutoProxyOptions.dwAutoDetectFlags = AutoDetectFlag.WINHTTP_AUTO_DETECT_TYPE_DHCP | AutoDetectFlag.WINHTTP_AUTO_DETECT_TYPE_DNS_A;
            winHttpAutoProxyOptions.fAutoLogonIfChallenged = true;

            Console.WriteLine(WinHttp.WinHttpGetProxyForUrl(hSession, "http://example.com", ref winHttpAutoProxyOptions, ref winHttpProxyInfo));

            Console.WriteLine(winHttpProxyInfo.lpszProxy);

            Console.WriteLine(WinHttp.WinHttpCloseHandle(hSession));

            winHttpProxyInfo = new WINHTTP_PROXY_INFO();
            winHttpProxyInfo.dwAccessType = AccessType.WINHTTP_ACCESS_TYPE_DEFAULT_PROXY;
            Console.WriteLine(WinHttp.WinHttpGetDefaultProxyConfiguration(ref winHttpProxyInfo));

            Console.ReadLine();
        }
    }
}

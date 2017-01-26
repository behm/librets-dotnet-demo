using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using librets;

namespace LibRetsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var loginUrl = "https://some.rets.server.com/rets/login";
            var username = "";
            var password = "";
            var userAgent = "";

            using (var retsSession = new RetsSession(loginUrl))
            {
				var uri = new Uri(loginUrl);
	            if (uri.Scheme == Uri.UriSchemeHttps)
	            {
					// ssl certificate work around - https://groups.google.com/forum/#!searchin/librets/ssl%7Csort:relevance/librets/g62O8pxsAcg/AXzlKi133TUJ
					retsSession.SetModeFlags(RetsSession.MODE_NO_SSL_VERIFY);
	            }

                if (!string.IsNullOrEmpty(userAgent))
                {
                    retsSession.SetUserAgent(userAgent);
                }
                retsSession.SetRetsVersion(RetsVersion.RETS_1_8_0);

                if (!retsSession.Login(username, password))
                {
                    throw new Exception("RETS login failed");
                }

                var loginResponse = retsSession.GetLoginResponse();

                // todo: inspect login response
            }
        }
    }
}

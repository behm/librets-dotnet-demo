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
            var loginUrl = "";
            var username = "";
            var password = "";
            var userAgent = "";

            using (var retsSession = new RetsSession(loginUrl))
            {
                if (!string.IsNullOrEmpty(userAgent))
                {
                    retsSession.SetUserAgent(userAgent);
                }
                retsSession.SetRetsVersion(RetsVersion.RETS_1_7_2);

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

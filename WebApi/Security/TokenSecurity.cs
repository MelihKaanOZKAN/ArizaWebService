using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using WEBApiDAL;

namespace WebApi.Security
{
    public class TokenSecurity : DelegatingHandler
    {
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            UserDAL userDal = new UserDAL();
            Kullanicilar kullanici = new Kullanicilar();
            string tk = "";
            try
            {
                var queryString = request.Headers;
                var token = queryString.Where(x => x.Key == "Token").FirstOrDefault();
               
                 tk = token.Value.First().ToString();
                kullanici = userDal.getUserByToken(tk);
                if (kullanici != null)
                {
                    var principal = new ClaimsPrincipal(new GenericIdentity(kullanici.KullaniciAdi, "Token"));
                    HttpContext.Current.User = principal;
                }
            }
            catch (ArgumentNullException)
            {
                tk = "";
            }

          

            var logMetadata = BuildRequestMetadata(request);
            var response = await base.SendAsync(request, cancellationToken);
            logMetadata = BuildResponseMetadata(logMetadata, response, kullanici);
           
            await SendToLog(logMetadata);
            return response;
        }

        private async Task<LogMetaData> SendToLog(LogMetaData logMetadata)
        {
            dbATUEntities db = new dbATUEntities();
            db.LogMetaData.Add(logMetadata);
             db.SaveChanges();
            return logMetadata;
        }

        private LogMetaData BuildRequestMetadata(HttpRequestMessage request)
        {
            LogMetaData log = new LogMetaData
            {
                RequestMethod = request.Method.Method,
                RequestTimestamp = DateTime.Now,
                RequestUri = request.RequestUri.ToString()
            };
            return log;
        }
        private LogMetaData BuildResponseMetadata(LogMetaData logMetadata, HttpResponseMessage response, Kullanicilar user)
        {
            logMetadata.ResponseStatusCode = response.StatusCode.ToString();
            logMetadata.ResponseTimestamp = DateTime.Now;
            if(user != null)
            {
                logMetadata.ResponseContentType = " ? User: " + user.KullaniciNo;
            }

            //logMetadata.ResponseContentType = response.Content.ToString();

            return logMetadata;
        }
    }
}
using System;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using WEBApiDAL;

namespace WebApi.Controllers
{
    public class LoginController : ApiController
    {
        /*  [ResponseType(typeof(void))]
          [HttpPost]
          public IHttpActionResult GetLogin()
          {
              return BadRequest("Kullanıcı Adı veya Şifre Giriniz");
          }*/
        [ResponseType(typeof(void))]
        [HttpPost]
        public IHttpActionResult GetLogin(Kullanicilar kullanici)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    LoginDAL loginDAL = new LoginDAL();

                
                    Tokens token = loginDAL.Login(kullanici);

                    if (token == null)
                    {
                        return BadRequest("Hatalı Kullanıcı Adı ve Şifre");
                    }
                    else
                    {
                        var principal = new ClaimsPrincipal(new GenericIdentity(token.Token, "Token"));
                        HttpContext.Current.User = principal;
                        return Ok(token);
                    }
                }
                else
                {
                    return BadRequest("Kullanıcı Adı ve Şifre Giriniz");
                }
            } catch(Exception e)
            {
                return InternalServerError(e.InnerException);
            }
           
        }
    }
}

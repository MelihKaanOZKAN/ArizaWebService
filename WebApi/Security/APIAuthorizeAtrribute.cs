using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using WEBApiDAL;

namespace WebApi.Security
{
    public class APIAuthorizeAtrribute : AuthorizeAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var actionRoles = Roles;
            var userName = HttpContext.Current.User.Identity.Name;
            UserDAL userDAL = new UserDAL();
            var user = userDAL.getUserByUserName(userName);
            if(user!= null)
            {
                if(actionRoles.Contains("AE") && user.KullaniciGruplari.ArızaEkleme)
                {

                }
               else if(actionRoles.Contains("AC") && user.KullaniciGruplari.ArızaCozme)
                {

                }
               else if (actionRoles.Contains("PE") && user.KullaniciGruplari.PersonelEkleme)
                {

                }
                else
                {
                    actionContext.Response = new
                        System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
                }
            }
            else{
                actionContext.Response = new
                       System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
            }
            //base.OnAuthorization(actionContext);
        }
    }
}
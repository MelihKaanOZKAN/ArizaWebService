using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using WebApi.Security;
using WEBApiDAL;

namespace WebApi.Controllers
{
    public class KullanicilarController : ApiController
    {
       

        [Authorize]
        [ResponseType(typeof(IQueryable<Kullanicilar>))]
        [HttpPost]
        public IQueryable<Kullanicilar> GetButunKullanicilar()
        {
            KullanicilarDAL kullanicilarDAL = new KullanicilarDAL();
            return kullanicilarDAL.GetButunKullanicilar();
        }
        [Authorize]
        [HttpPost]
        [ResponseType(typeof(Kullanicilar))]
        public IHttpActionResult GetKullaniciById(Kullanicilar  kullanici)
        {
            KullanicilarDAL kullanicilarDAL = new KullanicilarDAL();
            Kullanicilar kullanicilar = kullanicilarDAL.getKullaniciById(kullanici);
            if (kullanicilar == null)
            {
                return NotFound();
            }

            return Ok(kullanicilar);
        }

        [APIAuthorizeAtrribute(Roles = "PE")]
        [HttpPost]
        [ResponseType(typeof(void))]
        public IHttpActionResult KullaniciGuncelle( Kullanicilar kullanicilar)
        {
            if (!ModelState.IsValid || kullanicilar.KullaniciNo == 0)
            {
                return BadRequest(ModelState);
            }



            KullanicilarDAL kullanicilarDAL = new KullanicilarDAL();
            if (kullanicilarDAL.KullaniciGuncelle(kullanicilar))
            {
                return Ok();
            }
            {
                return InternalServerError();
            }
           

           
        }
        [APIAuthorizeAtrribute(Roles = "PE")]
        [HttpPost]
        [ResponseType(typeof(Kullanicilar))]
        public IHttpActionResult KullaniciEkle(Kullanicilar kullanicilar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            KullanicilarDAL kullanicilarDAL = new KullanicilarDAL();
            if (kullanicilarDAL.KullaniciEkle(kullanicilar))
            {
                return Ok();
            }
            {
                return InternalServerError();
            }
        }

        [APIAuthorizeAtrribute(Roles = "PE")]
        [HttpPost]
        [ResponseType(typeof(Kullanicilar))]
        public IHttpActionResult KullaniciSil(Kullanicilar kullanicilar)
        {
            if (!ModelState.IsValid || kullanicilar.KullaniciNo == 0)
            {
                return BadRequest(ModelState);
            }

            KullanicilarDAL kullanicilarDAL = new KullanicilarDAL();
            if (kullanicilarDAL.KullaniciSil(kullanicilar))
            {
                return Ok();
            }
            {
                return InternalServerError();
            }
        }
    }
}
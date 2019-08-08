using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using WebApi.Security;
using WEBApiDAL;

namespace WebApi.Controllers
{
    public class KullaniciGruplariController : ApiController
    {
         [Authorize]
        [ResponseType(typeof(void))]
        [HttpPost]
        public IQueryable<KullaniciGruplari> GetKullaniciGruplari()
        {
            KullaniciGruplariDAL kullaniciGruplariDAL = new KullaniciGruplariDAL();
            return kullaniciGruplariDAL.getButunGruplar();
        }
        [Authorize]
        [HttpPost]
        [ResponseType(typeof(KullaniciGruplari))]
        public IHttpActionResult GetKullaniciGruplariById(KullaniciGruplari kullaniciGruplarir)
        {
            KullaniciGruplariDAL kullaniciGruplariDAL = new KullaniciGruplariDAL();
            KullaniciGruplari kullaniciGruplari = kullaniciGruplariDAL.getKullaniciGruplariById(kullaniciGruplarir);
            if (kullaniciGruplari == null)
            {
                return NotFound();
            }

            return Ok(kullaniciGruplari);
        }
        [APIAuthorizeAtrribute(Roles = "PE")]
        [HttpPost]
        [ResponseType(typeof(void))]
        public IHttpActionResult KullaniciGrubuGuncelle(KullaniciGruplari kullaniciGruplarir)
        {
            if (!ModelState.IsValid || kullaniciGruplarir.GrupNo == 0)
            {
                return BadRequest(ModelState);
            }

            KullaniciGruplariDAL kullaniciGruplariDAL = new KullaniciGruplariDAL();
            KullaniciGruplari kullaniciGruplari = kullaniciGruplariDAL.getKullaniciGruplariById(kullaniciGruplarir);
            if (kullaniciGruplariDAL.KullaniciGrupGuncelle(kullaniciGruplarir))
            {
                return Ok();
            }
           else {
               return  BadRequest();
            }
         

         
        }
        [APIAuthorizeAtrribute(Roles = "PE")]
        [HttpPost]
        // POST: api/KullaniciGruplaris
        [ResponseType(typeof(void))]
        public IHttpActionResult KullaniciGrubuEkle(KullaniciGruplari kullaniciGruplarir)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            KullaniciGruplariDAL kullaniciGruplariDAL = new KullaniciGruplariDAL();
            KullaniciGruplari kullaniciGruplari = kullaniciGruplariDAL.getKullaniciGruplariById(kullaniciGruplarir);
            if (kullaniciGruplariDAL.KullaniciGrupEkle(kullaniciGruplarir))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }


        }


        [APIAuthorizeAtrribute(Roles = "PE")]
        [ResponseType(typeof(void))]
        [HttpPost]
        public IHttpActionResult KullaniciGrubuSil(KullaniciGruplari kullaniciGruplarir)
        {
      
            if (!ModelState.IsValid || kullaniciGruplarir.GrupNo == 0)
            {
                return BadRequest(ModelState);
            }

            KullaniciGruplariDAL kullaniciGruplariDAL = new KullaniciGruplariDAL();
            KullaniciGruplari kullaniciGruplari = kullaniciGruplariDAL.getKullaniciGruplariById(kullaniciGruplarir);
            if (kullaniciGruplariDAL.KullanciGrupSil(kullaniciGruplarir))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
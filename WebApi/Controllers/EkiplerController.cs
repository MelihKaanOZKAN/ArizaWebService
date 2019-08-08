using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using WebApi.Security;
using WEBApiDAL;

namespace WebApi.Controllers
{
    public class EkiplerController : ApiController
    {
      

        [Authorize]
        [ResponseType(typeof(void))]
        [HttpPost]
        public IQueryable<Ekipler> GetButunEkipler()
        {
            EkiplerDAL ekiplerDAL = new EkiplerDAL();
            return ekiplerDAL.getEkipler();
        }

        [Authorize]
        [HttpPost]
        [ResponseType(typeof(Ekipler))]
        public IHttpActionResult GetEkipById(Ekipler ekip)
        {
            EkiplerDAL ekiplerDAL = new EkiplerDAL();
            Ekipler ekipler = ekiplerDAL.getEkipById(ekip);
            if (ekipler == null)
            {
                return NotFound();
            }

            return Ok(ekipler);
        }


        [APIAuthorizeAtrribute(Roles = "PE")]
        [ResponseType(typeof(void))]
        [HttpPost]
        public IHttpActionResult EkipGuncelle(Ekipler ekip)
        {
            if (!ModelState.IsValid ||ekip.EkipNo == 0)
            {
                return BadRequest(ModelState);
            }

            EkiplerDAL ekiplerDAL = new EkiplerDAL();
            if (ekiplerDAL.EkipGuncelle(ekip))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }


        [APIAuthorizeAtrribute(Roles = "PE")]
        [ResponseType(typeof(Ekipler))]
        [HttpPost]
        public IHttpActionResult EkipEkle(Ekipler ekipler)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            EkiplerDAL ekiplerDAL = new EkiplerDAL();
            if (ekiplerDAL.EkipEkle(ekipler))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        [APIAuthorizeAtrribute(Roles = "PE")]
        [ResponseType(typeof(Ekipler))]
        [HttpPost]
        public IHttpActionResult KisiEkle(Ekipler ekipler)
        {
            if (!ModelState.IsValid || ekipler.EkipNo == 0 || ekipler.Personel.Count == 0)
            {
                return BadRequest(ModelState);
            }

            EkiplerDAL ekiplerDAL = new EkiplerDAL();
            if (ekiplerDAL.KisiEkle(ekipler))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        [APIAuthorizeAtrribute(Roles = "PE")]
        [ResponseType(typeof(Ekipler))]
        [HttpPost]
        public IHttpActionResult KisiSil(Ekipler ekipler)
        {
            if (!ModelState.IsValid || ekipler.EkipNo == 0 || ekipler.Personel.Count == 0)
            {
                return BadRequest(ModelState);
            }

            EkiplerDAL ekiplerDAL = new EkiplerDAL();
            if (ekiplerDAL.KisiSil(ekipler))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        [APIAuthorizeAtrribute(Roles = "PE")]
        [ResponseType(typeof(Ekipler))]
        [HttpPost]
        public IHttpActionResult KategoriEkle(Ekipler ekipler)
        {
            if (!ModelState.IsValid || ekipler.EkipNo == 0 || ekipler.Kategori_2.Count == 0)
            {
                return BadRequest(ModelState);
            }

            EkiplerDAL ekiplerDAL = new EkiplerDAL();
            if (ekiplerDAL.KategoriEkle(ekipler))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        [APIAuthorizeAtrribute(Roles = "PE")]
        [ResponseType(typeof(Ekipler))]
        [HttpPost]
        public IHttpActionResult KategoriSil(Ekipler ekipler)
        {
            
            if (!ModelState.IsValid || ekipler.EkipNo == 0 || ekipler.Kategori_2.Count == 0)
            {
                return BadRequest(ModelState);
            }

            EkiplerDAL ekiplerDAL = new EkiplerDAL();
            if (ekiplerDAL.KategoriSil(ekipler))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        [APIAuthorizeAtrribute(Roles = "PE")]
        [ResponseType(typeof(Ekipler))]
        [HttpPost]
        public IHttpActionResult EkipSil(Ekipler ekipler)
        {

            if (!ModelState.IsValid || ekipler.EkipNo == 0)
            {
                return BadRequest(ModelState);
            }

            EkiplerDAL ekiplerDAL = new EkiplerDAL();
            if (ekiplerDAL.EkipSil(ekipler))
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
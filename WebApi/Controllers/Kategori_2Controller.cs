using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using WebApi.Security;
using WEBApiDAL;

namespace WebApi.Controllers
{
    public class Kategori_2Controller : ApiController
    {
      

        [Authorize]
        [ResponseType(typeof(IQueryable<Kategori_2>))]
        [HttpPost]
        public IQueryable<Kategori_2> GetKategori2ByKat1(Kategori_1 kategori_1)
        {
            Kategori2DAL kategori2DAL = new Kategori2DAL();

            return kategori2DAL.getButunKategori2ByKat1(kategori_1);
        }


        [Authorize]
        [ResponseType(typeof(Kategori_2))]
        [HttpPost]
        public IHttpActionResult GetKategori_2ById(Kategori_2 Kategori_2r)
        {
            Kategori2DAL Kategori2DAL = new Kategori2DAL();
            Kategori_2 Kategori_2 = Kategori2DAL.getKategori2ById(Kategori_2r);
            if (Kategori_2 == null)
            {
                return NotFound();
            }

            return Ok(Kategori_2);
        }

        [APIAuthorizeAtrribute(Roles = "PE")]
        [ResponseType(typeof(void))]
        [HttpPost]
        public IHttpActionResult Kategori2Guncelle(Kategori_2 Kategori_2r)
        {

            if (!ModelState.IsValid || Kategori_2r.KategoriNo == 0)
            {
                return BadRequest(ModelState);
            }
            Kategori2DAL Kategori2DAL = new Kategori2DAL();

            if (Kategori2DAL.Kategori2Guncelle(Kategori_2r))
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
        public IHttpActionResult Kategori2Ekle(Kategori_2 Kategori_2r)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Kategori2DAL Kategori2DAL = new Kategori2DAL();

            if (Kategori2DAL.Kategori2Ekle(Kategori_2r))
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
        public IHttpActionResult Kategori2Sil(Kategori_2 Kategori_2r)
        {

            if (!ModelState.IsValid || Kategori_2r.KategoriNo == 0)
            {
                return BadRequest(ModelState);
            }
            Kategori2DAL Kategori2DAL = new Kategori2DAL();

            if (Kategori2DAL.Kategori2Sil(Kategori_2r))
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
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using WebApi.Security;
using WEBApiDAL;

namespace WebApi.Controllers
{
    public class Kategori_1Controller : ApiController
    {
       

        [Authorize]
        [ResponseType(typeof(IQueryable<Kategori_1>))]
        [HttpPost]
        public IQueryable<Kategori_1> GetButunKategori_1()
        {
            Kategori1DAL kategori1DAL = new Kategori1DAL();

            return kategori1DAL.getButunKategori1();
        }

      
        [Authorize]
        [ResponseType(typeof(Kategori_1))]
        [HttpPost]
        public IHttpActionResult GetKategori_1ById(Kategori_1 kategori_1r)
        {
            Kategori1DAL kategori1DAL = new Kategori1DAL();
            Kategori_1 kategori_1 = kategori1DAL.getKategori1ById(kategori_1r);
            if (kategori_1 == null)
            {
                return NotFound();
            }

            return Ok(kategori_1);
        }

        [APIAuthorizeAtrribute(Roles = "PE")]
        [ResponseType(typeof(void))]
        [HttpPost]
        public IHttpActionResult Kategori1Guncelle(Kategori_1 kategori_1r)
        {
          
            if (!ModelState.IsValid || kategori_1r.KategoriNo == 0)
            {
                return BadRequest(ModelState);
            }
            Kategori1DAL kategori1DAL = new Kategori1DAL();

            if (kategori1DAL.Kategori1Guncelle(kategori_1r))
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
        public IHttpActionResult Kategori1Ekle(Kategori_1 kategori_1r)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Kategori1DAL kategori1DAL = new Kategori1DAL();

            if (kategori1DAL.Kategori1Ekle(kategori_1r))
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
        public IHttpActionResult Kategori1Sil(Kategori_1 kategori_1r)
        {

            if (!ModelState.IsValid || kategori_1r.KategoriNo == 0)
            {
                return BadRequest(ModelState);
            }
            Kategori1DAL kategori1DAL = new Kategori1DAL();

            if (kategori1DAL.Kategori1Sil(kategori_1r))
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
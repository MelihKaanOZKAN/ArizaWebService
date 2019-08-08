using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using WebApi.Security;
using WEBApiDAL;

namespace WebApi.Controllers
{
    public class PersonelController : ApiController
    {
        

        [Authorize]
        [ResponseType(typeof(IQueryable<Personel>))]
        [HttpPost]
        public IQueryable<Personel> GetButunPersonel()
        {
            PersonelDAL personelDAL = new PersonelDAL();
            return personelDAL.getButunPersonel();
        }

        [Authorize]
        [HttpPost]
        [ResponseType(typeof(Personel))]
        public IHttpActionResult GetPersonelById(Personel personel)
        {
            PersonelDAL personelDAL = new PersonelDAL();
            personel = personelDAL.getPersonelById(personel);
            if (personel == null)
            {
                return NotFound();
            }

            return Ok(personel);
        }

        [APIAuthorizeAtrribute(Roles = "PE")]
        [ResponseType(typeof(void))]
        [HttpPost]
        public IHttpActionResult PersonelEkle(Personel personel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            
            PersonelDAL personelDAL = new PersonelDAL();
            if(personelDAL.getPersonelByKimlikNo(personel.KimlikNo) != null)
            {
                return BadRequest("Kimlik numaralı personel zaten ekli");
            }
            if (personelDAL.PersonelEkle(personel))
            {
                return Ok();
            }
            else
            {
                return InternalServerError();
            }
        }

        [APIAuthorizeAtrribute(Roles = "PE")]
        [ResponseType(typeof(void))]
        [HttpPost]
        public IHttpActionResult PersonelGuncelle(Personel personel)
        {
            if (!ModelState.IsValid || personel.PersonelNo == 0)
            {
                return BadRequest(ModelState);
            }

            PersonelDAL personelDAL = new PersonelDAL();
            if (personelDAL.PersonelGuncelle(personel))
            {
                return Ok();
            }
            else
            {
                return InternalServerError();
            }
           
        }

        [APIAuthorizeAtrribute(Roles = "PE")]
        [HttpPost]
        [ResponseType(typeof(Personel))]
        public IHttpActionResult PersonelSil(Personel personel)
        {
            if (!ModelState.IsValid || personel.PersonelNo == 0)
            {
                return BadRequest(ModelState);
            }
            PersonelDAL personelDAL = new PersonelDAL();
            if (personelDAL.PersonelSil(personel))
            {
                return Ok();
            }
            else
            {
                return InternalServerError();
            }
        }

      
    }
}
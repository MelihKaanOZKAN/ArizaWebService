using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using WebApi.Security;
using WEBApiDAL;

namespace WebApi.Controllers
{
    public class ArizalarController : ApiController
    {
      

        [Authorize]
        [ResponseType(typeof(Array))]
        [HttpPost]
        public Array GetButunArizalar()
        {
            ArizalarDAL arizalarDAL = new ArizalarDAL();
            return arizalarDAL.GetButunArizalar().ToArray<Arızalar>();
        }

        [Authorize]
        [ResponseType(typeof(Arızalar))]
        [HttpPost]
        public IHttpActionResult GetArizaById(Arızalar arizalar)
        {
            ArizalarDAL arizalarDAL = new ArizalarDAL();
            Arızalar arızalar = arizalarDAL.GetArizaById(arizalar);
            if (arızalar == null)
            {
                return NotFound();
            }

            return Ok(arızalar);
        }
        [Authorize]
        [HttpPost]
        [ResponseType(typeof(IQueryable))]
        public IHttpActionResult GetArizaByEkip(Ekipler ekip)
        {
            if(ekip.EkipNo == 0)
            {
                return BadRequest("Ekip Numarası Giriniz");
            }
            ArizalarDAL arizalarDAL = new ArizalarDAL();
            IQueryable arızalar = arizalarDAL.GetArizaByEkip(ekip);
            if (arızalar == null)
            {
                return NotFound();
            }
            return Ok(arızalar);
        }

        [Authorize]
        [HttpPost]
        [ResponseType(typeof(IQueryable))]
        public IHttpActionResult GetArizaByOlusturan(Kullanicilar kullanici)
        {
            if(kullanici.KullaniciNo == 0)
            {
                return BadRequest("Kişi Numarası Giriniz");
            }
            ArizalarDAL arizalarDAL = new ArizalarDAL();
            IQueryable arızalar = arizalarDAL.GetArizaByOlusturan(kullanici);
            if (arızalar == null)
            {
                return NotFound();
            }
            return Ok(arızalar);
        }

        [Authorize]
        [HttpPost]
        [ResponseType(typeof(IQueryable))]
        public IHttpActionResult GetArizaByTarih(JObject data)
        {
            try
            {
                DateTime baslangic = data["baslangic"].ToObject<DateTime>();
                DateTime bitis = data["bitis"].ToObject<DateTime>();
                if (baslangic == DateTime.MinValue || bitis == DateTime.MinValue)
                {
                    return BadRequest("Başlangıç ve/veya bitiş tarihi giriniz.");
                }
                ArizalarDAL arizalarDAL = new ArizalarDAL();
                IQueryable arızalar = arizalarDAL.GetArizaByTarih(baslangic, bitis);
                if (arızalar == null)
                {
                    return NotFound();
                }
                return Ok(arızalar);
            }
            catch (NullReferenceException)
            {
                return BadRequest("Geçerli Format: " +
                    "'baslangic':'2019-06-20T00:00:00'," +
                     "'bitis':'2019-06-20T00:00:00'");
            }
          
        }

        [Authorize]
        [HttpPost]
        [ResponseType(typeof(IQueryable))]
        public IHttpActionResult GetArizaByKategori(Kategori_2 kategori)
        {
            if (kategori.KategoriNo == 0)
            {
                return BadRequest("Kategori numarası giriniz.");
            }
            ArizalarDAL arizalarDAL = new ArizalarDAL();
            IQueryable arızalar = arizalarDAL.GetArizaByKategori(kategori);
            if (arızalar == null)
            {
                return NotFound();
            }
            return Ok(arızalar);
        }
        [APIAuthorizeAtrribute(Roles ="AE,AC")]
        [HttpPost]
        [ResponseType(typeof(void))]
        public IHttpActionResult ArizaGuncelle(Arızalar ariza)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (ariza.ArızaNo == 0)
            {
                return BadRequest("Arıza Numarası Eksik");
            }

            ArizalarDAL arizalarDAL = new ArizalarDAL();
            if (arizalarDAL.ArizaGuncelle(ariza))
            {
                return Ok();
            }
            else
            {
                return InternalServerError();
            }
        }
        [APIAuthorizeAtrribute(Roles = "AE,AC")]
        // POST: api/Arızalar
        [ResponseType(typeof(Arızalar))]
        [HttpPost]
        public IHttpActionResult ArizaEkle(Arızalar ariza)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(ariza.ArızaBaslik == "")
            {
                return BadRequest("Arıza Başlığı Giriniz.");

            }
            if(ariza.ArızaNotu == "")
            {
                return BadRequest("Arıza Notu Giriniz.");
            }
            if(ariza.Olusturan == 0)
            {
                return BadRequest("Oluşturan bilgisi eksik");
            }
            if(ariza.ArızaYeri == "")
            {
                return BadRequest("Arıza Yeri Giriniz.");
            }
            if(ariza.Kategori_1.KategoriNo == 0 || ariza.Kategori_2.KategoriNo == 0)
            {
                return BadRequest("Arıza kategorisi eksik.");
            }
            ArizalarDAL arizalarDAL = new ArizalarDAL();
            if (arizalarDAL.ArizaEkle(ariza))
            {
                return Ok(ariza);
            }
            else
            {
                return InternalServerError();
            }
        }

        [APIAuthorizeAtrribute(Roles = "AE,AC")]
        [HttpPost]
        [ResponseType(typeof(void))]
        public IHttpActionResult ArizaSil(Arızalar ariza)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (ariza.ArızaNo == 0)
            {
                return BadRequest("Arıza Numarası Eksik");
            }
            ArizalarDAL arizalarDAL = new ArizalarDAL();
            if (arizalarDAL.ArizaSil(ariza))
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
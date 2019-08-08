using System;
using System.Data.Entity;
using System.Linq;

namespace WEBApiDAL
{
    public class ArizalarDAL
    {

        dbATUEntities db = new dbATUEntities();
        public ArizalarDAL()
        {
            db.Configuration.LazyLoadingEnabled = false;
        }
        public IQueryable<Arızalar> GetButunArizalar()
        {
            return db.Arızalar
             .Include(x => x.Kategori_1)
             .Include(x => x.Kategori_2)
             .Include(x => x.Ekipler)
               .Include(x => x.Kullanicilar);
        }
        public Arızalar GetArizaById(Arızalar ariza)
        {

            Arızalar arızalar = db.Arızalar.Where(x => x.ArızaNo == ariza.ArızaNo)
                .Include(x => x.Kategori_1)
                .Include(x => x.Kategori_2)
                .Include(x => x.Ekipler)
               .Include(x => x.Kullanicilar)
               .FirstOrDefault();
            if (arızalar == null)
            {
                return null;
            }

            return arızalar;
        }

        public IQueryable<Arızalar> GetArizaByEkip(Ekipler Ekip)
        {
            IQueryable<Arızalar> arızalar =  db.Arızalar.Where(x => x.CozumEkibi == Ekip.EkipNo)
               .Include(x => x.Kategori_1)
               .Include(x => x.Kategori_2)
               .Include(x => x.Ekipler)
               .Include(x => x.Kullanicilar);
            return arızalar;
        }
        public IQueryable<Arızalar> GetArizaByOlusturan(Kullanicilar Kullanici)
        {
            IQueryable<Arızalar> arızalar = db.Arızalar.Where(x => x.Olusturan == Kullanici.KullaniciNo)
             .Include(x => x.Kategori_1)
             .Include(x => x.Kategori_2)
             .Include(x => x.Ekipler)
               .Include(x => x.Kullanicilar);
            return arızalar;
        }
        public IQueryable<Arızalar> GetArizaByTarih(DateTime baslangic, DateTime bitis)
        {
            IQueryable<Arızalar> arızalar = 
                db.Arızalar.Where(x => x.ArızaTarihi >= baslangic && x.ArızaTarihi <= bitis)
               .Include(x => x.Kategori_1)
               .Include(x => x.Kategori_2)
               .Include(x => x.Ekipler)
               .Include(x => x.Kullanicilar);
            return arızalar;
        }
        public IQueryable<Arızalar> GetArizaByKategori(Kategori_2 kategori)
        {
            IQueryable<Arızalar> arızalar =
                 db.Arızalar.Where(x => x.Kat2 == kategori.KategoriNo)
                .Include(x => x.Kategori_1)
                .Include(x => x.Kategori_2)
                .Include(x => x.Ekipler)
               .Include(x => x.Kullanicilar);
            return arızalar;
        }
        public bool ArizaEkle(Arızalar ariza)
        {
            try
            {
                db.Arızalar.Add(ariza);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ArizaGuncelle(Arızalar ariza)
        {
            try
            {
                db.Entry(ariza).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool ArizaSil(Arızalar ariza)
        {
            try
            {
                db.Arızalar.Remove(db.Arızalar.Find(ariza.ArızaNo));
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }







        /*
                public IHttpActionResult PutArızalar(int id, Arızalar arızalar)
                {
                    if (!ModelState.IsValid)
                    {
                        return BadRequest(ModelState);
                    }

                    if (id != arızalar.ArızaNo)
                    {
                        return BadRequest();
                    }

                    db.Entry(arızalar).State = EntityState.Modified;

                    try
                    {
                        db.SaveChanges();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!ArızalarExists(id))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }

                    return StatusCode(HttpStatusCode.NoContent);
                }

                // POST: api/Arızalar
                [ResponseType(typeof(Arızalar))]
                public IHttpActionResult PostArızalar(Arızalar arızalar)
                {
                    if (!ModelState.IsValid)
                    {
                        return BadRequest(ModelState);
                    }

                    db.Arızalar.Add(arızalar);
                    db.SaveChanges();

                    return CreatedAtRoute("DefaultApi", new { id = arızalar.ArızaNo }, arızalar);
                }

                // DELETE: api/Arızalar/5
                [ResponseType(typeof(Arızalar))]
                public IHttpActionResult DeleteArızalar(int id)
                {
                    Arızalar arızalar = db.Arızalar.Find(id);
                    if (arızalar == null)
                    {
                        return NotFound();
                    }

                    db.Arızalar.Remove(arızalar);
                    db.SaveChanges();

                    return Ok(arızalar);
                }

                protected override void Dispose(bool disposing)
                {
                    if (disposing)
                    {
                        db.Dispose();
                    }
                    base.Dispose(disposing);
                }

                private bool ArızalarExists(int id)
                {
                    return db.Arızalar.Count(e => e.ArızaNo == id) > 0;
                }
            }*/
    }
}

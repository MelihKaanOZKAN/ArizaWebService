using System;
using System.Data.Entity;
using System.Linq;

namespace WEBApiDAL
{
    public class EkiplerDAL
    {
        dbATUEntities db = new dbATUEntities();
        public EkiplerDAL()
        {
            db.Configuration.LazyLoadingEnabled = false;
        }
        public IQueryable<Ekipler> getEkipler()
        {
            return db.Ekipler
                .Include(x => x.Personel)
                .Include(x => x.Kategori_2);
        }

        public Ekipler getEkipById(Ekipler ekip)
        {
            if (ekip == null)
            {
                return null;
            }
            Ekipler res = db.Ekipler
                .Where(x => x.EkipNo == ekip.EkipNo)
                .Include(x => x.Personel)
                .Include(x => x.Kategori_2).FirstOrDefault();
            return res;
        }
        public Ekipler getEkipById(int id)
        {

            Ekipler res = db.Ekipler
                 .Where(x => x.EkipNo == id)
                 .Include(x => x.Personel)
                 .Include(x => x.Kategori_2).FirstOrDefault();
            return res;
        }
        public bool EkipEkle (Ekipler ekip)
        {
            bool res = false;

            try
            {
                db.Ekipler.Add(ekip);
                db.SaveChanges();
                res = true;
            }catch (Exception)
            {
                res = false;
            }
            return res;
        }

        public bool KisiEkle(Ekipler ekip)
        {
            bool res = false;

            try
            {
              PersonelDAL personelDal = new PersonelDAL();
                foreach (var p in ekip.Personel)
                {
                    db.Personel.Add(p);
                    db.Personel.Attach(p);
                    db.Ekipler.Add(ekip);
                    db.Ekipler.Attach(ekip);
                   }
               db.SaveChanges();
             res = true;
            }
            catch (Exception ex)
            {
                res = false;
            }
            return res;
        }
        public bool KisiSil(Ekipler ekip)
        {
            bool res = false;

            try
            {
                Ekipler ekipler = this.getEkipById(ekip);
                PersonelDAL personelDal = new PersonelDAL();
                foreach (var p in ekip.Personel)
                {
                    Personel personel = db.Personel.Where(a => a.PersonelNo == p.PersonelNo).FirstOrDefault();
                    ekipler.Personel.Remove(personel);
                }
                db.Entry(ekipler).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                res = true;
            }
            catch (Exception ex)
            {
                res = false;
            }
            return res;
        }
        public bool KategoriEkle(Ekipler ekip)
        {
            bool res = false;

            try
            {
                Kategori2DAL kategori2DAL = new Kategori2DAL();
                foreach (var p in ekip.Kategori_2)
                {
                    db.Kategori_2.Add(p);
                    db.Kategori_2.Attach(p);
                    db.Ekipler.Add(ekip);
                    db.Ekipler.Attach(ekip);
                }
                db.SaveChanges();
                res = true;
            }
            catch (Exception ex)
            {
                res = false;
            }
            return res;
        }
        public bool KategoriSil(Ekipler ekip)
        {
            bool res = false;

            try
            {
                Ekipler ekipler = this.getEkipById(ekip);
                Kategori_2 personelDal = new Kategori_2();
                foreach (var p in ekip.Kategori_2)
                {
                    Kategori_2 personel = db.Kategori_2.Where(a => a.KategoriNo == p.KategoriNo).FirstOrDefault();
                    ekipler.Kategori_2.Remove(personel);
                }
                db.Entry(ekipler).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                res = true;
            }
            catch (Exception ex)
            {
                res = false;
            }
            return res;
        }
        public bool EkipGuncelle(Ekipler ekip)
        {
            bool res = false;

            try
            {
                db.Entry(ekip).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                res = true;
            }
            catch (Exception)
            {
                res = false;
            }
            return res;
        }
        public bool EkipSil(Ekipler ekip)
        {
            bool res = false;

            try
            {
                db.Ekipler.Remove(db.Ekipler.Find(ekip.EkipNo));
                db.SaveChanges();
                res = true;
            }
            catch (Exception)
            {
                res = false;
            }
            return res;
        }

    }
}
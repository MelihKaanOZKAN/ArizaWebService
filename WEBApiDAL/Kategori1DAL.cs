using System;
using System.Linq;

namespace WEBApiDAL
{
    public class Kategori1DAL
    {
        dbATUEntities db = new dbATUEntities();
        public Kategori1DAL()
        {
            db.Configuration.LazyLoadingEnabled = false;

        }
        public IQueryable<Kategori_1> getButunKategori1()
        {
            return db.Kategori_1;
        }
      

        public Kategori_1 getKategori1ById(Kategori_1 kategori_1)
        {
            Kategori_1 res = db.Kategori_1.Find(kategori_1.KategoriNo);
            return res;
        }
        public bool Kategori1Ekle(Kategori_1 kategori_1)
        {
            bool res = false;

            try
            {
                db.Kategori_1.Add(kategori_1);
                db.SaveChanges();
                res = true;
            }
            catch (Exception)
            {
                res = false;
            }
            return res;
        }
        public bool Kategori1Guncelle(Kategori_1 kategori_1)
        {
            bool res = false;

            try
            {
                db.Entry(kategori_1).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                res = true;
            }
            catch (Exception)
            {
                res = false;
            }
            return res;
        }
        public bool Kategori1Sil(Kategori_1 kategori_1)
        {
            bool res = false;

            try
            {
                db.Kategori_1.Remove(db.Kategori_1.Find(kategori_1.KategoriNo));
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


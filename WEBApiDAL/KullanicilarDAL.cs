using System;
using System.Data.Entity;
using System.Linq;

namespace WEBApiDAL
{
    public class KullanicilarDAL
    {
        dbATUEntities db = new dbATUEntities();
        public KullanicilarDAL()
        {
            db.Configuration.LazyLoadingEnabled = false;
        }
        public IQueryable<Kullanicilar> GetButunKullanicilar()
        {
            return db.Kullanicilar
                .Include(x => x.Personel)
                .Include(x => x.KullaniciGruplari);
        }


        public Kullanicilar getKullaniciById(Kullanicilar kullanicilar)
        {
            Kullanicilar res = db.Kullanicilar
                .Where(x => x.KullaniciNo == kullanicilar.KullaniciNo)
                .Include(x => x.Personel)
                .Include(x => x.KullaniciGruplari).FirstOrDefault();
            return res;
        }
        public bool KullaniciEkle(Kullanicilar kullanicilar)
        {
            bool res = false;

            try
            {
                db.Kullanicilar.Add(kullanicilar);
                db.SaveChanges();
                res = true;
            }
            catch (Exception)
            {
                res = false;
            }
            return res;
        }
        public bool KullaniciGuncelle(Kullanicilar kullanicilar)
        {
            bool res = false;

            try
            {
                db.Entry(kullanicilar).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                res = true;
            }
            catch (Exception)
            {
                res = false;
            }
            return res;
        }
        public bool KullaniciSil(Kullanicilar kullanici)
        {
            bool res = false;

            try
            {
                db.Kullanicilar.Remove(db.Kullanicilar.Find(kullanici.KullaniciNo));
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

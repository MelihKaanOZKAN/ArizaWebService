using System;
using System.Linq;

namespace WEBApiDAL
{
    public class KullaniciGruplariDAL
    {
        dbATUEntities db = new dbATUEntities();
        public KullaniciGruplariDAL()
        {
            db.Configuration.LazyLoadingEnabled = false;
        }
        public IQueryable<KullaniciGruplari> getButunGruplar()
        {
            return db.KullaniciGruplari;
        }


        public KullaniciGruplari getKullaniciGruplariById(KullaniciGruplari kullaniciGruplari)
        {
            KullaniciGruplari res = db.KullaniciGruplari.Find(kullaniciGruplari.GrupNo);
            return res;
        }
        public bool KullaniciGrupEkle(KullaniciGruplari kullaniciGruplari)
        {
            bool res = false;

            try
            {
                db.KullaniciGruplari.Add(kullaniciGruplari);
                db.SaveChanges();
                res = true;
            }
            catch (Exception)
            {
                res = false;
            }
            return res;
        }
        public bool KullaniciGrupGuncelle(KullaniciGruplari kullaniciGruplari)
        {
            bool res = false;

            try
            {
                db.Entry(kullaniciGruplari).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                res = true;
            }
            catch (Exception)
            {
                res = false;
            }
            return res;
        }
        public bool KullanciGrupSil(KullaniciGruplari kullaniciGruplari)
        {
            bool res = false;

            try
            {
                db.KullaniciGruplari.Remove(db.KullaniciGruplari.Find(kullaniciGruplari.GrupNo));
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
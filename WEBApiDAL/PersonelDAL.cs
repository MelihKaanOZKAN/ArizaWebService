using System;
using System.Linq;

namespace WEBApiDAL
{
    public class PersonelDAL
    {
        dbATUEntities db = new dbATUEntities();

        public PersonelDAL()
        {
            db.Configuration.LazyLoadingEnabled = false;
        }
        public IQueryable<Personel> getButunPersonel()
        {
            return db.Personel;
        }


        public Personel getPersonelById(Personel personel)
        {
            Personel res = db.Personel.Find(personel.PersonelNo);
            return res;
        }
        public Personel getPersonelById(int id)
        {
            Personel res = db.Personel.Find(id);
            return res;
        }
        public Personel getPersonelByKimlikNo(decimal kimlikNo)
        {
            Personel res = db.Personel.Where(x => x.KimlikNo == kimlikNo).FirstOrDefault();
            return res;
        }
        public bool PersonelEkle(Personel personel)
        {
            bool res = false;

            try
            {
                db.Personel.Add(personel);
                db.SaveChanges();
                res = true;
            }
            catch (Exception)
            {
                res = false;
            }
            return res;
        }
        public bool PersonelGuncelle(Personel personel)
        {
            bool res = false;

            try
            {
                db.Entry(personel).State = System.Data.Entity.EntityState.Modified;
                
                db.SaveChanges();
                res = true;
            }
            catch (Exception ex)
            {
                res = false;
            }
            return res;
        }
        public bool PersonelSil(Personel personel)
        {
            bool res = false;

            try
            {
                db.Personel.Remove(db.Personel.Find(personel.PersonelNo));
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

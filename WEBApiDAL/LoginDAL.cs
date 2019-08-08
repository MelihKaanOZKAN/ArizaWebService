using System;
using System.Data.Entity;
using System.Linq;

namespace WEBApiDAL
{
    public class LoginDAL
    {
        dbATUEntities db = new dbATUEntities();
       
        public Tokens Login(Kullanicilar kullanici)
        {
            Kullanicilar isThereUser = null;
            using (var db1 = new dbATUEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;
                /* isThereUser = (from kl in db1.Kullanicilar
                                 where kl.KullaniciAdi == kullanici.KullaniciAdi && kl.Sifre == kullanici.Sifre
                                 select kl)
                                 .FirstOrDefault<Kullanicilar>();*/

                isThereUser = db.Kullanicilar.Where(a => a.KullaniciAdi == kullanici.KullaniciAdi
                && a.Sifre == kullanici.Sifre)
                    .Include(p => p.Personel)
                    .Include(p => p.KullaniciGruplari)
                    .Include(p => p.Personel.Ekipler)
                    .FirstOrDefault();
                    
                    
                    /*select new Kullanicilar()
                {
                    KullaniciAdi = kl.KullaniciAdi,
                    KullaniciNo = kl.KullaniciNo,
                    PersonelNo = kl.PersonelNo,
                    KullaniciGrubu = kl.KullaniciGrubu

                }*/

            }
           
            if(isThereUser != null)
            {
                    Tokens res = new Tokens();
               

                    res.Kullanicilar = isThereUser;
               

                    res.KullaniciNo = isThereUser.KullaniciNo;
            //    PersonelDAL personelDAL = new PersonelDAL();
                res.Token = RandomString(40);
                res.Kullanicilar = isThereUser;
              //  res.Kullanicilar.Personel = personelDAL.getPersonelById(isThereUser.PersonelNo);
                db.Entry(res.Kullanicilar).State = System.Data.Entity.EntityState.Modified;
                if(isThereUser.Tokens.Count == 0)
                {
                    db.Tokens.Add(res);
                    db.SaveChanges();
                }
                else
                {
                    Tokens tokens = isThereUser.Tokens.First<Tokens>();
                    isThereUser.Tokens.Clear();
                    res.Token = tokens.Token;

                }

                res.Kullanicilar.KullaniciAdi = "";
                res.Kullanicilar.Sifre = "";
                res.Kullanicilar.Personel.KimlikNo = 0;
                return res;
            }
            else
            {
                return null;
            }
        }
        private static Random random = new Random();
        private static string RandomString(int length)
        {
            const string chars = "abcdefghıjklmnopqrstuvwxtzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
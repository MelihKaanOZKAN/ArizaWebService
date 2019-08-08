using System.Linq;

namespace WEBApiDAL
{
    public class UserDAL
    {
        dbATUEntities db = new dbATUEntities();
     public Kullanicilar getUserByToken(string Token)
        {
            /*var kullanici = from tk in db.TokenList
                           join kl in db.Kullanicilar on tk.KullaniciNo equals kl.KullaniciNo
                           where tk.Token == Token
                           select kl;*/
       

            Kullanicilar isThereUser = (from kl in db.Kullanicilar
                           join tk in db.Tokens on kl.KullaniciNo equals tk.KullaniciNo
                           where tk.Token == Token
                           select kl)
                             .FirstOrDefault<Kullanicilar>();

            if (isThereUser != null)
            {
                
                return isThereUser;
            }
            return null;

        }
        public Kullanicilar getUserByUserName(string Username)
        {
            /*var kullanici = from tk in db.TokenList
                           join kl in db.Kullanicilar on tk.KullaniciNo equals kl.KullaniciNo
                           where tk.Token == Token
                           select kl;*/


            Kullanicilar isThereUser = (from kl in db.Kullanicilar
                                        join grup in db.KullaniciGruplari on kl.KullaniciGrubu  equals grup.GrupNo
                                        where kl.KullaniciAdi == Username
                                        select kl)
                             .FirstOrDefault<Kullanicilar>();

            if (isThereUser != null)
            {
                KullaniciGruplariDAL kullaniciGruplariDAL = new KullaniciGruplariDAL();
                KullaniciGruplari kl = new KullaniciGruplari();
                kl.GrupNo = isThereUser.KullaniciGrubu;
                isThereUser.KullaniciGruplari = kullaniciGruplariDAL.getKullaniciGruplariById(kl);
                return isThereUser;
            }
            return null;

        }


    }
}
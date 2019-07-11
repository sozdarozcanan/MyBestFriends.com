using MyBestFriends.Entities;
using MyBestFriends.Entities.ValidationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBestFriends.BusinessLayer
{
   public class KullaniciYönetimi
    {
        private Repository<Kullanici> repo_User = new Repository<Kullanici>();
       
        public Kullanici KullaniciKayit(RegisterViewModel kayit)
        {
         Kullanici kullanici= repo_User.Find(x => x.Mail == kayit.Mail);
            if (kullanici!=null)
            {
                throw new Exception("Girdiğiniz e-posta adresi kullanılmaktadır.");
            }
            else
            {
                repo_User.Insert(new Kullanici()
                {
                    KullaniciAdiSoyadi = kayit.KullaniciAdiSoyadi,
                    Mail = kayit.Mail,
                    ProfilFotoDosyaAdi = "User.png",
                    Sifre=kayit.Sifre, 
                    Telefon=kayit.Telefon                                    
                });
                kullanici=repo_User.Find(x => x.Mail == kayit.Mail);
            }
            return kullanici;
        }

        public Kullanici KullaniciGiris(LoginViewModel giris)
        {
            Kullanici kullaniciGiris = repo_User.Find(x => x.Mail == giris.Mail && x.Sifre==giris.Sifre);

            if (kullaniciGiris ==null)
            {
                throw new Exception("Kullanıcı ya da şifre hatalı");
            }
            else
            {
                kullaniciGiris = repo_User.Find(x => x.Mail == giris.Mail && x.Sifre == giris.Sifre);
            }
            return kullaniciGiris;
        }

        public Kullanici GetKullaniciById(int id)
        {
            Kullanici kullanici = repo_User.Find(x => x.KullaniciID == id);

            if (kullanici ==null)
            {
                throw new Exception("Kullanıcı bulunamadı.");
            }
            return kullanici;
        }

        public Kullanici ProfilGuncelleme(Kullanici kayit)
        {
            Kullanici db_user = repo_User.Find(x => x.KullaniciID != kayit.KullaniciID && (x.Mail==kayit.Mail || x.Telefon==kayit.Telefon) ); // Database bak bakalım set ediceği bilgi database de var mı
            

            if (db_user != null && db_user.KullaniciID!=kayit.KullaniciID)
            {                
                if (db_user.Mail==kayit.Mail)
                {
                    throw new Exception("E-posta adresi kayıtlı.");
                }
                if (db_user.Telefon == kayit.Telefon)
                {
                    throw new Exception("Telefon kayıtlı.");
                }
            }
            db_user = repo_User.Find(x => x.KullaniciID == kayit.KullaniciID);
            db_user.KullaniciAdiSoyadi = kayit.KullaniciAdiSoyadi;
            db_user.Mail = kayit.Mail;
            db_user.Sifre = kayit.Sifre;
            db_user.Telefon = kayit.Telefon;

            if (string.IsNullOrEmpty(kayit.ProfilFotoDosyaAdi)==false)
            {
                db_user.ProfilFotoDosyaAdi = kayit.ProfilFotoDosyaAdi;
            }
            if (repo_User.Update(db_user)==0)
            {
                throw new Exception("Profil güncellenemedi.");
            }
            return db_user;
        }

        public Kullanici DeleteByKullaniciId(int kullaniciID)
        {
            Kullanici kullanici = new Kullanici();
            kullanici = repo_User.Find(x => x.KullaniciID == kullaniciID);
            if (kullanici!=null)
            {
                repo_User.Delete(kullanici);
            }
            return kullanici;
        }
    }
}
 
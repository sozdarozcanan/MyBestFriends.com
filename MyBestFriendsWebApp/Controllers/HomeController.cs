using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using MyBestFriends.Entities.ValidationModels;
using MyBestFriends.BusinessLayer;
using MyBestFriends.Entities;
using System.Net;


namespace MyBestFriendsWebApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            if (TempData["mesaj"] == "EsArayanlar")
            {
                TempData["mesaj"] = "Sahiplendirme  ";
                return RedirectToAction("Index");
            }
            TempData["mesaj"] = "Sahiplendirme";
            return View();
        }
        public ActionResult ByHayvan(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            IlanYonetimi hy = new IlanYonetimi();
            List<Ilan> hyvn;
            if (TempData["mesaj"] == "Sahiplendirme")
            {
                hyvn = hy.GetHayvanById(id.Value, true);
                if (hyvn == null)
                {
                    return HttpNotFound();
                }
                TempData["mesaj"] = "Sahiplendirme";
                return View("Index", hyvn);
            }
            else
            {
                hyvn = hy.GetHayvanById(id.Value, false);
                TempData["mesaj"] = "EsArayanlar";
                if (hyvn == null)
                {
                    return HttpNotFound();
                }
                return View("EsArayanlar", hyvn);
            }

        }
        public ActionResult Hakkimizda()
        {
            return View();
        }
        public ActionResult Iletisim()
        {
            return View();
        }
        public ActionResult EsArayanlar()
        {
            TempData["mesaj"] = "EsArayanlar";
            return View();
        }
        public ActionResult Profil()
        {
            Kullanici kayitliKullanici = Session["login"] as Kullanici;
            KullaniciYönetimi KY = new KullaniciYönetimi();
            try
            {

                Kullanici kul = KY.GetKullaniciById(kayitliKullanici.KullaniciID);
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", ex.Message);
            }
            return View(kayitliKullanici);
        }
        public ActionResult EditProfil()
        {
            Kullanici kayitliKullanici = Session["login"] as Kullanici;
            KullaniciYönetimi KY = new KullaniciYönetimi();
            try
            {

                Kullanici kul = KY.GetKullaniciById(kayitliKullanici.KullaniciID);
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", ex.Message);
            }
            return View(kayitliKullanici);

        }
        [HttpPost]
        public ActionResult EditProfil(Kullanici model, HttpPostedFileBase ProfilFoto)
        {
            if (ModelState.IsValid)
            {
                if (ProfilFoto != null &&
                (ProfilFoto.ContentType == "image/jpeg" ||
                 ProfilFoto.ContentType == "image/jpg" ||
                 ProfilFoto.ContentType == "image/png"))
                {
                    Random rnd = new Random();
                    string dosyaAdi = $"Kullanıcı_{rnd.Next(1,10)}.{ProfilFoto.ContentType.Split('/')[1]}";
                    ProfilFoto.SaveAs(Server.MapPath($"~/Images/{dosyaAdi}"));
                    model.ProfilFotoDosyaAdi = dosyaAdi;
                }
                KullaniciYönetimi KY = new KullaniciYönetimi();
                try
                {
                    Kullanici klnc = KY.ProfilGuncelleme(model);
                    Session["login"] = klnc;  // Profil güncelledik session güncellendi.
                }
                catch (Exception ex)
                {
                    int sonuc;
                    ModelState.AddModelError("", ex.Message);
                    sonuc = string.Compare("telefon", ex.Message);
                    if (sonuc == -1)
                    {
                        return RedirectToAction("KayitliTelefon", "Hata");
                    }

                    sonuc = string.Compare("E-posta", ex.Message);
                    if (sonuc == -1)
                    {
                        return RedirectToAction("KayitliEmail", "Hata");
                    }
                }
                return RedirectToAction("Profil");
            }
            return View(model);


        }

        public ActionResult DeleteProfil()
        {
            Kullanici kullanici = Session["login"] as Kullanici;
            KullaniciYönetimi KY = new KullaniciYönetimi();
            kullanici = KY.DeleteByKullaniciId(kullanici.KullaniciID);
            Session.Clear();
            return RedirectToAction("Index");
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                KullaniciYönetimi ky = new KullaniciYönetimi();
                Kullanici kullanici = null;
                try
                {
                    kullanici = ky.KullaniciGiris(model);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
                if (kullanici != null)
                {
                    Session["login"] = kullanici;
                    return RedirectToAction("Index", "Home");

                }
                return View(model);
            }
            return View(model);
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                KullaniciYönetimi ky = new KullaniciYönetimi();
                Kullanici kullanici = null;
                try
                {
                    kullanici = ky.KullaniciKayit(model);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
                if (kullanici == null)
                {
                    return View(model);
                }
                return RedirectToAction("RegisterOk", "Home");
            }
            return View(model);
        }
        public ActionResult RegisterOk()
        {
            return View();
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index");
        }


    }
}
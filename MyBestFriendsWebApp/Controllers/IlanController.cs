using MyBestFriends.BusinessLayer;
using MyBestFriends.Entities;
using MyBestFriendsWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MyBestFriendsWebApp.Controllers
{
    public class IlanController : Controller
    {
        IlanYonetimi IY = new IlanYonetimi();
        Repository<Ilan> repo_ilan = new Repository<Ilan>();
        Repository<Sehir> repo_sehir = new Repository<Sehir>();
        Repository<HayvanCins> repo_cins = new Repository<HayvanCins>();
        Repository<Hayvan> repo_hayvan = new Repository<Hayvan>();
        Repository<Kullanici> repo_kullanici = new Repository<Kullanici>();
        public ActionResult Index()
        {
            var ilanlar = IY.getIlanlar().Where(x => x.KullaniciID == KayitliSession.Kullanici.KullaniciID);
            return View(ilanlar.ToList());
        }
     
        public ActionResult Create()
        {
            
            Kullanici user = Session["login"] as Kullanici;
            
            ViewBag.SehirID = new SelectList(repo_sehir.List(), "SehirID", "SehirAdi");
            ViewBag.CinsID = new SelectList(repo_cins.List(), "CinsID", "CinsAdi");
            ViewBag.HayvanID = new SelectList(repo_hayvan.List(), "HayvanID", "HayvanTuru");
           
            return View();
        }
        [HttpPost]
       public JsonResult IDCinsListe(int id)
        {
            List<HayvanCins> liste = repo_cins.List(x => x.HayvanID == id);
            List<SelectListItem> secilenListe = (from i in liste
                                                 select new SelectListItem
                                                 {
                                                     Value = i.CinsID.ToString(),
                                                     Text = i.CinsAdi
                                                 }).ToList();
            return Json(secilenListe,JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Ilan ilan, HttpPostedFileBase IlanFoto)
        {
            if (ModelState.IsValid) 
            {
                ilan.KullaniciID = KayitliSession.Kullanici.KullaniciID;
                if (IlanFoto != null &&
              (IlanFoto.ContentType == "image/jpeg" ||
               IlanFoto.ContentType == "image/jpg" ||
               IlanFoto.ContentType == "image/png"))
                {
                    Random rnd = new Random();
                    string dosyaAdi = $"Ilan_{rnd.Next(1,500)}.{IlanFoto.ContentType.Split('/')[1]}";
                    IlanFoto.SaveAs(Server.MapPath($"~/Images/{dosyaAdi}"));
                    ilan.Fotograf = dosyaAdi;
                }
               
                repo_ilan.Insert(ilan);
                return RedirectToAction("Index");
            }
            ViewBag.SehirID = new SelectList(repo_sehir.List(), "SehirID", "SehirAdi",ilan.SehirID);        
            ViewBag.CinsID = new SelectList(repo_cins.List(), "CinsID", "CinsAdi",ilan.CinsID);
           
            //ViewBag.HayvanID = new SelectList(repo_hayvan.List(), "HayvanID", "HayvanAdi", ilan.Cins.HayvanID);
            return View(ilan);
        }
       
       
        public ActionResult Edit(int? id)
        {
            ViewBag.SehirID = new SelectList(repo_sehir.List(), "SehirID", "SehirAdi");
            ViewBag.CinsID = new SelectList(repo_cins.List(), "CinsID", "CinsAdi");
            ViewBag.HayvanID = new SelectList(repo_hayvan.List(), "HayvanID", "HayvanTuru");
            if (id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ilan ilan = repo_ilan.Find(x => x.IlanID == id);
            if (ilan==null)
            {
                return HttpNotFound();
            }
            return View(ilan);
        }
       [HttpPost]
       [ValidateAntiForgeryToken]
        public ActionResult Edit(Ilan ilan, HttpPostedFileBase IlanFoto)
        {
            ViewBag.SehirID = new SelectList(repo_sehir.List(), "SehirID", "SehirAdi");
            ViewBag.CinsID = new SelectList(repo_cins.List(), "CinsID", "CinsAdi");
            if (ModelState.IsValid)
            {
                if (IlanFoto != null &&
            (IlanFoto.ContentType == "image/jpeg" ||
             IlanFoto.ContentType == "image/jpg" ||
             IlanFoto.ContentType == "image/png"))
                {
                    Random rnd = new Random();
                    string dosyaAdi = $"Ilan_{rnd.Next(1,500)}.{IlanFoto.ContentType.Split('/')[1]}";
                    IlanFoto.SaveAs(Server.MapPath($"~/Images/{dosyaAdi}"));
                    ilan.Fotograf = dosyaAdi;
                }
                

                Ilan db_ilan = repo_ilan.Find(x => x.IlanID == ilan.IlanID);
                db_ilan.KullaniciID = KayitliSession.Kullanici.KullaniciID;
                db_ilan.IlanTuru = ilan.IlanTuru;
                db_ilan.IlanTarihi = ilan.IlanTarihi;
                db_ilan.SehirID = ilan.SehirID;
                db_ilan.Cinsiyet = ilan.Cinsiyet;
                db_ilan.CinsID =ilan.CinsID;
                db_ilan.Aciklama = ilan.Aciklama;
                db_ilan.Fotograf = ilan.Fotograf;
                    
                
                repo_ilan.Update(db_ilan);

                return RedirectToAction("Index");
            }
            
            return View(ilan);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ilan ilan = repo_ilan.Find(x => x.IlanID == id);
            if (ilan == null)
            {
                return HttpNotFound();
            }
            return View(ilan);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ilan ilan = repo_ilan.Find(x => x.IlanID == id);
            repo_ilan.Delete(ilan);
            return RedirectToAction("Index");
        }
    }
}
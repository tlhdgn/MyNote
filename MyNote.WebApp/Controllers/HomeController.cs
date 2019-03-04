using MyNote.BusinessLayer;
using MyNote.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MyNote.WebApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            //BusinessLayer.Test test = new BusinessLayer.Test();

            //user tablosuna insert etmek için
            //test.InsertTest();

            //user tablosundaki kaydı update için
            //test.UpdateTest();

            //user tablosundaki kaydı silmek için
            //test.DeleteTest();

            //Singleteon pattern için çoklu tablolarla ilişki kurulması
            //test.CommentTest();

            //sol tarafataki kategoriler sekmesine tıklanıldığında gelen categoriye bağlı notları görüntülemek için
            //if(TempData["catTemp"]!=null)
            //{
            //    return View(TempData["catTemp"] as List<Note>);
            //}

            NoteManager nm = new NoteManager();
            return View(nm.GetAllNote());

        }

        public ActionResult ByCategory(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            CategoryManager cm = new CategoryManager();
            Category cat = cm.GetCategoryById(id.Value);

            if (cat == null)
            {
                return HttpNotFound();
            }
            return View("Index", cat.Notes);
        }
    }
}
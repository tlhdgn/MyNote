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
    public class NoteController : Controller
    {
        private NoteManager noteManager = new NoteManager();

        // GET: Note
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetNoteText(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Note note = noteManager.Find(x => x.Id == id);

            if (note == null)
            {
                return HttpNotFound();
            }

            return PartialView("_PartialNoteText", note);
        }
    }
}
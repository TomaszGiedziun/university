using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using notatka.Models;

namespace notatka.Controllers
{
    public class NoteController : Controller
    {
        // GET: Note
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Index(AddNoteModel model)
        {
            if(ModelState.IsValid)
            {
                var note = new Note();

                note.Title = model.Title;
                note.Content = model.Content;

                using (var ctx = new ApplicationDbContext())
                {
                    ctx.Notes.Add(note);
                    ctx.SaveChanges();
                }

                    return RedirectToAction("Index");
            }
            ViewBag.Error = "Wypełnij poprawnie notatkę.";
            return View(model);
        }

        public ActionResult List()
        {
            var viewmodel = new ListNotesViewModel();

            using (var ctx = new ApplicationDbContext())
            {
                var notes = ctx.Notes.Select(note=> new ListNoteItem()
                {
                    Title =note.Title,
                    Content =note.Content,
                    Id =note.Id.ToString()
                }).ToList();

                viewmodel.Notes = notes;
            }
            return View(viewmodel);
        }

        public ActionResult Delete(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var note = ctx.Notes.Single(n => n.Id == id);
                ctx.Notes.Remove(note);
                ctx.SaveChanges();
              
            }

            return RedirectToAction("List");
        }

        public ActionResult Edit(int id)
        {
            var viewmodel = new EditViewModel();

            using (var ctx = new ApplicationDbContext())
            {
               var note = ctx.Notes.Single(m => m.Id == id);
                viewmodel.Title = note.Title;
                viewmodel.Content = note.Content;
                viewmodel.Id = note.Id;
               ctx.SaveChanges();
            }

            return RedirectToAction("List");
        }


    }

    public class EditViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }

    public class AddNoteModel
    {
        [Required]
        [MinLength(4)]
        public string Title { get; set; }

        [Required]
        [MinLength(4)]
        //[AllowHtml]
        public string Content { get; set; }
    }

    public class ListNotesViewModel
    {
        public List<ListNoteItem> Notes;
    }

    public class ListNoteItem
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
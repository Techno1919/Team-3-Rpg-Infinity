using RpgInfinity.Models;
using RpgInfinity.Models.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RpgInfinity.Controllers
{


    public class CharacterController : Controller
    {
        public static IEnumerable<Models.Character> characters = new List<Models.Character>();
        // GET: Character
        public ActionResult Index()
        {
            return View(characters);
        }

        // GET: Character/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Character/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Character/Create
        [HttpPost]
        public ActionResult Create(Character character)
        {
            try
            {
                // TODO: Add insert logic here
                var repo = new CharacterRepo();

                repo.AddCharacter(character);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Character/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Character/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Character/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Character/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

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
            IEnumerable<Character> charList = new List<Character>();
            var repo = new CharacterRepo();

            charList = repo.GetAllCharacters();

            return View(charList);
        }

        // GET: Character/Details/5
        public ActionResult Details(int id)
        {
            var repo = new CharacterRepo();

            return View(repo.GetCharacter(id));
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
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return View();
            }
        }

        // GET: Character/Edit/5
        public ActionResult Edit(int id)
        {
            var repo = new CharacterRepo();

            return View(repo.GetCharacter(id));
        }

        // POST: Character/Edit/5
        [HttpPost]
        public ActionResult Edit(Character character)
        {
                var repo = new CharacterRepo();

                repo.UpdateCharacter(character);

                return RedirectToAction("Index");
        }

        // GET: Character/Delete/5
        public ActionResult Delete(int id)
        {
            var repo = new CharacterRepo();

            return View(repo.GetCharacter(id));
        }

        // POST: Character/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Character character)
        {
            try
            {
                var repo = new CharacterRepo();

                repo.DeleteCharacter(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

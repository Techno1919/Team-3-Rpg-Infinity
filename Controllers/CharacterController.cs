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
        private static int? characterUserId;

        // GET: Character
        public ActionResult Index()
        {
            IEnumerable<Character> charList = new List<Character>();
            var repo = new CharacterRepo();

            charList = repo.GetAllCharacters();

            charList = charList.OrderByDescending(c => c.UserId).ToList();

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

        // GET: Character/RandomCreate
        public ActionResult RandomCreate()
        {
            return View();
        }

        // POST: Character/RandomCreate
        [HttpPost]
        public ActionResult RandomCreate(Character character)
        {
            try
            {
                // TODO: Add insert logic here
                var repo = new CharacterRepo();

                repo.AddRandomCharacter(character);

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

            Character character = repo.GetCharacter(id);
            characterUserId = character.UserId;

            return View(character);
        }

        // POST: Character/Edit/5
        [HttpPost]
        public ActionResult Edit(Character character)
        {
            var repo = new CharacterRepo();

            if (characterUserId == 1)
            {
                if (HomeController._currentUser != null)
                {
                    repo.AddCharacter(character);
                }
            }
            else
            {
                repo.UpdateCharacter(character);
            }
            characterUserId = null;

            return RedirectToAction("Index");
        }

        // GET: Character/Delete/5
        public ActionResult Delete(int id)
        {
            var repo = new CharacterRepo();

            Character character = repo.GetCharacter(id);

            if (character.UserId == 1)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(repo.GetCharacter(id));
            }
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

        // GET: Character/Race
        public ActionResult Race(int id)
        {
            var repo = new CharacterRepo();

            return View(repo.GetCharacterRace(id));
        }

        // GET: Character/Class
        public ActionResult Class(int id)
        {
            var repo = new CharacterRepo();

            return View(repo.GetCharacterClass(id));
        }

        public ActionResult AddImage()
        {
            return View("AddImage");
        }

        [HttpPost]
        public ActionResult AddImage(Image img, HttpPostedFileBase file, int id)
        {
            var repo = new CharacterRepo();

            return View("Details", repo.AddImage(img, file, id));
        }

    }
}

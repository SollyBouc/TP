using BO;
using System;
using System.Linq;
using System.Web.Mvc;
using TPPiz.Database;
using TPPiz.Models;

namespace TPPiz.Controllers
{
    public class PizzaController : Controller
    {
        // GET: Pizza
        public ActionResult Index()
        {
            return View(FakeDb.Instance.Pizzas);
        }

        // GET: Pizza/Details/5
        public ActionResult Details(int id)
        {
            PizzaCreateViewModel vm = new PizzaCreateViewModel();
            vm.Pizza = FakeDb.Instance.Pizzas.FirstOrDefault(x => x.Id == id);
            return View(vm);
        }

        // GET: Pizza/Create
        public ActionResult Create()
        {
            PizzaCreateViewModel vm = new PizzaCreateViewModel();

            vm.Pates = FakeDb.Instance.Pates.Select(x => new SelectListItem { Text = x.Nom, Value = x.Id.ToString() }).ToList();
            vm.Ingredients = FakeDb.Instance.Ingredients.Select(x => new SelectListItem { Text = x.Nom, Value = x.Id.ToString() }).ToList();
            return View(vm);
        }

        // POST: Pizza/Create
        [HttpPost]
        public ActionResult Create(PizzaCreateViewModel vm)
        {
            

                if (ModelState.IsValid)
                {


                    Pizza pizza = vm.Pizza;

                    pizza.Pate = FakeDb.Instance.Pates.FirstOrDefault(x => x.Id == vm.IdPate);

                    pizza.Ingredients = FakeDb.Instance.Ingredients.Where(x => vm.IdsIngredients.Contains(x.Id)).ToList();

                    pizza.Id = FakeDb.Instance.Pizzas.Count == 0 ? 1 : FakeDb.Instance.Pizzas.Max(x => x.Id) + 1;

                    FakeDb.Instance.Pizzas.Add(pizza);

                    return RedirectToAction("Index");
                }

                else
                {
                    vm.Pates = FakeDb.Instance.Pates.Select(x => new SelectListItem { Text = x.Nom, Value = x.Id.ToString() }).ToList();
                    vm.Ingredients = FakeDb.Instance.Ingredients.Select(x => new SelectListItem { Text = x.Nom, Value = x.Id.ToString() }).ToList();
                    return View(vm);
                }

            }
           


        

        // GET: Pizza/Edit/5
        public ActionResult Edit(int id)
        {
            PizzaCreateViewModel vm = new PizzaCreateViewModel();

            vm.Pates = FakeDb.Instance.Pates.Select(x => new SelectListItem { Text = x.Nom, Value = x.Id.ToString() }).ToList();
            vm.Ingredients = FakeDb.Instance.Ingredients.Select(x => new SelectListItem { Text = x.Nom, Value = x.Id.ToString() }).ToList();

            vm.Pizza = FakeDb.Instance.Pizzas.FirstOrDefault(x => x.Id == id);

            if (vm.Pizza.Pate != null)
            {
                vm.IdPate = vm.Pizza.Pate.Id;
            }

            if (vm.Pizza.Ingredients.Any())
            {
                vm.IdsIngredients = vm.Pizza.Ingredients.Select(x => x.Id).ToList();

            }

            return View(vm);
        }

        // POST: Pizza/Edit/5
        [HttpPost]
        public ActionResult Edit(PizzaCreateViewModel vm)
        {
            try
            {
                Pizza pizza = FakeDb.Instance.Pizzas.FirstOrDefault(x => x.Id == vm.Pizza.Id);
                pizza.Nom = vm.Pizza.Nom;
                pizza.Pate = FakeDb.Instance.Pates.FirstOrDefault(x => x.Id == vm.IdPate);
                pizza.Ingredients = FakeDb.Instance.Ingredients.Where(x => vm.IdsIngredients.Contains(x.Id)).ToList();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pizza/Delete/5
        public ActionResult Delete(int id)
        {

            PizzaCreateViewModel vm = new PizzaCreateViewModel();
            vm.Pizza = FakeDb.Instance.Pizzas.FirstOrDefault(x => x.Id == id);

            return View(vm);
        }

        // POST: Pizza/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Pizza pizza = FakeDb.Instance.Pizzas.FirstOrDefault(x => x.Id == id);
                FakeDb.Instance.Pizzas.Remove(pizza);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

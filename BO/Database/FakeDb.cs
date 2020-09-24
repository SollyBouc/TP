using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TPPiz.Database
{
    public class FakeDb
    {

        private static readonly Lazy<FakeDb> lazy =
            new Lazy<FakeDb>(() => new FakeDb());

        /// <summary>
        /// FakeDb singleton access.
        /// </summary>
        public static FakeDb Instance { get { return lazy.Value; } }

       

        private FakeDb()
        {
            this.Ingredients = new List<Ingredient>();
            this.Pates = new List<Pate>();
            this.Pizzas = new List<Pizza>();
            

            Ingredients = IngredientsDisponibles();
            Pates = PatesDisponibles();
            
        }


        public List<Ingredient> Ingredients { get; private set; }
        public List<Pate> Pates { get; private set; }
        public List<Pizza> Pizzas { get; private set; }

        public static List<Ingredient> IngredientsDisponibles() 
        {
            return new List<Ingredient>
            { 
            new Ingredient{Id=1,Nom="Mozzarella"},
            new Ingredient{Id=2,Nom="Jambon"},
            new Ingredient{Id=3,Nom="Tomate"},
            new Ingredient{Id=4,Nom="Oignon"},
            new Ingredient{Id=5,Nom="Cheddar"},
            new Ingredient{Id=6,Nom="Saumon"},
            new Ingredient{Id=7,Nom="Champignon"},
            new Ingredient{Id=8,Nom="Poulet"}
            };
        }

        public static List<Pate> PatesDisponibles()
        {
            return new List<Pate>
            {
            new Pate{ Id=1,Nom="Pate fine, base crême"},
            new Pate{ Id=2,Nom="Pate fine, base tomate"},
            new Pate{ Id=3,Nom="Pate épaisse, base crême"},
            new Pate{ Id=4,Nom="Pate épaisse, base tomate"}
            };
        }

        
    }
}
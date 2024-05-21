using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRKI
{
    using System;
    using System.Collections.Generic;

    public class Meal
    {
        public string MainCourse { get; set; }
        public string SideDish { get; set; }
        public string Drink { get; set; }
        public List<string> Extras { get; set; } = new List<string>();

        public override string ToString()
        {
            return $"MainCourse: {MainCourse}, SideDish: {SideDish}, Drink: {Drink}, Extras: {string.Join(", ", Extras)}";
        }
    }

    public interface IMealBuilder
    {
        void SetMainCourse();
        void SetSideDish();
        void SetDrink();
        void AddExtras();
        Meal GetMeal();
    }

    public class StandardMealBuilder : IMealBuilder
    {
        private Meal _meal = new Meal();

        public void SetMainCourse()
        {
            _meal.MainCourse = "Chicken";
        }

        public void SetSideDish()
        {
            _meal.SideDish = "Rice";
        }

        public void SetDrink()
        {
            _meal.Drink = "Water";
        }

        public void AddExtras()
        {
            // No extras for standard meal
        }

        public Meal GetMeal()
        {
            return _meal;
        }
    }

    public class CustomMealBuilder : IMealBuilder
    {
        private Meal _meal = new Meal();

        public void SetMainCourse()
        {
            _meal.MainCourse = "Steak";
        }

        public void SetSideDish()
        {
            _meal.SideDish = "Potatoes";
        }

        public void SetDrink()
        {
            _meal.Drink = "Wine";
        }

        public void AddExtras()
        {
            _meal.Extras.Add("Salad");
            _meal.Extras.Add("Dessert");
        }

        public Meal GetMeal()
        {
            return _meal;
        }
    }

    public class MealDirector
    {
        public void Construct(IMealBuilder mealBuilder)
        {
            mealBuilder.SetMainCourse();
            mealBuilder.SetSideDish();
            mealBuilder.SetDrink();
            mealBuilder.AddExtras();
        }
    }
}

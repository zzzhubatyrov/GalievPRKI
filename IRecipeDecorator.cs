using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRKI
{
    public interface IRecipe
    {
        void PrintInfo();
    }

    public class Recipe : IRecipe
    {
        private string _doctor;
        private DateTime _expirationDate;

        public Recipe(string doctor, DateTime expirationDate)
        {
            _doctor = doctor;
            _expirationDate = expirationDate;
        }

        public void PrintInfo()
        {
            Console.WriteLine($"Doctor: {_doctor}, Expiration Date: {_expirationDate}");
        }
    }

    public class RecipeExpirationDateDecorator : IRecipe
    {
        private IRecipe _recipe;
        private DateTime _newExpirationDate;

        public RecipeExpirationDateDecorator(IRecipe recipe, DateTime newExpirationDate)
        {
            _recipe = recipe;
            _newExpirationDate = newExpirationDate;
        }

        public void PrintInfo()
        {
            _recipe.PrintInfo();
            Console.WriteLine($"New Expiration Date: {_newExpirationDate}");
        }
    }
}

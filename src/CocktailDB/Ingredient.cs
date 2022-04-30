using System.Collections.Generic;

namespace CocktailDB
{
    public class Ingredient
    {
        public string idIngredient;
        public string strIngredient;
        public string strDescription;
        public string strType;
        public string strAlcohol;
        public string strABV;
    }

    class Ingredients
    {
        public List<Ingredient> ingredients;
    }
}
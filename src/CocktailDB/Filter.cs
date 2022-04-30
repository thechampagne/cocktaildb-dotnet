using System.Collections.Generic;

namespace CocktailDB
{
    public class Filter
    {
        public string strDrink;
        public string strDrinkThumb;
        public string idDrink;
    }
    
    class FilterDrinks
    {
        public List<Filter> drinks;
    }
}
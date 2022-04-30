using System.Collections.Generic;
using Newtonsoft.Json;

namespace CocktailDB
{
    public class Cocktail
    {
        public string idDrink;
        public string strDrink;
        public string strDrinkAlternate;
        public string strTags;
        public string strVideo;
        public string strCategory;
        public string strIBA;
        public string strAlcoholic;
        public string strGlass;
        public string strInstructions;
        public string strInstructionsES;
        public string strInstructionsDE;
        public string strInstructionsFR;
        public string strInstructionsIT;
        [JsonProperty("strInstructionsZH-HANS")]
        public string StrInstructionsZHHANS;
        [JsonProperty("strInstructionsZH-HANT")]
        public string StrInstructionsZHHANT;
        public string strDrinkThumb;
        public string strIngredient1;
        public string strIngredient2;
        public string strIngredient3;
        public string strIngredient4;
        public string strIngredient5;
        public string strIngredient6;
        public string strIngredient7;
        public string strIngredient8;
        public string strIngredient9;
        public string strIngredient10;
        public string strIngredient11;
        public string strIngredient12;
        public string strIngredient13;
        public string strIngredient14;
        public string strIngredient15;
        public string strMeasure1;
        public string strMeasure2;
        public string strMeasure3;
        public string strMeasure4;
        public string strMeasure5;
        public string strMeasure6;
        public string strMeasure7;
        public string strMeasure8;
        public string strMeasure9;
        public string strMeasure10;
        public string strMeasure11;
        public string strMeasure12;
        public string strMeasure13;
        public string strMeasure14;
        public string strMeasure15;
        public string strImageSource;
        public string strImageAttribution;
        public string strCreativeCommonsConfirmed;
        public string dateModified;
    }

    class Cocktails
    {
        public List<Cocktail> drinks;
    }
}
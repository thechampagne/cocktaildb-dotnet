using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace CocktailDB
{
    /// <summary>
    /// TheCocktailDB API client
    /// <br/>
    /// An open, crowd-sourced database of drinks
    /// and cocktails from around the world.
    /// </summary>
    public class CocktailAPI
    {
        private static string Http(string endpoint)
        {
            try
            {
                HttpWebRequest client = (HttpWebRequest) WebRequest.Create($"https://thecocktaildb.com/api/json/v1/1/{endpoint}");
                client.Method = "GET";
                var webResponse = client.GetResponse();
                var webStream = webResponse.GetResponseStream();
                var responseReader = new StreamReader(webStream);
                var response = responseReader.ReadToEnd();
                responseReader.Close();
                responseReader.Dispose();
                return response;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Search cocktail by name.
        /// </summary>
        /// <param name="s">Cocktail name.</param>
        /// <returns>List of <see cref="Cocktail"/></returns>
        public static List<Cocktail> Search(string s)
        {
            try
            {
                var response = Http($"search.php?s={Uri.EscapeDataString(s)}");
                if (response != null && response.Length != 0)
                {
                    Cocktails cocktails = JsonConvert.DeserializeObject<Cocktails>(response);
                    if (cocktails.drinks != null && cocktails.drinks.Count != 0)
                    {
                        List<Cocktail> list = new List<Cocktail>();
                        foreach (var c in cocktails.drinks)
                        {
                            list.Add(c);
                        }
                        if (list.Count == 0)
                        {
                            return null;
                        }
                        else
                        {
                            return list;
                        }
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        
        /// <summary>
        /// Search cocktails by first letter.
        /// </summary>
        /// <param name="c">Cocktails letter.</param>
        /// <returns>List of <see cref="Cocktail"/></returns>
        public static List<Cocktail> SearchByLetter(char c)
        {
            try
            {
                var response = Http($"search.php?f={c}");
                if (response != null && response.Length != 0)
                {
                    Cocktails cocktails = JsonConvert.DeserializeObject<Cocktails>(response);
                    if (cocktails.drinks != null && cocktails.drinks.Count != 0)
                    {
                        List<Cocktail> list = new List<Cocktail>();
                        foreach (var i in cocktails.drinks)
                        {
                            list.Add(i);
                        }
                        if (list.Count == 0)
                        {
                            return null;
                        }
                        else
                        {
                            return list;
                        }
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        
        /// <summary>
        /// Search ingredient by name.
        /// </summary>
        /// <param name="s">Ingredient name.</param>
        /// <returns><see cref="Ingredient"/></returns>
        public static Ingredient SearchIngredient(string s)
        {
            try
            {
                var response = Http($"search.php?i={Uri.EscapeDataString(s)}");
                if (response != null && response.Length != 0)
                {
                    Ingredients cocktails = JsonConvert.DeserializeObject<Ingredients>(response);
                    if (cocktails.ingredients != null && cocktails.ingredients.Count != 0)
                    {
                        return cocktails.ingredients[0];
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        
        /// <summary>
        /// Search cocktail details by id.
        /// </summary>
        /// <param name="l">Cocktail id.</param>
        /// <returns><see cref="Cocktail"/></returns>
        public static Cocktail SearchByID(long l)
        {
            try
            {
                var response = Http($"lookup.php?i={l}");
                if (response != null && response.Length != 0)
                {
                    Cocktails cocktails = JsonConvert.DeserializeObject<Cocktails>(response);
                    if (cocktails.drinks != null && cocktails.drinks.Count != 0)
                    {
                        return cocktails.drinks[0];
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        
        /// <summary>
        /// Search ingredient by ID.
        /// </summary>
        /// <param name="l">Ingredient ID.</param>
        /// <returns><see cref="Ingredient"/></returns>
        public static Ingredient SearchIngredientByID(long l)
        {
            try
            {
                var response = Http($"lookup.php?iid={l}");
                if (response != null && response.Length != 0)
                {
                    Ingredients cocktails = JsonConvert.DeserializeObject<Ingredients>(response);
                    if (cocktails.ingredients != null && cocktails.ingredients.Count != 0)
                    {
                        return cocktails.ingredients[0];
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        
        /// <summary>
        /// Search a random cocktail.
        /// </summary>
        /// <returns><see cref="Cocktail"/></returns>
        public static Cocktail Random()
        {
            try
            {
                var response = Http("random.php");
                if (response != null && response.Length != 0)
                {
                    Cocktails cocktails = JsonConvert.DeserializeObject<Cocktails>(response);
                    if (cocktails.drinks != null && cocktails.drinks.Count != 0)
                    {
                        return cocktails.drinks[0];
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        
        /// <summary>
        /// Filter by ingredient.
        /// </summary>
        /// <param name="s">Ingredient name.</param>
        /// <returns>List of <see cref="Filter"/></returns>
        public static List<Filter> FilterByIngredient(string s)
        {
            try
            {
                var response = Http($"filter.php?i={Uri.EscapeDataString(s)}");
                if (response != null && response.Length != 0)
                {
                    FilterDrinks cocktails = JsonConvert.DeserializeObject<FilterDrinks>(response);
                    if (cocktails.drinks != null && cocktails.drinks.Count != 0)
                    {
                        List<Filter> list = new List<Filter>();
                        foreach (var c in cocktails.drinks)
                        {
                            list.Add(c);
                        }
                        if (list.Count == 0)
                        {
                            return null;
                        }
                        else
                        {
                            return list;
                        }
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        
        /// <summary>
        /// Filter by Alcoholic.
        /// </summary>
        /// <param name="s">Alcoholic name.</param>
        /// <returns>List of <see cref="Filter"/></returns>
        public static List<Filter> FilterByAlcoholic(string s)
        {
            try
            {
                var response = Http($"filter.php?a={Uri.EscapeDataString(s)}");
                if (response != null && response.Length != 0)
                {
                    FilterDrinks cocktails = JsonConvert.DeserializeObject<FilterDrinks>(response);
                    if (cocktails.drinks != null && cocktails.drinks.Count != 0)
                    {
                        List<Filter> list = new List<Filter>();
                        foreach (var c in cocktails.drinks)
                        {
                            list.Add(c);
                        }
                        if (list.Count == 0)
                        {
                            return null;
                        }
                        else
                        {
                            return list;
                        }
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        
        /// <summary>
        /// Filter by Category.
        /// </summary>
        /// <param name="s">Category name.</param>
        /// <returns>List of <see cref="Filter"/></returns>
        public static List<Filter> FilterByCategory(string s)
        {
            try
            {
                var response = Http($"filter.php?c={Uri.EscapeDataString(s)}");
                if (response != null && response.Length != 0)
                {
                    FilterDrinks cocktails = JsonConvert.DeserializeObject<FilterDrinks>(response);
                    if (cocktails.drinks != null && cocktails.drinks.Count != 0)
                    {
                        List<Filter> list = new List<Filter>();
                        foreach (var c in cocktails.drinks)
                        {
                            list.Add(c);
                        }
                        if (list.Count == 0)
                        {
                            return null;
                        }
                        else
                        {
                            return list;
                        }
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        
        /// <summary>
        /// Filter by Glass.
        /// </summary>
        /// <param name="s">Glass name.</param>
        /// <returns>List of <see cref="Filter"/></returns>
        public static List<Filter> FilterByGlass(string s)
        {
            try
            {
                var response = Http($"filter.php?g={Uri.EscapeDataString(s)}");
                if (response != null && response.Length != 0)
                {
                    FilterDrinks cocktails = JsonConvert.DeserializeObject<FilterDrinks>(response);
                    if (cocktails.drinks != null && cocktails.drinks.Count != 0)
                    {
                        List<Filter> list = new List<Filter>();
                        foreach (var c in cocktails.drinks)
                        {
                            list.Add(c);
                        }
                        if (list.Count == 0)
                        {
                            return null;
                        }
                        else
                        {
                            return list;
                        }
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        
        /// <summary>
        /// List the categories filter.
        /// </summary>
        /// <returns>List of <see cref="string"/></returns>
        public static List<string> CategoriesFilter()
        {
            try
            {
                var response = Http("list.php?c=list");
                if (response != null && response.Length != 0)
                {
                    CategoriesFilter cocktails = JsonConvert.DeserializeObject<CategoriesFilter>(response);
                    if (cocktails.drinks != null && cocktails.drinks.Count != 0)
                    {
                        List<string> list = new List<string>();
                        foreach (var c in cocktails.drinks)
                        {
                            list.Add(c.strCategory);
                        }
                        if (list.Count == 0)
                        {
                            return null;
                        }
                        else
                        {
                            return list;
                        }
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        
        /// <summary>
        /// List the glasses filter.
        /// </summary>
        /// <returns>List of <see cref="string"/></returns>
        public static List<string> GlassesFilter()
        {
            try
            {
                var response = Http("list.php?g=list");
                if (response != null && response.Length != 0)
                {
                    GlassesFilter cocktails = JsonConvert.DeserializeObject<GlassesFilter>(response);
                    if (cocktails.drinks != null && cocktails.drinks.Count != 0)
                    {
                        List<string> list = new List<string>();
                        foreach (var c in cocktails.drinks)
                        {
                            list.Add(c.strGlass);
                        }
                        if (list.Count == 0)
                        {
                            return null;
                        }
                        else
                        {
                            return list;
                        }
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        
        /// <summary>
        /// List the ingredients filter.
        /// </summary>
        /// <returns>List of <see cref="string"/></returns>
        public static List<string> IngredientsFilter()
        {
            try
            {
                var response = Http("list.php?i=list");
                if (response != null && response.Length != 0)
                {
                    IngredientsFilter cocktails = JsonConvert.DeserializeObject<IngredientsFilter>(response);
                    if (cocktails.drinks != null && cocktails.drinks.Count != 0)
                    {
                        List<string> list = new List<string>();
                        foreach (var c in cocktails.drinks)
                        {
                            list.Add(c.strIngredient1);
                        }
                        if (list.Count == 0)
                        {
                            return null;
                        }
                        else
                        {
                            return list;
                        }
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        
        /// <summary>
        /// List the alcoholic filter.
        /// </summary>
        /// <returns>List of <see cref="string"/></returns>
        public static List<string> AlcoholicFilter()
        {
            try
            {
                var response = Http("list.php?a=list");
                if (response != null && response.Length != 0)
                {
                    AlcoholicFilter cocktails = JsonConvert.DeserializeObject<AlcoholicFilter>(response);
                    if (cocktails.drinks != null && cocktails.drinks.Count != 0)
                    {
                        List<string> list = new List<string>();
                        foreach (var c in cocktails.drinks)
                        {
                            list.Add(c.strAlcoholic);
                        }
                        if (list.Count == 0)
                        {
                            return null;
                        }
                        else
                        {
                            return list;
                        }
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
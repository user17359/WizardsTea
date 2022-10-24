using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckRecipe : MonoBehaviour
{
    Dictionary<string, string> translation;
    public CurrentRecipe currentRecipe;
    public RecipeDisplay recipeDisplay;
    public GetJsonSprites jsonSprites;

    void Awake()
    {
        //loading json file
        var textFile = Resources.Load<TextAsset>("Recipes");
        //loading json file as a dictionary to easily convert names into paths
        translation = JsonConvert.DeserializeObject<Dictionary<string, string>>(textFile.text);
    }

    //Translating item name into its sprite

    public string Check()
    {
        string result = "";
        string recipe = currentRecipe.GetRecipe();
        if (translation.ContainsKey(recipe))
        {
            result = translation[recipe];
            recipeDisplay.AddResult(jsonSprites.GetSprite(result));
            currentRecipe.ClearIngridients();
        }
        return result;
    }
}

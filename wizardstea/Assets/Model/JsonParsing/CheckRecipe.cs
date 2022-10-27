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
    public GetResult getResult;

    void Awake()
    {
        //loading json file
        var textFile = Resources.Load<TextAsset>("Recipes");
        //loading json file as a dictionary to easily check recipes
        translation = JsonConvert.DeserializeObject<Dictionary<string, string>>(textFile.text);
    }


    public bool Check(string recipe)
    {
        if (translation.ContainsKey(recipe))
        {
            return true;
        }
        return false;
    }

    public string ProcessRecipe()
    {
        string result = "";
        string recipe = currentRecipe.GetRecipe();
        if (Check(recipe))
        {
            result = translation[recipe];
            recipeDisplay.AddResult(jsonSprites.GetSprite(result), result);
            currentRecipe.ClearIngridients(true);
            getResult.SetResult(result);
        }
        return result;
    }
}

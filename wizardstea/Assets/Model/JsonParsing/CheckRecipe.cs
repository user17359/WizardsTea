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
    public Recipebook recipebook;

    void Awake()
    {
        //loading json file
        var textFile = Resources.Load<TextAsset>("Recipes");
        //loading json file as a dictionary to easily check recipes
        translation = JsonConvert.DeserializeObject<Dictionary<string, string>>(textFile.text);
    }

    private void Start()
    {
        //resizing scrolling view to fit all recipes
        recipebook.SetContentHeight(translation.Count);

        //displaying all recipes
        foreach (var item in translation)
        {
            string[] recipe = SeparateIngridients(item.Key);
            Sprite[] recipeSprites = new Sprite[recipe.Length];

            for(int i = 0; i < recipe.Length; i++)
            {
                recipeSprites[i] = jsonSprites.GetSprite(recipe[i]);
            }

            Sprite resultSprite = jsonSprites.GetSprite(item.Value);

            recipebook.AddRecipe(recipe, recipeSprites, item.Value, resultSprite);
        }
    }

    private string[] SeparateIngridients(string recipe)
    {
        string[] result = recipe.Split('-');
        return result;
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

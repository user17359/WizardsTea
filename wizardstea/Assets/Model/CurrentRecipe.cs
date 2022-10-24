using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentRecipe : MonoBehaviour
{
    public string[] recipe;
    public RecipeDisplay recipeDisplay;
    public GetJsonSprites jsonSprites;

    public string GetRecipe()
    {
        string key = "";
        for(int i = 0; i < recipe.Length; i++)
        {
            if(i != recipe.Length - 1)
            {
                key += (recipe[i] + "-");
            }
            else
            {
                key += recipe[i];
            }
        }
        return key;
    }

    public void AddIngredient(int position, string ID)
    {
        recipe[position] = ID;
        recipeDisplay.AddIngredient(position, jsonSprites.GetSprite(ID));
    }

    public void RemoveIngridient(int position)
    {
        recipe[position] = "";
        recipeDisplay.RemoveIngridient(position);
    }

    public void ClearIngridients()
    {
        for (int i = 0; i < recipe.Length; i++)
        {
            RemoveIngridient(i);
        }
    }
    public int CheckFreePos()
    {
        for(int i = 0; i < recipe.Length; i++)
        {
            if (recipe[i] == "")
            {
                return i;
            }
        }
        //-1 means that there is no free position
        return -1;
    }
}

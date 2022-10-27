using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentRecipe : MonoBehaviour
{
    private static int _recipeLenght = 3;
    public string[] recipe = new string[_recipeLenght];
    public ItemCategories[] itemCategory = new ItemCategories[_recipeLenght];
    public RecipeDisplay recipeDisplay;
    public GetJsonSprites jsonSprites;
    public Inventory inventory;
    public CombineIngridients combineIngridients;
    public Clear clear;
    public CheckRecipe checkRecipe;
    public KettleAnimation kettleAnimation;

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

    public void AddIngredient(int position, string ID, ItemCategories itemCategory)
    {
        inventory.RemoveItemQuantity(1, ID, itemCategory);
        this.itemCategory[position] = itemCategory;
        recipe[position] = ID;
        recipeDisplay.AddIngredient(position, jsonSprites.GetSprite(ID), ID);
        kettleAnimation.ChangeKettle(CheckOcupation());
        //if recipe is full we activate the brewing options
        if(position == _recipeLenght - 1)
        {
            bool isValid = checkRecipe.Check(GetRecipe());
            if (isValid)
            {
                combineIngridients.SetActive(true);
            }
        }
        //if recipe is not empty we activate the clear option
        else if (position == 0)
        {
            clear.SetActive(true);
        }
    }

    public void RemoveIngridient(int position, bool consumed)
    {
        if (!consumed) 
        {
            inventory.AddItemQuantity(1, recipe[position], itemCategory[position]);
        }
        recipe[position] = "";
        recipeDisplay.RemoveIngridient(position);
        kettleAnimation.ChangeKettle(CheckOcupation());
        //if recipe is not full we deactivate the brewing options
        if (position == _recipeLenght - 1)
        {
            combineIngridients.SetActive(false);
        }
        //if recipe is empty we deactivate the clear option
        else if (position == 0)
        {
            clear.SetActive(false);
        }
    }

    public void ClearIngridients(bool consumed)
    {
        for (int i = 0; i < recipe.Length; i++)
        {
            RemoveIngridient(i, consumed);
        }
    }

    public int CheckOcupation()
    {
        int occupied = 0;
        for (int i = 0; i < recipe.Length; i++)
        {
            if (recipe[i] != "")
            {
                occupied++;
            }
        }
        return occupied;
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

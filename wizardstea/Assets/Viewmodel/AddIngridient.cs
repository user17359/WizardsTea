using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddIngridient : MonoBehaviour
{
    public string ID;
    private CurrentRecipe _currentRecipe;
    public ItemCategories itemCategory;

    private void Start()
    {
        _currentRecipe = GameObject.FindGameObjectWithTag("RecipeHandler").GetComponent<CurrentRecipe>();
    }

    public void Add()
    {
        int position = _currentRecipe.CheckFreePos();
        if(position == -1)
        {
            //on decline
        }
        else
        {
            _currentRecipe.AddIngredient(position, ID, itemCategory);
        }
    }
}

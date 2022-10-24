using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombineIngridients : MonoBehaviour
{
    private CheckRecipe _checkRecipe;

    private void Start()
    {
        _checkRecipe = GameObject.FindGameObjectWithTag("RecipeHandler").GetComponent<CheckRecipe>();
    }

    public void Combine()
    {
        Debug.Log(_checkRecipe.Check());
    }
}

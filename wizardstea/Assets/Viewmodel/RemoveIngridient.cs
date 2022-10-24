using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveIngridient : MonoBehaviour
{
    public int position;
    private CurrentRecipe _currentRecipe;

    private void Start()
    {
        _currentRecipe = GameObject.FindGameObjectWithTag("RecipeHandler").GetComponent<CurrentRecipe>();
    }

    public void Remove()
    {
        _currentRecipe.RemoveIngridient(position);
    }
}

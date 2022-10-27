using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombineIngridients : MonoBehaviour
{
    private CheckRecipe _checkRecipe;

    private Button button;

    private void Start()
    {
        _checkRecipe = GameObject.FindGameObjectWithTag("RecipeHandler").GetComponent<CheckRecipe>();
        button = GetComponent<Button>();
    }

    public void SetActive(bool active)
    {
        button.interactable = active;
    }
    public void Combine()
    {
        _checkRecipe.ProcessRecipe();
    }
}

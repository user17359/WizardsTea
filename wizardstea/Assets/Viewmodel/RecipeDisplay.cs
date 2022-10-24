using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipeDisplay : MonoBehaviour
{
    public Button[] recipeButtons;
    public Button resultButton;

    public void AddIngredient(int position, Sprite sprite)
    {
        recipeButtons[position].image.sprite = sprite;
        recipeButtons[position].interactable = true;
    }

    public void RemoveIngridient(int position)
    {
        recipeButtons[position].image.sprite = null;
        recipeButtons[position].interactable = false;
    }

    public void AddResult(Sprite sprite)
    {
        resultButton.image.sprite = sprite;
        resultButton.interactable = true;
    }

    public void RemoveResult()
    {
        resultButton.image.sprite = null;
        resultButton.interactable = false;
    }
}

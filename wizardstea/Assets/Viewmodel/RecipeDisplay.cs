using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipeDisplay : MonoBehaviour
{
    public Button[] recipeButtons;
    public Image[] recipeImages;
    public TooltipDisplay[] recipeTooltips;
    public Button resultButton;
    public Image resultImage;
    public TooltipDisplay resultTooltip;
    public Sprite empty;

    public void AddIngredient(int position, Sprite sprite, string ID)
    {
        recipeImages[position].sprite = sprite;
        recipeButtons[position].interactable = true;
        recipeTooltips[position].display = ID;
    }

    public void RemoveIngridient(int position)
    {
        recipeImages[position].sprite = empty;
        recipeButtons[position].interactable = false;
        recipeTooltips[position].display = "";
    }

    public void AddResult(Sprite sprite, string ID)
    {
        resultImage.sprite = sprite;
        resultButton.interactable = true;
        resultTooltip.display = ID;
    }

    public void RemoveResult()
    {
        resultImage.sprite = empty;
        resultButton.interactable = false;
        resultTooltip.display = "";
        resultTooltip.OnPointerExit(null);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SingleRecipe : MonoBehaviour
{
    public Image[] images;
    public TooltipDisplay[] tooltipDisplays;

    //0,1,2 is ingridients, 3 is result
    public void UpdateRecipe(string[] recipeIDs, Sprite[] recipeSprites, string resultIDs, Sprite resultSprite)
    {
        for(int i = 0; i < images.Length; i++)
        {
            if (i != images.Length - 1) 
            {
                images[i].sprite = recipeSprites[i];
                tooltipDisplays[i].display = recipeIDs[i];
            }
            else
            {
                images[i].sprite = resultSprite;
                tooltipDisplays[i].display = resultIDs;
            }
        }
    }
}

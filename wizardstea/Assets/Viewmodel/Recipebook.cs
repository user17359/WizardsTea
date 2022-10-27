using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recipebook : MonoBehaviour
{
    public int verticalSize;
    public GameObject recipe;
    public Transform view;
    public RectTransform content;
    private float sizeCoef;
    public RectTransform canvas;

    public void SetContentHeight(int quantity)
    {
        sizeCoef = canvas.localScale.x;
        int height = verticalSize * quantity;
        content.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height);
    }

    public void AddRecipe(string[] recipeIDs, Sprite[] recipeSprites, string resultIDs, Sprite resultSprite)
    {
        GameObject spawned = Instantiate(recipe, transform.position, Quaternion.identity);
        spawned.GetComponent<RectTransform>().SetParent(view);
        spawned.GetComponent<RectTransform>().localScale = Vector3.one;
        spawned.GetComponent<SingleRecipe>().UpdateRecipe(recipeIDs, recipeSprites, resultIDs, resultSprite);
        transform.Translate(new Vector2(0, -verticalSize * sizeCoef));
    }
}

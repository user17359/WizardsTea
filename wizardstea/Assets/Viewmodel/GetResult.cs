using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetResult : MonoBehaviour
{
    public Inventory inventory;
    public RecipeDisplay recipeDisplay;
    private string ID = "";

    public void RetriveResult()
    {
        if (ID != "")
        {
            inventory.AddItemQuantity(1, ID);
            recipeDisplay.RemoveResult();
            ID = "";
        }
    }

    public void SetResult(string ID)
    {
        this.ID = ID;
    }
}

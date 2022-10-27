using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StackButton : MonoBehaviour
{
    public string ID;
    private AddIngridient _addIngridient;
    private TooltipDisplay _tooltipDisplay;
    public TMP_Text quantityText;
    public Button button;
    public Image itemDisplay;
    public Sprite empty;

    void Start()
    {
        _addIngridient = GetComponent<AddIngridient>();
        _tooltipDisplay = GetComponent<TooltipDisplay>();
        _addIngridient.ID = ID;
    }

    public void UpdateButton(string quantity, string ID, Sprite sprite, ItemCategories itemCategory)
    {
        button.interactable = true;
        _addIngridient.itemCategory = itemCategory;
        _addIngridient.ID = ID;
        _tooltipDisplay.display = ID;
        quantityText.text = quantity;
        if (sprite != null) {
            itemDisplay.sprite = sprite;
        }
    }

    public void UpdateButton(string quantity)
    {
        quantityText.text = quantity;
    }

    public void ClearButton()
    {
        button.interactable = false;
        _addIngridient.ID = "";
        _tooltipDisplay.display = "";
        quantityText.text = "";
        itemDisplay.sprite = empty;
    }
}

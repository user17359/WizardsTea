using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CategoryDisplay : MonoBehaviour
{
    public GameObject itemStackButton;
    public Vector2 buttonDistance;
    public int collumns = 4;
    public int rows = 3;
    public StackButton[] stackButtons;
    public Sprite defaultSprite;

    private void Awake()
    {
        stackButtons = new StackButton[collumns * rows];
        Vector2 spawnCord = transform.position;
        for(int x = 0; x < rows; x++)
        {
            for(int y = 0; y < collumns; y++)
            {
                GameObject newInstance = Instantiate(itemStackButton, spawnCord, Quaternion.identity, transform);
                stackButtons[x*collumns + y] = newInstance.GetComponent<StackButton>();
                
                spawnCord += new Vector2(buttonDistance.x, 0);
            }
            //we move spawn point to start of new row
            spawnCord +=  new Vector2(buttonDistance.x * -collumns, buttonDistance.y);
        }
    }

    public void AddItem(string ID, int quantity, Sprite sprite, int position, ItemCategories category)
    {
        stackButtons[position].UpdateButton(quantity.ToString(), ID, sprite, category);
    }

    public void ChangeQuantity(int newQuantity, int position)
    {
        stackButtons[position].UpdateButton(newQuantity.ToString());
    }

    public void RemoveItem(int position)
    {
        stackButtons[position].ClearButton();
    }
}

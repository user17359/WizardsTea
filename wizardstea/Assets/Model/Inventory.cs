using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemCategories
{
    BASIC_TEA = 0,
    MAGICAL_INGRIDIENTS = 1,
    BREWS = 2
}

public class ItemStack
{
    private int quantity;
    private string id;
    private ItemCategories itemCategories;

    public ItemStack(int quantity, string id, ItemCategories itemCategories)
    {
        this.quantity = quantity;
        this.id = id;
        this.itemCategories = itemCategories;
    }

    public int Quantity { get => quantity; set => quantity = value; }
    public string Id { get => id; set => id = value; }
    public ItemCategories ItemCategories { get => itemCategories; set => itemCategories = value; }
}


public class Inventory : MonoBehaviour
{
    //temporary solution to set starting items
    public int[] startQuantities;
    public string[] startIDs;
    public ItemCategories[] startItemCategories;


    private static int _numberOfCategories = 3;
    List<ItemStack>[] inventory = new List<ItemStack>[_numberOfCategories];

    //link between inventory logic and displaying
    public CategoryDisplay[] categoryDisplays = new CategoryDisplay[_numberOfCategories];

    public GetJsonSprites jsonSprites;

    private void Awake()
    {
        //initializing inventory
        for(int i = 0; i < inventory.Length; i++)
        {
            inventory[i] = new List<ItemStack>();
        }
    }

    private void Start()
    {
        //adding starting items
        for (int i = 0; i < startQuantities.Length; i++)
        {
            AddItemQuantity(startQuantities[i], startIDs[i], startItemCategories[i]);
        }
    }

    public void AddItemQuantity(int quantity, string ID, ItemCategories itemCategories = ItemCategories.BREWS)
    {
        //firstly we search if item stack with given ID already exists
        ItemStack itemStack = inventory[(int)itemCategories].Find(r => r.Id == ID);
        int position = inventory[(int)itemCategories].IndexOf(itemStack);
        if (itemStack == null)
        {
            //if no we search if there is any empty space left after depleting another item
            ItemStack empty = inventory[(int)itemCategories].Find(r => r.Id == "");
            if (empty != null)
            {
                //if empty space exists we create our item there
                position = inventory[(int)itemCategories].IndexOf(empty);
                inventory[(int)itemCategories][position] = new ItemStack(quantity, ID, itemCategories);
                categoryDisplays[(int)itemCategories].AddItem(ID, quantity, jsonSprites.GetSprite(ID), position, itemCategories);
            }
            else 
            {
                //if theres neither an empty space nor existing item stack we create our item at the end of the list
                inventory[(int)itemCategories].Add(new ItemStack(quantity, ID, itemCategories));
                categoryDisplays[(int)itemCategories].AddItem(ID, quantity, jsonSprites.GetSprite(ID), inventory[(int)itemCategories].Count - 1, itemCategories);
            }
        }
        else
        {
            //if item stack exists we just change quantity in that stack
            itemStack.Quantity += quantity;
            categoryDisplays[(int)itemCategories].ChangeQuantity(itemStack.Quantity, position);
        }
    }

    public void RemoveItemQuantity(int quantity, string ID, ItemCategories itemCategories = ItemCategories.BREWS)
    {
        ItemStack itemStack = inventory[(int)itemCategories].Find(r => r.Id == ID);
        int position = inventory[(int)itemCategories].IndexOf(itemStack);

        if (itemStack.Quantity <= quantity)
        {
            //if quantity of item is equal or below zero we create empty space to be filled by AddItemQuantity
            inventory[(int)itemCategories][position] = new ItemStack(0, "", itemCategories);
            categoryDisplays[(int)itemCategories].RemoveItem(position);
        }
        else
        {
            //if quantity is larger than zero we just change quantity in that stack
            itemStack.Quantity -= quantity;
            categoryDisplays[(int)itemCategories].ChangeQuantity(itemStack.Quantity, position);
        }
    }
}

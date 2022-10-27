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

    public int[] startQuantities;
    public string[] startIDs;
    public ItemCategories[] startItemCategories;

    private static int _numberOfCategories = 3;
    List<ItemStack>[] inventory = new List<ItemStack>[_numberOfCategories];
    public CategoryDisplay[] categoryDisplays = new CategoryDisplay[_numberOfCategories];

    public GetJsonSprites jsonSprites;

    private void Awake()
    {
        for(int i = 0; i < inventory.Length; i++)
        {
            inventory[i] = new List<ItemStack>();
        }
    }

    private void Start()
    {
        for (int i = 0; i < startQuantities.Length; i++)
        {
            AddItemQuantity(startQuantities[i], startIDs[i], startItemCategories[i]);
        }
    }

    public void AddItemQuantity(int quantity, string ID, ItemCategories itemCategories = ItemCategories.BREWS)
    {
        ItemStack itemStack = inventory[(int)itemCategories].Find(r => r.Id == ID);
        int position = inventory[(int)itemCategories].IndexOf(itemStack);
        if (itemStack == null)
        {
            ItemStack empty = inventory[(int)itemCategories].Find(r => r.Id == "");
            if (empty != null)
            {
                position = inventory[(int)itemCategories].IndexOf(empty);
                inventory[(int)itemCategories][position] = new ItemStack(quantity, ID, itemCategories);
                Debug.Log(position);
                categoryDisplays[(int)itemCategories].AddItem(ID, quantity, jsonSprites.GetSprite(ID), position, itemCategories);
            }
            else 
            {
                inventory[(int)itemCategories].Add(new ItemStack(quantity, ID, itemCategories));
                categoryDisplays[(int)itemCategories].AddItem(ID, quantity, jsonSprites.GetSprite(ID), inventory[(int)itemCategories].Count - 1, itemCategories);
            }
        }
        else
        {
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
            inventory[(int)itemCategories][position] = new ItemStack(0, "", itemCategories);
            categoryDisplays[(int)itemCategories].RemoveItem(position);
        }
        else
        {
            itemStack.Quantity -= quantity;
            categoryDisplays[(int)itemCategories].ChangeQuantity(itemStack.Quantity, position);
        }
    }
}

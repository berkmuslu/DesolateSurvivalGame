using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class Item : MonoBehaviour
{
    public GameObject player;
    public int ID;
    public string name;
    public int amount;
    public Sprite itemImage;
    public bool canStacked;

    private void Start()
    {
        player = GameObject.Find("Character");
    }
    
    /*
    public Item(string name)
    {
        this.name = name;
        itemImage = Resources.Load<Sprite>("/Inventory/Items/" + name); //took it from internet but it's not working
    }
    */
    
    public Item(string name, Sprite itemImage)
    {
        this.name = name;
        this.itemImage = itemImage;
    }
    
    public Item()
    {
        this.name = "";
    }

    public void AddItem()
    {
        
        if(player.GetComponent<InventorySystem>().inventory.Count +1 != 21){
        player.GetComponent<InventorySystem>().AddItem(this, itemImage);
        }

    }
    
}

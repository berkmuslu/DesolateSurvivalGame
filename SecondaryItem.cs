using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondaryItem : Item
{
    
    private void Start()
    {
        player = GameObject.Find("Character");
    }
    
    
    public SecondaryItem()
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

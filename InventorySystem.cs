using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;


public class InventorySystem : MonoBehaviour
{
    public List<Item> inventory = new List<Item>();
    public Button[] slots = new Button[20]; 
    public bool isDisplayed;
    public GameObject inventoryUI;
    public GameObject axe;

    public FirstPersonController component;

    
    void Start()
    {
        isDisplayed = false;

    }

    public void AddItem(Item item, Sprite sprite)
    {
        var isFound = false;
        foreach (var it in inventory)
        {
            if (it.name == item.name)
            {
                Debug.Log(item.name);
                it.amount++;
                Debug.Log(it.amount);

                isFound = true;
                break;
            }
            
        }

        if (!isFound)
        {
           
                inventory.Add(item);
        
                slots[inventory.Count - 1].transform.GetChild(1).GetComponent<Image>().sprite = sprite;
               
                if(!item.canStacked){
                    slots[inventory.Count - 1].transform.GetChild(0).GetComponent<Text>().text = char.ToUpper(item.name[0]) + item.name.Substring(1);
                }
                else
                {
                    item.amount++;
                    slots[inventory.Count - 1].transform.GetChild(0).GetComponent<Text>().text = char.ToUpper(item.name[0]) + item.name.Substring(1) + " (" + item.amount + ")";
                }
        }

    }

    public void ShowItems()
    {
        

        foreach (var slot in slots)
        {
            if (slot.transform.GetChild(1).GetComponent<Image>().sprite != null)
            {
                slot.gameObject.SetActive(true);
            }
            else
            {
                slot.gameObject.SetActive(false);

            }
        }

        foreach (var slot in slots)
        {

            if (slot.gameObject.active)
            {
            
                foreach (var item in inventory)
                {

                    if (slot.transform.GetChild(0).GetComponent<Text>().text.Contains(char.ToUpper(item.name[0]) + item.name.Substring(1)) && item.canStacked)
                    {
                        //Debug.Log("Yazdım");
                        slot.transform.GetChild(0).GetComponent<Text>().text = char.ToUpper(item.name[0]) + item.name.Substring(1) + " (" + item.amount + ")";
                            
                    
                    }
                
                
                }
                
            }
            
        }
        
        
    }

    void relocateInventory()
    {
        

        for (int i = 0; i < slots.Length; i++)
        {

            for (int j = i; j < slots.Length; j++)
            {

                if (!slots[i].IsActive() && slots[j].IsActive())
                {

                    slots[i].transform.GetChild(1).GetComponent<Image>().sprite = slots[j].transform.GetChild(1).GetComponent<Image>().sprite;
                    slots[i].transform.GetChild(0).GetComponent<Text>().text = slots[j].transform.GetChild(0).GetComponent<Text>().text;
                    slots[i].gameObject.SetActive(true);
                    
                    slots[j].gameObject.SetActive(false);
                    slots[j].transform.GetChild(1).GetComponent<Image>().sprite = null;
                    slots[j].transform.GetChild(0).GetComponent<Text>().text = "";
                }
                
            }
            
        }
        
        ShowItems();
        
        
        
    }
    
    // Update is called once per frame
    void Update()
    {
        int cnt = 0;
        foreach (var slot in slots)
        {

            foreach (var item in inventory)
            {
                if (item.amount == 0 && item.canStacked && slot.transform.GetChild(0).GetComponent<Text>().text.Contains(item.name))
                {
                    inventory.RemoveAt(cnt);
                    
                    slot.gameObject.SetActive(false);
                    slot.transform.GetChild(1).GetComponent<Image>().sprite = null;
                    
                    break;
                }

                cnt++;

            }

            cnt = 0;
        }
        relocateInventory();

        
        if (Input.GetKeyDown(KeyCode.Tab))
        {

           

            isDisplayed = !isDisplayed;
            
            
        }

        if (isDisplayed)
        {
            GetComponent<Craft>().craftBook.SetActive(false);
            GetComponent<FirstPersonController>().m_MouseLook.lockCursor = false;
            GetComponent<FirstPersonController>().m_MouseLook.SetCursorLock(false);
            GetComponent<FirstPersonController>().enabled = false;
            axe.GetComponent<axeAttack>().enabled = false;

            ShowItems();
            
        }
        else if(!isDisplayed && !GetComponent<Craft>().isDisplayed)
        {

            GetComponent<FirstPersonController>().m_MouseLook.lockCursor = true;
            GetComponent<FirstPersonController>().m_MouseLook.UpdateCursorLock();
            GetComponent<FirstPersonController>().enabled = true;
            axe.GetComponent<axeAttack>().enabled = true;

            
        }
       
       

        inventoryUI.SetActive(isDisplayed);
        
        
        
        

    }
}

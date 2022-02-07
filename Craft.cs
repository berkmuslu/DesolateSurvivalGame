using System.Collections;
using System.Collections.Generic;
using Microsoft.Win32.SafeHandles;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class Craft : MonoBehaviour
{
    public GameObject craftBook;
    public Button craftFirePit;
    public Button craftShelter;
    public Button craftFishingRod;
    
    private int stickInInventory;
    private int logInInventory;
    private int stoneInInventory;

    public GameObject axe;

    public bool isDisplayed;

    void Start()
    {
        isDisplayed = false;
        craftFirePit.interactable = false;
        craftShelter.interactable = false;
        craftFishingRod.interactable = false;

        craftFirePit.onClick.AddListener(craftPit);
        craftShelter.onClick.AddListener(craftShelterFunc);
        craftFishingRod.onClick.AddListener(craftFishingRodFunc);

        logInInventory = 0;
        stickInInventory = 0;
        stoneInInventory = 0;
    }

    void craftPit()
    {
        foreach (var item in GetComponent<InventorySystem>().inventory)
        {

            if (item.name == "Log")
            {
                item.amount -= 5;
            }

            if (item.name == "Stone")
            {
                item.amount -= 7;
            }
            
        }

    }
    
    void craftShelterFunc()
    {
        foreach (var item in GetComponent<InventorySystem>().inventory)
        {

            if (item.name == "Log")
            {
                item.amount -= 15;
            }

            if (item.name == "Stick")
            {
                item.amount -= 12;
            }
            
            if (item.name == "Stone")
            {
                item.amount -= 8;
            }
            
        }

    }
    
    void craftFishingRodFunc()
    {
        foreach (var item in GetComponent<InventorySystem>().inventory)
        {

            if (item.name == "Stick")
            {
                item.amount -= 15;
            }

            if (item.name == "Stone")
            {
                item.amount -= 8;
            }
        }

    }

    public void recalculateInventory()
    {
        bool log_found = false;
        bool stone_found = false;
        bool stick_found = false;
        
        foreach (var item in GetComponent<InventorySystem>().inventory)
        {
            if (item.name == "Log")
            {
                logInInventory = item.amount;
                log_found = true;
            }

            if (item.name == "Stone")
            {
                stoneInInventory = item.amount;
                stone_found = true;
            }

            if (item.name == "Stick")
            {
                stickInInventory = item.amount;
                stick_found = true;
            }
        }

        if (!log_found)
        {
            logInInventory = 0;
        }
        
        if (!stone_found)
        {
            stoneInInventory = 0;
        }
        
        if (!stick_found)
        {
            stickInInventory = 0;
        }
        
    }
    

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.B))
        {
            
            isDisplayed = !isDisplayed;
            
            
        }
        
        
        recalculateInventory();

        
        
        if (isDisplayed)
        {
            GetComponent<InventorySystem>().isDisplayed = false;

            GetComponent<FirstPersonController>().m_MouseLook.lockCursor = false;
            GetComponent<FirstPersonController>().m_MouseLook.SetCursorLock(false);
            GetComponent<FirstPersonController>().enabled = false;
            axe.GetComponent<axeAttack>().enabled = false;

                
            if (logInInventory >= 5 && stoneInInventory >= 7)
            {
                craftFirePit.interactable = true;
            }
            else
            {
                craftFirePit.interactable = false;

            }

            if (logInInventory >= 15 && stickInInventory >= 12 && stoneInInventory >= 8)
            {
                craftShelter.interactable = true;
            }
            else
            {
                craftShelter.interactable = false;

            }

            if (stickInInventory >= 15 && stoneInInventory >= 8)
            {
                craftFishingRod.interactable = true;
            }
            else
            {
                craftFishingRod.interactable = false;

            }
            
            craftBook.SetActive(true);
        }
        else if(!isDisplayed && !GetComponent<InventorySystem>().isDisplayed)
        {
            craftBook.SetActive(false);
            
            GetComponent<FirstPersonController>().m_MouseLook.lockCursor = true;
            GetComponent<FirstPersonController>().m_MouseLook.UpdateCursorLock();
            GetComponent<FirstPersonController>().enabled = true;
            
            axe.GetComponent<axeAttack>().enabled = true;



        }
       
        
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PickUpCoconut : MonoBehaviour
{
 
    private Transform player;
    private GameObject pickUpText;
    private float range = 3.0f;
    public bool equipped;
    private bool isInside;


    private void Start()
    {
      
        player = GameObject.Find("Character").transform;
        pickUpText = GameObject.Find("equipText");


    }

    private void Update()
    {
        Vector3 distance = player.position - transform.position; //Got the idea from the internet

        if (distance.magnitude <= range && !equipped)
        {
            pickUpText.GetComponent<TextMeshProUGUI>().enabled = true;

            if (Input.GetKeyDown(KeyCode.E))
            {
                PickUp();
            }

            isInside = true;

        }
        else if (distance.magnitude >= range  && isInside)
        {
            pickUpText.GetComponent<TextMeshProUGUI>().enabled = false;
            isInside = false;
        }
      
      

        if (equipped)
        {
            
            pickUpText.GetComponent<TextMeshProUGUI>().enabled = false;
            
        }


    }
    private void PickUp()
    {
       
            GetComponent<Item>().AddItem();
            pickUpText.GetComponent<TextMeshProUGUI>().enabled = false;
            transform.parent.GetComponent<Coconut>().chanceFactor = 1.0f;
            Destroy(gameObject);
        
    }
   

}
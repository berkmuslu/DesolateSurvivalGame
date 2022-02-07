using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class cutTree : MonoBehaviour
{
   public GameObject text;
   public AudioSource chop;
   public AudioSource fall;
   private int treeHealth;

   private void Start()
   {
      treeHealth = Random.Range(3, 6);
      text = GameObject.Find("feedbackText");
   }

   private void OnTriggerEnter(Collider other)
   {
      if (other.name == "axe")
      {

         
         if (other.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("axe_attack")) //Took it from the internet
         {
            
            
            if(treeHealth != 0)
            {


               double stick_chance = Random.Range(0.0f,1.0f);

               if (stick_chance >= 0.5f)
               {
                  GetComponent<SecondaryItem>().AddItem();
               }
               
            GetComponent<Item>().AddItem();

            text.GetComponent<TextMeshProUGUI>().text += "Obtained +1 Log!\n"; 
            text.GetComponent<textFading>().startWaiting(treeHealth);

            Debug.Log("Ağaca vuruldu!");
            chop.Play();
            treeHealth--;

            }
         }
         
      }
   }

   private bool notDead = true;
   private void Update()
   {
      if (treeHealth == 0)
      {
         if(notDead){
         fall.Play();
         notDead = false;
         }
               
         if(!fall.isPlaying){
         Destroy(gameObject);
         }
      }
   }
}

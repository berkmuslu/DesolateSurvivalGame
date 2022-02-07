using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PickUp_V2 : MonoBehaviour
{
   private Rigidbody rb;
   private MeshCollider col;
   public Transform player, hand;
   public GameObject pickUpText;
   public bool isPickable;
   private float range = 3.0f;
   public bool equipped;
   private bool isInside;


   private void Start()
   {
      rb = GetComponent<Rigidbody>();
      col = GetComponent<MeshCollider>();

      if(GetComponent<Animator>() != null){
         GetComponent<Animator>().enabled = false;
      }

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
         if(GetComponent<Animator>() != null){
            GetComponent<Animator>().enabled = true;
         }
         pickUpText.GetComponent<TextMeshProUGUI>().enabled = false;
         
        
      }


   }
   private void PickUp()
   {
      if (isPickable){
      equipped = true;
      rb.isKinematic = true;
      col.isTrigger = true;
      GetComponent<Item>().AddItem();
      transform.SetParent(hand);
      
      transform.localPosition = Vector3.zero;
      transform.localRotation = Quaternion.Euler(Vector3.zero);
      transform.localScale = Vector3.one;
      
      }
      else
      {
         GetComponent<Item>().AddItem();
         pickUpText.GetComponent<TextMeshProUGUI>().enabled = false;
         Destroy(gameObject);
      }
   }
   

}

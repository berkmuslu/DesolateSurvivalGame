using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Coconut : MonoBehaviour
{
    public GameObject prefab_Coconut;
    public double chanceFactor;
    public bool isCreated;
    public bool isCalled;

    private void Start()
    {
        chanceFactor = Random.Range(0.0f,1.0f);
        isCalled = false;

    }
    
    public void Update()
    {
        if(chanceFactor <= 0.2 && !isCreated){
            Instantiate(prefab_Coconut, transform);
            prefab_Coconut.transform.localPosition = Vector3.zero;
            prefab_Coconut.transform.localRotation = Quaternion.Euler(Vector3.zero);
            prefab_Coconut.transform.localScale = Vector3.one;
            isCreated = true;
        }

        if (transform.childCount == 0)
        {
            isCreated = false;

            if (!isCalled)
            {
                isCalled = true;
                StartCoroutine(waitCoroutine());
            }
            
        }

       
        
        
    }

 
    IEnumerator waitCoroutine()  //Learned from internet
    {

        yield return new WaitForSeconds(10);
        chanceFactor = Random.Range(0.0f, 1.0f);
        isCalled = false;


    }

}

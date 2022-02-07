using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class removeItems : MonoBehaviour
{
    public GameObject cube1;
    public GameObject cube2;
    public bool gameStarted;

    void Start()
    {
        gameStarted = false;
        StartCoroutine(waitCoroutine());
    }
    
    IEnumerator waitCoroutine()  //Learned from internet
    {
        GetComponent<FirstPersonController>().enabled = true;

        GetComponent<FirstPersonController>().m_MouseLook.lockCursor = true;
        GetComponent<FirstPersonController>().m_MouseLook.UpdateCursorLock();
        GetComponent<FirstPersonController>().enabled = false;
        yield return new WaitForSeconds(1);
        Destroy(cube1);
        Destroy(cube2);
        
        GetComponent<FirstPersonController>().enabled = true;



    }
}

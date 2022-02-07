using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class lifeBars : MonoBehaviour
{
    public float playerHealth;
    public float playerHunger;
    public float playerThirst;

    private Transform healthBar;
    private Transform foodBar;
    private Transform waterBar;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = 100.0f;
        playerHunger = 100.0f;
        playerThirst = 100.0f;

        healthBar = GameObject.Find("healthBar").transform;
        foodBar = GameObject.Find("foodBar").transform;
        waterBar = GameObject.Find("waterBar").transform;
        
        


    }

    // Update is called once per frame
    // 0.9719047 full
    //100/102.8902
    // 0 min
    void Update()
    {

        if (playerHealth <= 0f)
        {
            playerHealth = 0;
            GetComponent<changeScene>().loadScene();
        }

        if (playerHunger == 0.0f || playerThirst == 0.0f)
        {
            playerHealth -= 0.008f;
        }
        
        
        if (playerHealth > 0)
        {
            healthBar.localScale = new Vector3((playerHealth/102.8902f) ,healthBar.localScale.y,healthBar.localScale.z);

        }
        
        if (playerHunger > 0)
        {
            foodBar.localScale = new Vector3((playerHunger/102.8902f) ,foodBar.localScale.y,foodBar.localScale.z);
            
            if (!gameObject.GetComponent<FirstPersonController>().m_IsWalking)
            {
                playerHunger -= 0.004f;
            }
            else
            {
                playerHunger -= 0.002f;
            }

        }
        
        if (playerThirst > 0)
        {
            waterBar.localScale = new Vector3((playerThirst/102.8902f) ,waterBar.localScale.y,waterBar.localScale.z);
            
            
            if (!gameObject.GetComponent<FirstPersonController>().m_IsWalking)
            {
                playerThirst -= 0.006f;
            }
            else
            {
                playerThirst -= 0.003f;
            }
          

        }

        if (playerThirst <= 0)
        {
            playerThirst = 0;
        }

        if (playerHunger <= 0)
        {
            playerHunger = 0;
        }
    }
}

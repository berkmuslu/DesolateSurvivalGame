using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class axeAttack : MonoBehaviour
{
    // Update is called once per frame

    public Animator animator;
    void Update()
    {
        
        if (gameObject.GetComponent<PickUp_V2>().equipped && Input.GetMouseButtonDown(0))
        {
            animator.SetBool("isAttacked",true);
        }
        
        if (gameObject.GetComponent<PickUp_V2>().equipped && Input.GetMouseButtonUp(0))
        {
            animator.SetBool("isAttacked",false);
        }
    }
}

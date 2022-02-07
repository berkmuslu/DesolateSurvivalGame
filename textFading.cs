using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
class textFading : MonoBehaviour
{
    public TextMeshProUGUI text;
    

    public void startWaiting(int treeHealth)
    {
        StartCoroutine(waitCoroutine(treeHealth));
        
    }

    IEnumerator waitCoroutine(int treeHealth) 
    {
            yield return new WaitForSeconds(treeHealth);
            text.text = "";
            yield return null;
    }
}
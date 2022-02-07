using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScene : MonoBehaviour
{
    public int sceneID;


    public void loadScene()
    {

        if (sceneID == -1)
        {
            Application.Quit();
        }
        
        SceneManager.LoadScene(sceneID);

    }
    
}

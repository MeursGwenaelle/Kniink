using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TPBd : MonoBehaviour
{

    public string levelToLoad;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene(levelToLoad);

    }

    

   
}

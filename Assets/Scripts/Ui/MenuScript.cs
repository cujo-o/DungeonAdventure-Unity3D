using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public GameObject choosepanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

  

    public void BtStart()
    {
        choosepanel.SetActive(true);
    }
    public void Customize()
    {
        if (choosepanel.activeSelf == false)
        {
            choosepanel.SetActive(true);
           
        }
        else
        {
            choosepanel.SetActive(false);
           
        }
    }

    public void back()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

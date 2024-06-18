using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bossexit : MonoBehaviour
{
    public float elapsedtime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] enemynumber = GameObject.FindGameObjectsWithTag("enemy");


        int enumb = enemynumber.Length;
        elapsedtime -= Time.deltaTime;
        if (elapsedtime <= 0)
        {
            if (enumb <= 0)
            {
                Invoke(nameof(Win), 4);
               // Win();
            }
        }
      
    }

    public void Win()
    {
     
        SceneManager.LoadScene("levels");
    }
}

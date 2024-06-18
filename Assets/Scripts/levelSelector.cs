using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class levelSelector : MonoBehaviour
{
    public static int selectedLevel;
    public int levelnum;
    public TextMeshProUGUI leveltext;
   
    // Start is called before the first frame update
    void Start()
    {
        leveltext.text = levelnum.ToString(); 
    }

  

    public void LoadScene()
    {
        selectedLevel = levelnum;

        if (levelnum == 5 || levelnum == 15 || levelnum == 25 || levelnum == 35 || levelnum == 45 || levelnum == 55 || levelnum == 65)
        {
            SceneManager.LoadScene("miniboss");
        }
        else if (levelnum == 10 || levelnum == 20 || levelnum == 30 || levelnum == 40 || levelnum == 50 || levelnum == 60 || levelnum == 70)
        {
            SceneManager.LoadScene("boss");
        }
        else
        {
            SceneManager.LoadScene("Dungeons");
        }

       
    }
}

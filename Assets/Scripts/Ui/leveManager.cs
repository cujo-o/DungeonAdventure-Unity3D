using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class leveManager : MonoBehaviour
{
    public TextMeshProUGUI levelText;
    public Button[] levelBT;
   public int levelnum;

    // Start is called before the first frame update
    void Start()
    {
       levelnum  = levelSelector.selectedLevel;
        Debug.Log(levelnum);
        levelText.text = "Level " + levelnum.ToString();
      
    }

    private void Awake()
    {
       /* int unlocklevel = PlayerPrefs.GetInt("unlockedlevel", 1);
        for (int i = 0; i < levelBT.Length; i++)
        {
            levelBT[i].interactable = false;
        }

        for (int i = 0; i < unlocklevel; i++)
        {
            levelBT[i].interactable = true;
        }*/
    }

    public void  ToSafehub()
    {
        SceneManager.LoadScene("Safe Hub");
    }

  
}

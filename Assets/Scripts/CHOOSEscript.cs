using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CHOOSEscript : MonoBehaviour
{
    // Start is called before the first frame update
    public int choose;
    public void melee()
    {
        SceneManager.LoadScene("Safe Hub");
        choose = 1;

        PlayerPrefs.SetInt("choosenum", choose);
    }

    public void archer()
    {
        SceneManager.LoadScene("Safe Hub");
        choose = 2;

        PlayerPrefs.SetInt("choosenum", choose);
    }

    public void spells()
    {
        SceneManager.LoadScene("Safe Hub");
        choose = 3;

        PlayerPrefs.SetInt("choosenum", choose);
    }

    void Update()
    {
      //  PlayerPrefs.SetInt("choosenum", choose);
    }
}

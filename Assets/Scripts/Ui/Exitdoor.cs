using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Exitdoor : MonoBehaviour
{
    [SerializeField] private leveManager levelmanager;
    public float elapsedtime;
    public GameObject exitDoor;
    // Start is called before the first frame update
    void Start()
    {
       levelmanager = GameObject.FindAnyObjectByType<leveManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // levelPanel = GameObject.FindGameObjectWithTag("levelpanel");

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

        Destroy(exitDoor);
    }
    public void unloockLevel()
    {
     /*   PlayerPrefs.GetInt("unlockedlevel", PlayerPrefs.GetInt("unlockedlevel", 1) + 1);
        PlayerPrefs.Save();
       int ml = levelmanager.levelnum + 1;*/
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("levels");
           // unloockLevel();
        }
    }
}

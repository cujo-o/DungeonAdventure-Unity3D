using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public Slider PlayerHealthBar; //use it if you have a health bar. Just drag and drop it into this field in the editor.
  //  public AudioSource DeathSound; //Use it if you have a death sound. Just drag and drop it into this field in the editor.
    public float Health = 100.0f;  //Health of the player. Just for stating sake and easy modification in the editor
    public float CurrentHealth;  //This is the health code we will be using in the script
    public GameObject player;
    private equipmentSysytem equipment;
    public Playersounds playersounds;
  //  public AudioSource PlayerHit;  //use it if you have a player hit sound
  //  public Rigidbody[] ragdollbodies; //Drag and drop all the player character's ragdoll rigidbodies here
  //  public Collider[] ragdollcolliders; //Drag and drop all the player character's ragdoll colliders here

    // Start is called before the first frame update
    void Start()
    {
       // PlayerHealthBar = GameObject.FindGameObjectWithTag("PHB").GetComponent<Slider>(); //If you want to use a health bar, utilize this code, else just comment it out
        CurrentHealth = Health;
        PlayerHealthBar.value = CurrentHealth;
        equipment = FindAnyObjectByType<equipmentSysytem>();
        playersounds = FindAnyObjectByType<Playersounds>();
        
        /*  //Use these codes below if the Player has all its colliders on the gameobject the script is attached on(It wont be important because you will definitely have other colliders on e.g, the hands, legs, spine, head,etc when you enable ragdoll on the character. Just drag and drop the colliders and rigidbodies into the field in the editor)
          ragdollbodies = GetComponentsInChildren<Rigidbody>();
          ragdollcolliders = GetComponentsInChildren<Collider>();
  */
    }

  


    //This function is for the player to detect damage
    public void TakeDamage(float damage)
    {
       // playersounds.damagesound();
            CurrentHealth -= damage; //Reduces the current health of the player
            PlayerHealthBar.value = CurrentHealth; //Sets the playerhealth bar to be the same value with the current health
            if (CurrentHealth <= 0)
            {
               Death(); 
            }
    }

    public void addhealth(int health)
    {
        //  PlayerHit.Play(); //If there's a Hit audio, play it. Else just comment this code out to prevent compile errors
        CurrentHealth += health; //Reduces the current health of the player
        PlayerHealthBar.value = CurrentHealth; //Sets the playerhealth bar to be the same value with the current health
      
    }




    //As the name implies, It handles the player's death, heck, it kills the player😢
    public void Death()
    {
        playersounds.deathsound();
        SceneManager.LoadScene("Safe Hub");
        Destroy(player);
        }


}


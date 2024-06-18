using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{
   public float Health = 100.0f;  //Health of the player. Just for stating sake and easy modification in the editor
    public float CurrentHealth;  //This is the health code we will be using in the script
    public Animator anim;
    public weaponDamge weaponDamge;
    public Enemysounds enemysounds;
 

    // Start is called before the first frame update
    void Start()
    {
      //  PlayerHealthBar = GameObject.FindGameObjectWithTag("PHB").GetComponent<Slider>(); //If you want to use a health bar, utilize this code, else just comment it out
        CurrentHealth = Health;
        anim = GetComponent<Animator>();
        enemysounds = GetComponent<Enemysounds>();
       
    }


    //This function is for the player to detect damage
    public void TakeDamage(float damage)
    {
        enemysounds.damagesound();
        CurrentHealth -= damage; //Reduces the current health of the player
        anim.SetTrigger("dam");
        if (CurrentHealth <= 0)
        {
            anim.SetTrigger("die");
           
            Invoke(nameof(Death), 1);
            
        }
    }




    //As the name implies, It handles the player's death, heck, it kills the player😢
    public void Death()
    {
        enemysounds.deathsound();
        Destroy(this.gameObject);
      
      
    }

   /* void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("sword"))
        {
            TakeDamage(damageTaken);
        }
    }*/
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("sword"))
        {
            TakeDamage(other.GetComponent<weaponDamge>().weaponDamage);
            
        }

        if (other.gameObject.CompareTag("arrow"))
        {
            TakeDamage(other.GetComponent<ArrowScript>().damage);
        }
    }

    void knockback()
    {
        transform.position += transform.forward * Time.deltaTime * weaponDamge.knockBcak;
    }

}

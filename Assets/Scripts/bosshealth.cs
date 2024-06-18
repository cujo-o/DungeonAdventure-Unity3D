using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bosshealth : MonoBehaviour
{
   public float Health = 100.0f;  //Health of the player. Just for stating sake and easy modification in the editor
    public float CurrentHealth;  //This is the health code we will be using in the script
    public Slider bossslider;
    public weaponDamge weaponDamge;
    private Animator anim;
    public Enemysounds enemysounds;
    public ShopManager shopManager;

    // Start is called before the first frame update
    void Start()
    {
      //  PlayerHealthBar = GameObject.FindGameObjectWithTag("PHB").GetComponent<Slider>(); //If you want to use a health bar, utilize this code, else just comment it out
        CurrentHealth = Health;
        Health = bossslider.maxValue;
      bossslider.value = CurrentHealth;
        anim = GetComponent<Animator>();
        enemysounds = GetComponent<Enemysounds>();
        shopManager = FindAnyObjectByType<ShopManager>();

    }

    void Update()
    {
       // CurrentHealth = Health;

    }

    

    //This function is for the player to detect damage
    public void TakeDamage(float damage)
    {
      
        CurrentHealth -= damage; //Reduces the current health of the player
        bossslider.value = CurrentHealth;
        enemysounds.damagesound();
        anim.SetTrigger("dam");
        
        if (CurrentHealth <= 0)
        {
            anim.Play("Die");
          //  Death();
            Invoke(nameof(Death), 3 );
        }
    }




    //As the name implies, It handles the player's death, heck, it kills the player😢
    public void Death()
    {
        shopManager.coins += 2;
        shopManager.Savecoins();
        enemysounds.damagesound();
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

        if (other.gameObject.CompareTag("spell"))
        {
            TakeDamage(other.GetComponent<SpellProjectile>().damage);
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

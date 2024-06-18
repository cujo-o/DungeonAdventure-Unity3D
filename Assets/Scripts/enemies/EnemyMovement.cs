using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

   // public PlayerHealth PlayerHealth;
    public float speed; 
    private Transform player;
    public Animator Anim;
    private int randomValue;



    [SerializeField] PlayerHealth playerHealth;
    public float firerate = 1f;
    public float lineofsight;
    
   // private PlayerHealth playerhealth;
    public float shootingrange;
    private float nextfiretime;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerHealth = FindObjectOfType<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        
        float distancefromplayer = Vector3.Distance(player.position, transform.position);

        if (distancefromplayer < lineofsight && distancefromplayer > shootingrange)
        {
           
            transform.LookAt(player);
            transform.position = Vector3.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
            Anim.SetTrigger("walk");

        }
        else if (distancefromplayer <= shootingrange && nextfiretime < Time.time)
        {
            //  anim.SetTrigger("attack");
           
            Attack();
            nextfiretime = Time.time + firerate;
        }
    }

    public void Attack() 
    {
       playerHealth.TakeDamage(2f);
       
            float distancefromplayer = Vector2.Distance(player.position, transform.position);
        randomValue = Random.Range(1, 3);
            if (distancefromplayer <= shootingrange && nextfiretime < Time.time)
            {

                if (randomValue == 1)
                {
                   // Anim.SetTrigger("attack1");
                Anim.Play("Attack01");
                }
                else
                {
                Anim.Play("Attack02");
                   // Anim.SetTrigger("attack2");
                }

            }
        

    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lineofsight);
        Gizmos.DrawWireSphere(transform.position, shootingrange);
    }

  

}

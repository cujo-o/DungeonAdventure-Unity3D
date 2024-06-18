using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellProjectile : MonoBehaviour
{
    Transform target;
    public float speed;
    public float damage;
    public SpellAttack spellAttack;
    // Start is called before the first frame update
    void Start()
    {
      //  target = GameObject.FindGameObjectWithTag("enemy").transform;
        Destroy(this.gameObject, 5);
        spellAttack = FindAnyObjectByType<SpellAttack>();
	
	}

	// Update is called once per frame
	void Update()
    {
        target = spellAttack.target;
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("enemy"))
        {
            other.GetComponent<enemyHealth>().TakeDamage(damage);
            Destroy(this.gameObject);
        }
    }
	

	
}

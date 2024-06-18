using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellAttack : MonoBehaviour
{
    public GameObject bullet;
    public GameObject bulletparent;
    public float firerate = 1f;
    private float nextfiretime;
    public float attackrate;
    float nextattacktime;
    public Animator anim;

    public Transform target;
    private GameObject targetEnemy;
    public Playersounds playersounds;

    

    public float range = 150f;
    // Start is called before the first frame update
    void Start()
    {
        anim  = GetComponent<Animator>();
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        playersounds = FindAnyObjectByType<Playersounds>();

    }

    // Update is called once per frame
    void Update()
    {
        if (nextfiretime < Time.time)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                anim.SetTrigger("castspell");
                playersounds.fireballsound();
                nextfiretime = Time.time + firerate;
            }
        }
    }

   public void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");

        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
            targetEnemy = GameObject.FindGameObjectWithTag("enemy");
        }
        else
        {
            target = null;
        }

    }

    public void fire()
    {
        Instantiate(bullet, bulletparent.transform.position, Quaternion.identity);
        nextfiretime = Time.time + firerate;
    }
}

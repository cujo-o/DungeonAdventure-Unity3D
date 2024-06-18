using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class bowController : MonoBehaviour
{
    public GameObject arrowPrefab;
    

    public Camera cam;
    public LayerMask playerMask;
    public Animator animator;

    [Header("Use Bullets (default)")]
    public int currentclip;
    public int maxclipsize = 2;
    public int currentammo;
    public int maxammosize = 100;
    [SerializeField] public float firerate = 1f;
    private float nextfiretime;
    public TextMeshProUGUI text;
    public Playersounds playersounds;

    private void OnEnable()
    {
        playersounds = FindAnyObjectByType<Playersounds>();
        animator = GetComponent<Animator>();
    }

    public void Update()
    {

      
        if (nextfiretime < Time.time)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                animator.SetTrigger("attack");
                playersounds.arrowsound();
                nextfiretime = Time.time + firerate;

            }
        }

        if (currentclip <= 0)
        {
            reload();

        }
        updateammotext();

    }

    public void fire()
    {
        StartCoroutine((ThrowProjectile(arrowPrefab)));
        nextfiretime = Time.time + firerate;
        currentclip--;
    }

    [SerializeField]
    private Transform fireTransform;

    Vector3 calculateDirection(float force)
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        Vector3 maxTarget = ray.origin + ray.direction * force;
        var heading = maxTarget - fireTransform.position;
        var distance = heading.magnitude;
        var direction = heading / distance;

        int mask = ~playerMask.value;
        RaycastHit hitPoint;
        if (Physics.Raycast(ray.origin, ray.direction, out hitPoint, force, mask))
        {
            heading = hitPoint.point - fireTransform.position;
            distance = heading.magnitude;
            direction = heading / distance;
        }

        Debug.DrawRay(ray.origin, direction * 10, Color.yellow, 2);

        return direction;
    }

    IEnumerator ThrowProjectile(GameObject prefab)
    {
        GameObject projectile = Instantiate(prefab);
        ArrowScript arrowProjectile = projectile.GetComponent<ArrowScript>();

        Vector3 direction = calculateDirection(arrowProjectile.force);

        projectile.transform.position = fireTransform.position + direction;
        projectile.transform.forward = direction;
        projectile.transform.Rotate(90, 0, 0);

        //Wait for the position to update
        yield return null;

        arrowProjectile.Fire(direction);
    }

    public void reload()
    {
        int reloadamount = maxclipsize - currentclip;
        reloadamount = (currentammo - reloadamount) >= 0 ? reloadamount : currentammo;
        currentclip += reloadamount;
        currentammo -= reloadamount;

        //	Instantiate(enemy, floor.position, Quaternion.identity);
    }
    public void addammo(int ammoamount)
    {
        currentammo += ammoamount;
        if (currentammo > maxammosize)
        {
            currentammo = maxammosize;
        }
    }
    public void updateammotext()
    {
        text.text = $"{currentclip}/{currentammo}";

    }

}

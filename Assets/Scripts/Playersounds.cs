using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playersounds : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip[] footsteps;
    private AudioClip footstepsclip;

    public AudioClip[] fireball;
    private AudioClip fireballclip;

    public AudioClip[] arrow;
    private AudioClip arrowclip;



    public AudioClip[] death;
    private AudioClip deathclip;

    public AudioClip[] damage;
    private AudioClip damageclip;

    public AudioClip[] meleeAT;
    private AudioClip meleeATclip;
       
    
    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
 

    public void meleeATsound()
    {
        int index = Random.Range(0, meleeAT.Length);
        meleeATclip = meleeAT[index];

        audioSource.clip = meleeATclip;
        audioSource.Play();
    }

  


    public void fireballsound()
    {
        int index = Random.Range(0, fireball.Length);
        fireballclip = fireball[index];

        audioSource.clip = fireballclip;
        audioSource.Play();
    }
    public void damagesound()
    {
        int index = Random.Range(0, damage.Length);
       damageclip = damage[index];

        audioSource.clip = damageclip;
        audioSource.Play();
    }
    public void deathsound()
    {
        int index = Random.Range(0, death.Length);
      deathclip = death[index];

        audioSource.clip = deathclip;
        audioSource.Play();
    }
  
    public void footstepsound()
    {
        int index = Random.Range(0, footsteps.Length);
       footstepsclip = footsteps[index];

        audioSource.clip = footstepsclip;
        audioSource.Play();
    }

    public void arrowsound()
    {
        int index = Random.Range(0, arrow.Length);
        arrowclip = arrow[index];

        audioSource.clip = arrowclip;
        audioSource.Play();
    }

}

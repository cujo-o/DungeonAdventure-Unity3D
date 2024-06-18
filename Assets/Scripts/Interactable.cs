using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Interactable : MonoBehaviour
{

	public float radius = 3f;               // How close do we need to be to interact?
	public Transform interactionTransform;  // The transform from where we interact in case you want to offset it


	public Transform player;        // Reference to the player transform

	public bool hasInteracted = false; // Have we already interacted with the object?
	public GameObject shop;
	public GameObject PlayerUI;
	

    void Start()
    {
		PlayerUI = GameObject.FindGameObjectWithTag("playerui");
		player = GameObject.FindGameObjectWithTag("Player").transform;
		shop = GameObject.FindGameObjectWithTag("playershop");
		//shop.gameObject.SetActive(false);
	}
    public void Interact()
	{
		 if (shop.activeSelf==false)
		  {
	
        shop.gameObject.SetActive(true);
        PlayerUI.gameObject.SetActive(false);
        Time.timeScale = 0f;


        }
        else 
		{
			shop.gameObject.SetActive(false);
			PlayerUI.gameObject.SetActive(true);
			Time.timeScale = 1f;
			
		}
	
    }





    void Update()
		{
			// If we are currently being focused
			// and we haven't already interacted with the object
			if (!hasInteracted)
			{
				// If we are close enough
				float distance = Vector3.Distance(player.position, interactionTransform.position);
				if (distance <= radius)
				{
					if (Input.GetKeyDown(KeyCode.E))
					{
						Interact();
						//hasInteracted = true;
					}
					// Interact with the object

				}
			}

		//shop = GameObject.FindGameObjectWithTag("playershop");
	}


		void OnDrawGizmosSelected()
		{
			if (interactionTransform == null)
				interactionTransform = transform;

			Gizmos.color = Color.yellow;
			Gizmos.DrawWireSphere(interactionTransform.position, radius);
		}

	}


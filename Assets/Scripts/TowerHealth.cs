﻿//This script tracks the health of the tower and game status

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TowerHealth : MonoBehaviour
{
	public int numberOfLives = 3;	//How many hits tower can take
	public Image damageImage;		//Full screen red image

    int currentLives;				//Current number of lives
	AudioSource damageAudio;		//Audio feedback of hit
	bool alive = true;				//Is the tower alive?
	public GameObject DroneLife2; 
	public GameObject DroneLife3; 

    void Awake()
	{
		//Set current lives and get audio component reference
        currentLives = numberOfLives;
		damageAudio = GetComponent<AudioSource>();
		DroneLife2.SetActive(true);
		DroneLife3.SetActive(true);

    }

	void OnTriggerEnter(Collider other)
	{
		print ("yeah");
		//Make sure we can only be hit by enemies and only if tower is alive
		if (other.tag != "Enemy" || !alive)
			return;

		Destroy(other.gameObject);
        currentLives -= 1;
		damageAudio.Play();
	
		
		if (currentLives == 2) {
			DroneLife3.SetActive(false);
		}

		if (currentLives == 1) {
			DroneLife2.SetActive(false);
		}
		

		//If we are out of lives...
		if(currentLives <= 0)
		{
			//...set alive to false and show the red damage image
			//This image will hide the gameplay for 3 seconds
			alive = false;
            if (damageImage)
            {
                Color col = damageImage.color;
                col.a = 1f;
                damageImage.color = col;
            }

			//Restart the gameplay after 3 seconds
			Invoke("Restart", 3f);
		}
	}

	void Restart()
	{
		//While the red image is still up, and before gameplay resumes, find
		//all enemies in the scene and destroy them. It doesn't matter that Find() is
		//very slow since any stutter is hidden by the red image
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < enemies.Length; i++)
            Destroy(enemies[i]);

		//Reset lives and alive boolean
        currentLives = numberOfLives;
        alive = true;

		//Hide red image
        if (damageImage)
        {
            Color col = damageImage.color;
            col.a = 0f;
            damageImage.color = col;
		}

        DroneLife2.SetActive(true);
        DroneLife3.SetActive(true);
    }
}

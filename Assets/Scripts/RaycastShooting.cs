using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class RaycastShooting : MonoBehaviour
{
    public Transform laserOrigin;
    public float gunRange;
    public float fireRate;
    private AudioSource gunAudio;
    private AudioSource onClickSound;
    private LineRenderer laserLine;
    private WaitForSeconds shotDuration = new WaitForSeconds(0.07f);
    public Camera fpsCam;
    float nextFire;
    public AmmoScript ammoScript;
    ScoreManager scoreManager;
    string sceneName;
    [SerializeField] DroneHealthScript droneHealthScript;

  

     
   
   public void Start () 
    {
        // Get and store a reference to our LineRenderer component
        laserLine = GetComponent<LineRenderer>();
        scoreManager= GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        // Get and store a reference to our AudioSource component
        gunAudio = GetComponent<AudioSource>();
        onClickSound= GameObject.Find("ShootBtn").GetComponent<AudioSource>();
        sceneName= SceneManager.GetActiveScene().name;

        // Get and store a reference to our Camera by searching this GameObject and its parents
        // fpsCam = GetComponentInParent<Camera>();
    }

    public void onClick(){
        
            onClickSound.Play();
        
    }
    public void shot() 
    {
        float ammo= ammoScript.GetAmmo();
         
       
       if(ammo>0)
       {
        ammo--;
        ammoScript.SetAmmo(ammo);
        onClick();
        // Check if the player has pressed the fire button and if enough time has elapsed since they last fired
            if ( Time.time > nextFire) 
            {
            // Update the time when our player can fire next
            nextFire = Time.time + fireRate;

                // Declare a raycast hit to store information about what our raycast has hit
                RaycastHit hit;

            // Set the start position for our visual effect for our laser to the position of gunEnd
            laserLine.SetPosition (0, laserOrigin.position);

            // Create a vector at the center of our camera's viewport
            Vector3 rayOrigin = fpsCam.ViewportToWorldPoint (new Vector3(0.5f, 0.5f, 0.0f));
            // Vector3 rayOrigin = fpsCam.transform.position;

            // Check if our raycast has hit anything
            if (Physics.Raycast (rayOrigin, fpsCam.transform.forward, out hit, gunRange))
            {
                // Set the end position for our laser line 
                laserLine.SetPosition (1, hit.transform.position);
                // Destroy(hit.transform.gameObject);
                // scoreManager.AddScore();
                Action(hit);
                gunAudio.Play ();
                onClickSound.Stop();
            }
              else
            {
              
                laserLine.SetPosition(1, rayOrigin + (fpsCam.transform.forward * gunRange));
            }

           // Start our ShotEffect coroutine to turn our laser line on and off
            StartCoroutine (ShotEffect(ammo));
            }
       }
        
        
      
        // ammo--;
       
    }


    private IEnumerator ShotEffect(float ammo)
    {
        if(ammo>0){
        // Play the shooting sound effect
         

        // Turn on our line renderer
        laserLine.enabled = true;

        //Wait for .07 seconds
        yield return shotDuration;

        // Deactivate our line renderer after waiting
        laserLine.enabled = false;
        }
    }
    private void Action(RaycastHit hit){
        if(sceneName=="GamePlay"){
            Destroy(hit.transform.gameObject);
                scoreManager.AddScore();
        }
        else if(sceneName=="GamePlayExtended"){
             float health = droneHealthScript.GetHealth();
             health-=10;
             droneHealthScript.SetHealth(health);
             if(health==0){
                Destroy(hit.transform.gameObject);
             }
             scoreManager.AddScore();
        }
    }
}


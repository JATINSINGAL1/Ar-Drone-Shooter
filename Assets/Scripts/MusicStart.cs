using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicStart : MonoBehaviour
{
    private HealthScript healthscript;
    private AudioSource BgMusic;
    private void Start() {
        healthscript=GameObject.Find("HealthBar").GetComponent<HealthScript>();
        BgMusic=GetComponent<AudioSource>();
    }
    
     public void Awake(){
        float health = healthscript.GetHealth();
        while(health>0){
            BgMusic.Play();
        }
    }
}

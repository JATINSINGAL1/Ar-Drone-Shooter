using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoScript : MonoBehaviour
{

 public Slider AmmoSlider;
public int MaxAmmo=10;
private AudioSource reloadAudio;
public void Awake(){
    AmmoSlider=GetComponent<Slider>();
}
public void Start(){
    SetAmmo(MaxAmmo);
    SetMaxAmmo(MaxAmmo);
    reloadAudio=GameObject.Find("EnergyBtn").GetComponent<AudioSource>();
}
public void SetMaxAmmo(int MaxAmmo)
    {
        AmmoSlider.maxValue = MaxAmmo;
        AmmoSlider.value = MaxAmmo;
    }
public void SetAmmo(float ammo)
    {
        AmmoSlider.value = ammo;
       
    }
public float GetAmmo()
    {
        return AmmoSlider.value;
    }
public void reload(){
    SetAmmo(MaxAmmo);
    reloadAudio.Play();
    
}
}

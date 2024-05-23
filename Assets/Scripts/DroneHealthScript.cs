using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DroneHealthScript : MonoBehaviour
{
   public Slider HealthSlider;
     int Maxhealth = 100;

    private void Start()
    {
        HealthSlider = GetComponent<Slider>();
        SetHealth(Maxhealth);
       
    }
    public void SetMaxHealth(int Maxhealth)
    {
        HealthSlider.maxValue = Maxhealth;
        HealthSlider.value = Maxhealth;
    }
    public void SetHealth(float health)
    {
        HealthSlider.value = health;
    }
    public float GetHealth()
    {
        return HealthSlider.value;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScript : MonoBehaviour
{
    [SerializeField] HealthScript healthScript;

    public void OnTriggerEnter(Collider collider){
       Destroy(collider.gameObject);
       float health = healthScript.GetHealth();
       health-=10;
       healthScript.SetHealth(health);
        Handheld.Vibrate();
    }
}

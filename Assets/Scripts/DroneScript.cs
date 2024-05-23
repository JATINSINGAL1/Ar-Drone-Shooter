using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DroneScript : MonoBehaviour
{
    
   

    private Transform target;
  
    public void Awake()
    {
        target = Camera.main.transform;
    }
     

    [System.Obsolete]
    public void Update()
    {
        
        float p = Random.RandomRange(2f, 5f)*Time.deltaTime;
       // Debug.Log(p);
     transform.position = Vector3.MoveTowards(transform.position, target.position, p);
    }
  
}

using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    // public GameObject bullets;
     private Transform target;
    //  private Transform dronePosition;
    //  private Transform anchor;
    //  Vector3 error= new Vector3()
  
    public void Awake()
    {
        target = Camera.main.transform;
    }
    private void Start(){
        // anchor = GameObject.Find("anchor").GetComponent<Transform>();
        // dronePosition=GameObject.Find("Drone").GetComponent<Transform>();
    }
     

    [System.Obsolete]
    public void Update()
    {
        
    //  if(anchor.rotation.y==0)
    // {
    //     Debug.Log("working");
    //     Instantiate(bullets, dronePosition.position,UnityEngine.Quaternion.identity);
    //            }
     float p = 0.3f;
       // Debug.Log(p);
     transform.position = UnityEngine.Vector3.MoveTowards(transform.position, target.position, p);
    }

    
}

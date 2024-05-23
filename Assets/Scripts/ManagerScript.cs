using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerScript : MonoBehaviour
{
    int ammo;
    public void Start()
    {
       ammo=100; 
    }
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            ammo--;
            shoot();
        }
    }
    void shoot(){

    }
}

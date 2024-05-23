using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheildScript : MonoBehaviour
{
    public float timeDelay=15f;
    public void ActivateSheild(){
          gameObject.SetActive(true);
          Invoke("DeactivateSheild",timeDelay);
    }
    public void DeactivateSheild(){
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision sheild) {
        Destroy(sheild.gameObject);
    }
}

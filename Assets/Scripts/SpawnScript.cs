using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnScript : MonoBehaviour
{ 
    public GameObject Drones;
    public GameObject bullets;
    public Transform[] spawnpoint;
    string currentScene;

    [System.Obsolete]
    public void Start()
    {
        currentScene=SceneManager.GetActiveScene().name;
        
        StartCoroutine(StartSpawning()); 
    }

    [System.Obsolete]
    IEnumerator StartSpawning()
    {
        
        if(currentScene=="GamePlay"){
            yield return new WaitForSeconds(5);
        int i = Random.RandomRange(0, 8);
            Instantiate(Drones, spawnpoint[i].position, Quaternion.identity);
            StartCoroutine(StartSpawning());
            }
        else if(currentScene=="GamePlayExtended"){
            yield return new WaitForSeconds(5);
            Instantiate(bullets,Drones.transform.position,Quaternion.identity);
            StartCoroutine(StartSpawning());
        }
        
    }
}

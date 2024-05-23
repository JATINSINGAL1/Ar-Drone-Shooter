using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class SceneChanger : MonoBehaviour
{
   public HealthScript healthScript;
   public DroneHealthScript droneHealthScript;
   private ScoreManager scoreManager;
   string currentSceneName;
   public GameObject level;
   public void OnStart(){
    SceneManager.LoadScene(1);
   }

   public void OnExit(){
      Application.Quit();
   }
   private void Start() {
       currentSceneName= SceneManager.GetActiveScene().name;
       scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
       Invoke("SetActive",1.3f);

   }
   private void Update() {
      if(healthScript.GetHealth()==0 || droneHealthScript.GetHealth()==0 ){
         SceneManager.LoadScene("ExitMenu");
      }
     if(currentSceneName=="GamePlay" ){
      
         if(scoreManager.GetScore()==5){
         SceneManager.LoadScene("GamePlayExtended");
      }
     }

     
   }
   void SetActive(){
      level.SetActive(false);
   }
}

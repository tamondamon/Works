using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class TutorialButton : MyButton
{
  void Start(){
    GetAudioSource();
  }

  void Update(){
    IncreaseCountTime();
  }

  void OnTriggerEnter(Collider other){
    Push(other);
    if(IsPush){
      //IsPushの初期化
      IsPush = false;
      //個々の処理を記述
      Invoke("LoadTutorial",1f);
    }
  }

  void LoadTutorial(){
    //シーンのロード
    SceneManager.LoadScene ("Tutorial");
  }
}

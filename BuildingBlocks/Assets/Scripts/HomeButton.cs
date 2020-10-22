using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeButton : MyButton
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
      Invoke("LoadHome",1f);
    }
  }

  void LoadHome(){
    //シーンのリロード
    SceneManager.LoadScene ("Menu");
  }
}

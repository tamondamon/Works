using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class RestartButton : MyButton
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
      Invoke("RestartScene",1f);
    }
  }

  void RestartScene(){
    //シーンのリロード
    SceneManager.LoadScene (SceneManager.GetActiveScene().name);
  }

}

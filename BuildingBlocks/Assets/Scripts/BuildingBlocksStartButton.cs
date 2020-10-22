using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
public class BuildingBlocksStartButton : MyButton
{
  public Countdown countdown;

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
      Invoke("BuildingBlocksStart",1f);
    }
  }

  void BuildingBlocksStart(){
    countdown.isStart = true;
    this.gameObject.SetActive(false);
  }
}

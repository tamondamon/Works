using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpButton : MyButton
{
  public bool isJump = false;
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
      isJump = true;
    }
  }
}

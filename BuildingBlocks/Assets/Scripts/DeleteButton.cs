using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteButton : MyButton
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
      GameObject[] cubes = GameObject.FindGameObjectsWithTag ("Cube");
      for(int i = 0; i<cubes.Length;i++){
        Destroy(cubes[i],0.5f);
      }
    }
  }
}

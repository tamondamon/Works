using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyButton : MonoBehaviour
{
  public AudioClip ButtonSound;
  private AudioSource audioSource;
  public float CountTime = 3;
  public bool IsPush = false;

  //AudioSourceの取得
  public void GetAudioSource()
  {
    audioSource = GetComponent<AudioSource>();
  }


  //ボタンの連続押しを防ぐ
  public void IncreaseCountTime(){
    if(CountTime <=2){
      CountTime += Time.deltaTime;
    }
  }

  public void Push(Collider other)
  {
    //ボタンと手が触れているかどうかの判定
    if(other.gameObject.name.StartsWith("Hand") && CountTime > 2){
      //音の再生
      audioSource.PlayOneShot(ButtonSound);
      CountTime = 0;
      IsPush = true;
    }
  }

}

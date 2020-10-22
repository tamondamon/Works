using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountTime : MonoBehaviour
{
  public float TimeLimit;
  public GameObject TimeText;
  public AudioClip TimeupSound;
  public AudioSource BgmAudioSource;
  private AudioSource audioSource;
  private bool isFadeOut = false;
  private bool sound = false;
  public float FadeOutSeconds;
  private float FadeDeltaTime;

  void Start(){
    audioSource = GetComponent<AudioSource>();
  }

    // Update is called once per frame
    void Update()
    {
      //制限時間が切れた場合
      if(TimeLimit < 0 ){
        TimeText.GetComponent<TextMesh>().text = "Finish!";
        isFadeOut = true;
      }else{
        //制限時間の表示
        TimeLimit -= Time.deltaTime;
        TimeText.GetComponent<TextMesh>().text = "Time Limit : " + TimeLimit.ToString("f2");
      }

      if(TimeLimit <= 3 && !sound){
        //音の再生
        audioSource.PlayOneShot(TimeupSound);
        sound = true;
      }

      if (isFadeOut)
       {
            FadeDeltaTime += Time.deltaTime;
            if (FadeDeltaTime >= FadeOutSeconds)
            {
                FadeDeltaTime = FadeOutSeconds;
                isFadeOut = false;
            }
            BgmAudioSource.volume = (float)(0.35 - FadeDeltaTime / FadeOutSeconds);
        }
    }
}

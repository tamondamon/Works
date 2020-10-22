using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Countdown : MonoBehaviour
{
  public GameObject CountTime;
  public AudioClip CountdownSound;
  public AudioSource BgmAudioSource;
  private AudioSource audioSource;
  private int _startCountdown = 5;
  private bool sound = false;
  private bool setActive = false;
  private float _time = 0;
  public bool isStart = false;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
      /*
      //時間計測
      _time += Time.deltaTime;

      if(_time >  _startCountdown && !sound){
        //カウントダウン開始
        audioSource.PlayOneShot(CountdownSound);
        sound = true;
      }else if(_time > _startCountdown+3 && !setActive){
        //制限時間の表示
        CountTime.SetActive(true);
        BgmAudioSource.Play();
        setActive = true;
      }
      */

      if(isStart){
        _time += Time.deltaTime;
        if(!sound){
          audioSource.PlayOneShot(CountdownSound);
          sound = true;
        }

        if(_time > 3 && !setActive){
          //制限時間の表示
          CountTime.SetActive(true);
          BgmAudioSource.Play();
          setActive = true;
        }
      }

      Debug.Log(_time);
    }
}

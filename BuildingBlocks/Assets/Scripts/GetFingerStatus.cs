using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetFingerStatus : MonoBehaviour
{
    public OVRSkeleton R_skeleton;
    public OVRSkeleton L_skeleton;
    public OVRHand R_hand;
    public OVRHand L_hand;
    public GameObject Menu;
    public Transform HeadTransform;
    private int isMenu = 0;
    public AudioClip menu;
    public AudioClip close;
    private AudioSource audioSource;


    void Start(){
      audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
      //右手がこちらを向いているか
      if(R_hand.IsSystemGestureInProgress && isMenu == 0){
        //メニューの表示
        Menu.SetActive(true);
        Menu.transform.position = R_hand.transform.position + new Vector3(0,0.4f,0);
        //表示角度調整
        Menu.transform.LookAt(HeadTransform);
        //音の再生
        audioSource.PlayOneShot(menu);
        isMenu = 1;
      }else if(!R_hand.IsSystemGestureInProgress && isMenu == 1){
        isMenu = 2;
      }else if(R_hand.IsSystemGestureInProgress && isMenu == 2){
        //メニューの非表示
        Menu.SetActive(false);
        //音の再生
        audioSource.PlayOneShot(close);
        isMenu = 3;
      }else if(!R_hand.IsSystemGestureInProgress && isMenu == 3){
        isMenu = 0;
      }


    }
}

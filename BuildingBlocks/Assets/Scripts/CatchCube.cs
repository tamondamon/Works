using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchCube : MonoBehaviour
{
  public GetFingerStatus getFingerStatus;
  public bool isTouch;
  private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
      GameObject obj = GameObject.Find("GetFingerStatus");
      getFingerStatus = obj.GetComponent<GetFingerStatus>();
      rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
      //cubeに触れており、それが右手中指だった時
      if(isTouch && getFingerStatus.R_hand.GetFingerIsPinching(OVRHand.HandFinger.Middle)){
        Catch(getFingerStatus.R_skeleton.Bones[(int) OVRSkeleton.BoneId.Hand_ThumbTip].Transform);
      //cubeに触れており、それが左手中指だった時
      }else if(isTouch && getFingerStatus.L_hand.GetFingerIsPinching(OVRHand.HandFinger.Middle)){
        Catch(getFingerStatus.L_skeleton.Bones[(int) OVRSkeleton.BoneId.Hand_ThumbTip].Transform);
      //cubeに触れていない時
      }else{
        //rigidbodyの際動作
        rb.isKinematic = false;
        //親オブジェクトの初期化
        this.gameObject.transform.parent = null;
      }

    }

    void OnCollisionStay(Collision other){
      //cubeと手が触れているかどうかの判定
      if(other.gameObject.name.StartsWith("Hand")){
        isTouch = true;
      }else{
        isTouch = false;
      }
    }

    void Catch(Transform parent){
      //rigidbodyの停止
      rb.isKinematic = true;
      //cubeを触れている手の子オブジェクトにする
      this.gameObject.transform.parent = parent;
    }
}

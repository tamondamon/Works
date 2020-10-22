using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCube : MonoBehaviour
{
  public GameObject cube;
  public OVRHand rightHand;
  public OVRHand leftHand;
  public OVRSkeleton rightHandSkeleton;
  public OVRSkeleton leftHandSkeleton;
  private GameObject _cube;
  public bool isCreate = false;

    // Update is called once per frame
    void Update()
    {
      //右手と左手が人差し指と親指を合わせており、cubeを生成中でない時
      if(rightHand.GetFingerIsPinching(OVRHand.HandFinger.Index) && leftHand.GetFingerIsPinching(OVRHand.HandFinger.Index) && !isCreate){
        //cubeを生成
        InstantiateCube();
      }

    }

    void InstantiateCube(){
      //cube生成中
      isCreate = true;
      //生成するcubeの位置を右手と左手の中間点とする
      Vector3 cubePosition = (rightHandSkeleton.Bones[(int) OVRSkeleton.BoneId.Hand_IndexTip].Transform.position + leftHandSkeleton.Bones[(int) OVRSkeleton.BoneId.Hand_IndexTip].Transform.position)/2;
      //プレハブからcube生成
      Instantiate(cube, cubePosition , Quaternion.identity);
      //cubeの大きさはResizeCubeで行う
    }

}

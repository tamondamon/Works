using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResizeCube : MonoBehaviour
{
  public CreateCube createCube;
  private Rigidbody rb;
  public AudioClip sound1;
  private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
      GameObject obj = GameObject.Find("CreateCube");
      createCube = obj.GetComponent<CreateCube>();
      rb = GetComponent<Rigidbody>();
      audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
      //CreateCubeでcubeが生成中の時
      if(createCube.rightHand.GetFingerIsPinching(OVRHand.HandFinger.Index) && createCube.leftHand.GetFingerIsPinching(OVRHand.HandFinger.Index) && createCube.isCreate){
        //cubeのrigidbodyを
        rb.isKinematic = true;
        //左手と右手の位置からcubeの大きさの計算
        float RhandX = createCube.rightHandSkeleton.Bones[(int) OVRSkeleton.BoneId.Hand_IndexTip].Transform.position.x;
        float RhandZ = createCube.rightHandSkeleton.Bones[(int) OVRSkeleton.BoneId.Hand_IndexTip].Transform.position.z;
        float LhandX = createCube.leftHandSkeleton.Bones[(int) OVRSkeleton.BoneId.Hand_IndexTip].Transform.position.x;
        float LhandZ = createCube.leftHandSkeleton.Bones[(int) OVRSkeleton.BoneId.Hand_IndexTip].Transform.position.z;
        float handsDistance = Mathf.Sqrt((RhandX-LhandX)*(RhandX-LhandX) + (RhandZ-LhandZ)*(RhandZ-LhandZ))/2;
        //箱の大きさを変更
        this.transform.localScale = new Vector3(handsDistance,handsDistance,handsDistance);

      //cubeの生成が終了した時
      }else{
        //rigidbodyの再動作
        rb.isKinematic = false;
        createCube.isCreate = false;
        //cubeの大きさ変更不可化
        GetComponent<ResizeCube>().enabled = false;
        //cubeを摘めるようにする
        GetComponent<CatchCube>().enabled = true;
        //cubeの高さ取得開始
        GetComponent<GetHeight>().enabled = true;
        //音の再生
        audioSource.PlayOneShot(sound1);
      }
    }
}

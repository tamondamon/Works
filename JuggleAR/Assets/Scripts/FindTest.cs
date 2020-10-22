using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FindTest : MonoBehaviour
{
    public Text text;

    void Update(){
      if(GameObject.Find("RightToss") != null){
        text.text="Right Find!";
      }else{
        text.text="Not find ...";
      }
    }
}

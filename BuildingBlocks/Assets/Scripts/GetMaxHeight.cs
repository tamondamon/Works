using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetMaxHeight : MonoBehaviour
{
    public float MaxHeight = 0;
    public GameObject HeightText;
    public CountTime countTime;

    void Update()
    {
      //制限時間の判定
      if(countTime.TimeLimit >= 0){
        //高さを小数点第２位まで表示
        HeightText.GetComponent<TextMesh>().text = "Record : " + (MaxHeight*100).ToString("f2") + " cm";
      }
    }
}

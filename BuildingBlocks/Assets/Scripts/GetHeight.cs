using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetHeight : MonoBehaviour
{
    private Rigidbody _rigidbody;
    public GetMaxHeight getMaxHeight;
    private const float TableHeight = 0.6f;
    // Start is called before the first frame update
    void Start()
    {
      GameObject obj = GameObject.Find("GetMaxHeight");
      getMaxHeight = obj.GetComponent<GetMaxHeight>();
      _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if(_rigidbody.IsSleeping() && this.transform.position.y + this.transform.localScale.y/2 - TableHeight > getMaxHeight.MaxHeight ){
          //机の高さ分補正して計算
          getMaxHeight.MaxHeight = this.transform.position.y + this.transform.localScale.y/2 - TableHeight;
        }
    }
}

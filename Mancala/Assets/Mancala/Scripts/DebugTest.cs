using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine("Main");
    }

    void Update()
    {
      if (Input.GetKeyDown("f"))
      {
        StartCoroutine("Test");
      }
    }

    IEnumerator Test(){
      int i = 0;
      yield return null;
      Debug.Log(i);
      yield return null;
    }
}

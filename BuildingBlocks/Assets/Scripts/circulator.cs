﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circulator : MonoBehaviour
{
  public Transform WindCenter;
  public Transform[] Wing = new Transform[5];
  public float RotateWind;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      for (int i = 0;i<5;i++){
        Wing[i].RotateAround(WindCenter.position,Vector3.forward,RotateWind*Time.deltaTime);
      }
    }
}

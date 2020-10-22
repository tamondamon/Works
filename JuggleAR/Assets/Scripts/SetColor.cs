using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetColor : MonoBehaviour
{
  public Material BallMaterial;

  // Use this for initialization
  void Start () {
    DontDestroyOnLoad (this);
  }
  
  public void SetMaterial(Material value){
    BallMaterial = value;
  }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleBGM : MonoBehaviour
{
  private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
      audioSource = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StopMusic(){
      audioSource.Stop();
    }
}

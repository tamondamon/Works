using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
  public GameController game;
    // Start is called before the first frame update
    void Start()
    {
      GameObject obj = GameObject.Find("GameController");
      game = obj.GetComponent<GameController>();
    }


}

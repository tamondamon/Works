using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneController : MonoBehaviour
{
  public GameController gameController;
  public GameObject Stone;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DeleteStone(){
      var obj = GameObject.FindGameObjectsWithTag("Stone");

      for(int i = 0; i < obj.Length ; i++){
        Destroy(obj[i]);
      }
    }

    public void SetStone(bool Mine,int Pocket,int num){
      Vector3 pocketPosition = new Vector3(0,0,-1);

      switch(Pocket){
        case 0:
          pocketPosition.x = -3;
          break;
        case 1:
          pocketPosition.x = 0;
          break;
        case 2:
          pocketPosition.x = 3;
          break;
        case 3:
          pocketPosition.x = 7;
          break;
      }
      if(!Mine) pocketPosition *= -1;


      for(int i = 0;i<num;i++){
        if(pocketPosition.z > 0) pocketPosition.z += 0.2f;
        else pocketPosition.z -= 0.2f;
         Instantiate(Stone, pocketPosition, Quaternion.identity);
      }

    }
}

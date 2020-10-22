using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastWind : MonoBehaviour
{
    [SerializeField]
    private CharacterController _playerCharacter;
    private RaycastHit hit;
    public float WindForce;
    public float WindDistance;
    // Update is called once per frame
    void Update()
    {

      if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, WindDistance))
      {
        if(hit.collider.name == "unitychan"){
          _playerCharacter.Move(this.transform.forward*WindForce);
          Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
        }
      }else{
         Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
      }
    }
}

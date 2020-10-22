using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
  //周期
  public float _cycle;
  public Vector3 StartPosition;
  public Vector3 EndPosition;
  public Vector3 NextPosition;
  public float HoldTime;

  //経過時間
  private float _elapsedTime;
  //2点間の距離
  private float _xDistance;
  private float _zDistance;
  private Vector3 _currentPosition;
  private float Gravity;

  private float _moveHandTime;

  // Start is called before the first frame update
  public void Start()
  {
    _elapsedTime = 0;
    _moveHandTime = 0;
    _xDistance = EndPosition.x - StartPosition.x;
    _zDistance = EndPosition.z - StartPosition.z;
    _currentPosition = StartPosition;
    Gravity = 10;
  }

  // Update is called once per frame
  void Update()
  {
    _elapsedTime += Time.deltaTime;

    if(_elapsedTime <= _cycle){
      //x軸について
      _currentPosition.x =  StartPosition.x + (_xDistance*_elapsedTime)/_cycle;

      //z軸について
      _currentPosition.z =  StartPosition.z + (_zDistance*_elapsedTime)/_cycle;

      //y軸について
      _currentPosition.y = StartPosition.y + (Gravity*_cycle*_elapsedTime)/2 - Gravity *_elapsedTime*_elapsedTime/2;

      this.transform.position = _currentPosition;
    }else{
      //トス位置にボールを移動
      _moveHandTime += Time.deltaTime;
      // 円弧の中心
      Vector3 center = (EndPosition+ NextPosition)/2;

      // 中心を少し移動
      center += new Vector3(0, 1, 0);

      // 円弧との相対位置
      Vector3 endRelCenter = EndPosition  - center;
      Vector3 nextRelCenter = NextPosition - center;

      //球面補間
      transform.position = Vector3.Slerp(endRelCenter, nextRelCenter, _moveHandTime/HoldTime);
      transform.position += center;
    }

  }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//定数のクラス
static class Constants
{
    public const float BallNumber_CycleRatio= 0.3f;
    public const float HoldTime = 0.2f;
}

public class BallController : MonoBehaviour
{
    private int[] Siteswap;
    private int _ballNumber;
    public GameObject BallPrefab;
    private GameObject[] _balls;
    //手の位置
    private Vector3 RightToss;
    private Vector3 RightCatch;
    private Vector3 LeftToss;
    private Vector3 LeftCatch;
    //変数受け渡し用スクリプト
    private Ball ball;
    public CheckSiteswap checkSiteswap;
    public SetColor setcolor;

    //ボールを投げるタイミング
    private float _tossTiming;
    private int[] _countTiming;
    //時間計測用
    private float _time = 0;
    private bool _startRightHand;
    private float _baseCycle;
    private int _countSiteswap = 0;

    void Start()
    {
      GameObject obj = GameObject.Find ("CheckSiteswap");
      checkSiteswap = obj.GetComponent<CheckSiteswap>();
      obj = GameObject.Find ("SetColor");
      setcolor = obj.GetComponent<SetColor>();
      _ballNumber = checkSiteswap.BallNumber;
      _baseCycle = _ballNumber * Constants.BallNumber_CycleRatio;
      _tossTiming = _baseCycle/(float)_ballNumber;
      _balls = new GameObject[_ballNumber];
      _countTiming = new int[_ballNumber];

      //サイトスワップ引継ぎ
      Siteswap = new int[checkSiteswap.Siteswap.Length];
      for(int i = 0; i<Siteswap.Length ; i++){
        Siteswap[i] = checkSiteswap.Siteswap[i];
      }

      //ボールを個数分生成
      for(int i=0; i< _ballNumber;i++){
        _balls[i] = Instantiate(BallPrefab, Vector3.zero , Quaternion.identity);
        //マテリアルの変更
        _balls[i].GetComponent<Renderer>().material = setcolor.BallMaterial;
        _countTiming[i] = i+1;
        //_countTiming[i] = Siteswap[i%Siteswap.Length];
      }
    }

    void Update()
    {
      //トス位置、キャッチ位置の指定
      GameObject obj  = GameObject.Find("RightToss");
      RightToss = obj.transform.position;
      obj  = GameObject.Find("RightCatch");
      RightCatch = obj.transform.position;
      obj  = GameObject.Find("LeftToss");
      LeftToss = obj.transform.position;
      obj  = GameObject.Find("LeftCatch");
      LeftCatch = obj.transform.position;

      _time += Time.deltaTime;

      //ボールを投げる時
      if(_time > _tossTiming){

        //投げるボールの決定
        var _tossBall = DecideTossBall();
        ball = _balls[_tossBall].GetComponent<Ball>();

        //サイトスワップの代入
        //0の場合が未対応
        _countTiming[_tossBall] =  Siteswap[_countSiteswap];

        //ボールの投げる高さ取得
        DecideHeight();

        //ボールの投げる手を取得
        DecideHand();

        //初期化
        ball.Start();

        //サイトスワップを読み込む
        _countSiteswap++;
        if(_countSiteswap >= Siteswap.Length){
          _countSiteswap = 0;
        }
        _time = 0;
      }

    }

    //投げるボールの決定
    int DecideTossBall(){
      int zeroNumber = 0;

      for(int i = 0 ;i  < _ballNumber ; i++){
        _countTiming[i] -= 1;
        if(_countTiming[i] == 0) zeroNumber = i;
      }
      return zeroNumber;
    }


    //ボールを投げる高さをサイトスワップから変更
    void DecideHeight(){
      if(Siteswap[_countSiteswap] == 1){
        ball._cycle = 1/(float)_ballNumber - Constants.HoldTime;
      }else{
        //要調整
        var cycle = (float)Siteswap[_countSiteswap] * Constants.BallNumber_CycleRatio - Constants.HoldTime;
        ball._cycle = cycle ;
      }
    }


    //ボールのトス手、キャッチ手の設定
    void DecideHand(){
      //右手の時
      if(_startRightHand){
        //奇数軌道の時
        if((Siteswap[_countSiteswap] % 2 )== 1){
          ball.StartPosition = RightToss;
          ball.EndPosition = LeftCatch;
          ball.NextPosition = LeftToss;
        //偶数軌道の時
        }else{
          ball.StartPosition = RightToss;
          ball.EndPosition = RightCatch;
          ball.NextPosition = RightToss;
        }

      //左手の時
      }else{
        //奇数軌道の時
        if((Siteswap[_countSiteswap] % 2 )== 1){
          ball.StartPosition = LeftToss;
          ball.EndPosition = RightCatch;
          ball.NextPosition = RightToss;
        //偶数軌道の時
        }else{
          ball.StartPosition = LeftToss;
          ball.EndPosition =  LeftCatch;
          ball.NextPosition = LeftToss;
        }
      }

      ball.HoldTime = Constants.HoldTime;

      //手を逆にする
      _startRightHand = !_startRightHand;

    }
}

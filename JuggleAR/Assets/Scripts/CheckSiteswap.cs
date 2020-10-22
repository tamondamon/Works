using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckSiteswap : MonoBehaviour
{
    public string StringSiteswap;
    public int[] Siteswap;
    public int BallNumber;
    private int _siteswapSum;

    // Use this for initialization
  	void Start () {
  		DontDestroyOnLoad (this);
  	}

    public int Convert(){
      _siteswapSum = 0;
      Siteswap = new int[StringSiteswap.Length];

      //入力を数値に変換
      for(int i = 0;i < StringSiteswap.Length  ; i++){
        if( (int)StringSiteswap[i] >= (int)'0' && (int)StringSiteswap[i] <= (int)'9' )
        {
          Siteswap[i] = (int)StringSiteswap[i] - (int)'0';
        }else{
          Siteswap[i] = (int)StringSiteswap[i] - (int)'a'+10;
        }
        _siteswapSum += Siteswap[i];
      }

      BallNumber = _siteswapSum/StringSiteswap.Length;

      return Check();
    }

    public int Check(){
      /*
      n列のサイトスワップ a0 a1 ... an に対して 0<=i,j<=n を満たす i、jに対し
      (ai + i) と (aj + j) が mod n+1 について合同でない
      */
      for(int i = 0 ; i < StringSiteswap.Length ; i++){
        for(int j = i ; j < StringSiteswap.Length ; j++){
          if (i != j && ((Siteswap[i] + i) % StringSiteswap.Length) == ((Siteswap[j] + j) % StringSiteswap.Length)) {
            //  Unjugglable
            return (0);
          }
        }
      }

      return 1;
    }

}

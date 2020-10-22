using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class TrainerConstants{
  public const int POCKETNUMBER = 4;
}

public class ControllerForTraining : MonoBehaviour
{
  public StoneController stoneController;
  public int[] PlayerA = new int[TrainerConstants.POCKETNUMBER];
  public int[] PlayerB  = new int[TrainerConstants.POCKETNUMBER];
  public bool PlayerATurn;
  public int Pocket;
  public GameObject EndUI;
  public Button[] MyButton = new Button[3];
  public Button[] PlayerBButton = new Button[3];
  public Text EndText;
  public Text TurnText;

  public MancalaAgent mancalaAgentA;
  public MancalaAgent mancalaAgentB;


  // 初期設定
  void Start()
  {
    //全てのポケットに3個づつ石を入れる
    for(int i = 0; i<TrainerConstants.POCKETNUMBER-1 ; i++){
      PlayerA[i] = 3;
      PlayerB[i] = 3;
    }

    PlayerA[TrainerConstants.POCKETNUMBER-1] = 0;
    PlayerB[TrainerConstants.POCKETNUMBER-1] = 0;

    //手番を決める
    int value = Random.Range(0,10);
    if(value % 2 == 0){
      PlayerATurn = true;
    }else{
      PlayerATurn = false;
    }

    //ゲームの開始
    StartCoroutine("StartGame");
  }

  //メイン処理
  IEnumerator StartGame(){
    bool PlayerAWin = false;
    bool PlayerBWin = false;

    //どちらかが勝つまで続ける
    while(!PlayerAWin && !PlayerBWin){
      //ターンの変更
      ChangeTurn();
      Pocket = -1;

      //入力待ち
      while(Pocket == -1){
        yield return null;
      }
      yield return null;

      //石の移動
      MoveStone(PlayerATurn);

      //stoneController.DeleteStone();

      //石の設置(for debug)
      /*
      for(int i = 0 ; i < TrainerConstants.POCKETNUMBER ; i++){
        if(PlayerATurn){
          stoneController.SetStone(PlayerATurn,i,PlayerA[i]);
          stoneController.SetStone(!PlayerATurn,i,PlayerB[i]);
        }else{
          stoneController.SetStone(!PlayerATurn,i,PlayerA[i]);
          stoneController.SetStone(PlayerATurn,i,PlayerB[i]);
        }
      }
      */

      PlayerAWin = true;
      PlayerBWin = true;

      //勝利の判定
      for(int pocketNum = 0; pocketNum < TrainerConstants.POCKETNUMBER-1; pocketNum++){
        if(PlayerA[pocketNum] != 0) PlayerAWin = false;
        if(PlayerB[pocketNum] != 0) PlayerBWin = false;
      }

      /*
      Debug.Log("PlayerA : " + PlayerA[0] + ","+PlayerA[1]+","+PlayerA[2]);
      Debug.Log("PlayerB : " + PlayerB[0] + ","+PlayerB[1]+","+PlayerB[2]);
      */

    }

    //勝者の決定
    if(PlayerAWin){
      EndGame("PlayerA");
    }else if(PlayerBWin){
      EndGame("PlayerB");
    }

  }

  void MoveStone(bool myturn){
    int stoneNum;
    int i = Pocket + 1;

    //どちらのターンか
    if(myturn){
      stoneNum = PlayerA[Pocket];
      PlayerA[Pocket] = 0;
    } else {
      stoneNum = PlayerB[Pocket];
      PlayerB[Pocket] = 0;
    }

    //石の移動
    while(stoneNum > 0){
      //石を増やす
      if(myturn) PlayerA[i]++;
      else PlayerB[i]++;

      stoneNum--;
      i++;
      //どちらかのフィールドに石を埋め切った時
      if(i > TrainerConstants.POCKETNUMBER-1){
        myturn = !myturn;
        i=0;
      }
    }
  }

  // Update is called once per frame
  void ChangeTurn()
  {
    PlayerATurn = !PlayerATurn;

    //ボタンの表示・非表示
    /*
    if(PlayerATurn){
      for(int i = 0;i < TrainerConstants.POCKETNUMBER-1 ; i++){
        MyButton[i].interactable = true;
        PlayerBButton[i].interactable = false;
        TurnText.text = "あなたの番です";
      }
    }else{
      for(int i = 0;i < TrainerConstants.POCKETNUMBER-1 ; i++){
        MyButton[i].interactable = false;
        PlayerBButton[i].interactable = true;
        TurnText.text = "相手の番です";
      }
    }
    */

  }

  void EndGame(string winner){

    //EndUI.SetActive(true);
    EndText.text = winner + "の勝ちです!";
    Debug.Log(winner + "win");

    Reset();
  }

  public void Reset(){
    //
    if(PlayerATurn){
      mancalaAgentA.SetReward(1);
      mancalaAgentB.SetReward(-1);
    }else{
      mancalaAgentA.SetReward(-1);
      mancalaAgentB.SetReward(1);
    }

    mancalaAgentA.EndEpisode();
    mancalaAgentB.EndEpisode();

    Start();
  }

}

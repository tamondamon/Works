using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class Constants{
  public const int POCKETNUMBER = 4;
}

public class GameController : MonoBehaviour
{
    public StoneController stoneController;
    public int[] Player = new int[Constants.POCKETNUMBER];
    public int[] Enemy = new int[Constants.POCKETNUMBER];
    public bool MyTurn;
    public int Pocket;
    public GameObject EndUI;
    public Button[] MyButton = new Button[3];
    public Button[] EnemyButton = new Button[3];
    public Text EndText;
    public Text TurnText;

    // 初期設定
    void Start()
    {
      //全てのポケットに3個づつ石を入れる
      for(int i = 0; i<Constants.POCKETNUMBER-1 ; i++){
        Player[i] = 3;
        Enemy[i] = 3;
      }

      //手番を決める
      int value = Random.Range(0,10);
      if(value % 2 == 0){
        MyTurn = true;
      }else{
        MyTurn = false;
      }

      //ゲームの開始
      StartCoroutine("StartGame");
    }

    //メイン処理
    IEnumerator StartGame(){
      bool PlayerWin = false;
      bool EnemyWin = false;

      //どちらかが勝つまで続ける
      while(!PlayerWin && !EnemyWin){
        //ターンの変更
        ChangeTurn();
        Pocket = -1;

        //入力待ち
        while(Pocket == -1){
           yield return null;
        }
        yield return null;

        //石の移動
        MoveStone(MyTurn);

        stoneController.DeleteStone();

        //石の設置
        for(int i = 0 ; i < Constants.POCKETNUMBER ; i++){
          if(MyTurn){
            stoneController.SetStone(MyTurn,i,Player[i]);
            stoneController.SetStone(!MyTurn,i,Enemy[i]);
          }else{
            stoneController.SetStone(!MyTurn,i,Player[i]);
            stoneController.SetStone(MyTurn,i,Enemy[i]);
          }
        }

        PlayerWin = true;
        EnemyWin = true;
        //勝利の判定
        for(int pocketNum = 0; pocketNum < Constants.POCKETNUMBER-1; pocketNum++){
          if(Player[pocketNum] != 0) PlayerWin = false;
          if(Enemy[pocketNum] != 0) EnemyWin = false;
        }

      }

      //勝者の決定
      if(PlayerWin){
        EndGame("あなた");
      }else if(EnemyWin){
        EndGame("相手");
      }
    }

    void MoveStone(bool myturn){
      int stoneNum;
      int i = Pocket + 1;

      //どちらのターンか
      if(myturn){
        stoneNum = Player[Pocket];
        Player[Pocket] = 0;
      } else {
        stoneNum = Enemy[Pocket];
        Enemy[Pocket] = 0;
      }

      //石の移動
      while(stoneNum > 0){
        //石を増やす
        if(myturn) Player[i]++;
        else Enemy[i]++;

        stoneNum--;
        i++;
        //どちらかのフィールドに石を埋め切った時
        if(i > Constants.POCKETNUMBER-1){
          myturn = !myturn;
          i=0;
        }
      }
    }

    // Update is called once per frame
    void ChangeTurn()
    {
      MyTurn = !MyTurn;

      //ボタンの表示・非表示
      if(MyTurn){
        for(int i = 0;i < Constants.POCKETNUMBER-1 ; i++){
          /*
          MyButton[i].SetActive(true);
          EnemyButton[i].SetActive(false);
          */
          MyButton[i].interactable = true;
          EnemyButton[i].interactable = false;
          TurnText.text = "あなたの番です";
        }
      }else{
        for(int i = 0;i < Constants.POCKETNUMBER-1 ; i++){
          /*
          MyButton[i].SetActive(false);
          EnemyButton[i].SetActive(true);
          */
          MyButton[i].interactable = false;
          EnemyButton[i].interactable = true;
          TurnText.text = "相手の番です";
        }
      }

    }

    void EndGame(string winner){

      EndUI.SetActive(true);
      EndText.text = winner + "の勝ちです!";
      Debug.Log(winner + "win");
    }
}

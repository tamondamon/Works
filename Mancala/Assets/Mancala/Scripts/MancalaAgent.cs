using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAgents;
using MLAgents.Sensors;

public class MancalaAgent :  Agent
{
    public GameControllerForAI controllerForTraining;
    public bool isPlayerA;
    // Start is called before the first frame update
    void Start()
    {

    }

    //エピソードスタート時の設定
    public override void OnEpisodeBegin()
    {

    }

    //与えるパラメータ
    public override void CollectObservations(VectorSensor sensor)
    {
      for(int i = 0; i < controllerForTraining.PlayerA.Length - 1;i++){
        //相手と自分の盤面
        sensor.AddObservation(controllerForTraining.PlayerA[i]);
        sensor.AddObservation(controllerForTraining.PlayerB[i]);
      }
    }

    //アクションと報酬
    public override void OnActionReceived(float[] vectorAction)
    {
      /*
      //Aのターン
      if(isPlayerA && controllerForTraining.PlayerATurn && controllerForTraining.Pocket == -1){
        controllerForTraining.Pocket = (int)vectorAction[0];
      //Bのターン
      }else if(!isPlayerA && !controllerForTraining.PlayerATurn  && controllerForTraining.Pocket == -1){
        controllerForTraining.Pocket = (int)vectorAction[0];
      }
      */
      //Bのターン
      if(!isPlayerA && !controllerForTraining.PlayerATurn  && controllerForTraining.Pocket == -1){
        controllerForTraining.Pocket = (int)vectorAction[0];
      }




    }

    // 方向キーで行動を決定
    public override void Heuristic(float[] actionsOut){
      if(Input.GetKeyDown(KeyCode.A)){
           actionsOut[0] = 0;
           controllerForTraining.Pocket = 0;
      }
      if(Input.GetKeyDown(KeyCode.S)){
           actionsOut[0] = 1;
           controllerForTraining.Pocket = 1;
      }
      if(Input.GetKeyDown(KeyCode.D)){
           actionsOut[0] = 2;
           controllerForTraining.Pocket = 2;
      }
    }

}

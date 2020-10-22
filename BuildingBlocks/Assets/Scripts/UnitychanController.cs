using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitychanController : MonoBehaviour
{
  private Vector3 MoveDirection = Vector3.zero;
  private bool isFinish = false;
  [SerializeField]
  private float Speed;
  [SerializeField]
  private float JumpSpeed;
  [SerializeField]
  public float Gravity;

  public StartButton startButton;
  public JumpButton jumpButton;
  public ClearStage clearStage;
  private CharacterController _character;
  private Animator _animator;

  // Start is called before the first frame update
  void Start()
  {
    _character = GetComponent<CharacterController>();
    _animator = GetComponent<Animator>();
  }

  // Update is called once per frame
  void Update()
  {
    //スタートボタンが押された時
    if(startButton.isStart && !isFinish){
      _animator.SetBool("isRun",true);
      MoveDirection.x = -Speed;
    }else if(isFinish){
      MoveDirection = Vector3.zero;
    }

    //ジャンプボタンが押された時
    if(jumpButton.isJump && CheckIsGrounded()){
      MoveDirection.y = JumpSpeed;
      jumpButton.isJump = false;
    }else if(!CheckIsGrounded()){
      //重力の適用
      //MoveDirection.y -= Gravity * Time.deltaTime;
    }

    // for Debug
    //スタートボタンが押された時
    if(Input.GetKeyDown(KeyCode.Mouse0)){
      _animator.SetBool("isRun",true);
      MoveDirection.x = -Speed;
    }

    //ジャンプボタンが押された時
    if(Input.GetButton("Jump") && CheckIsGrounded() ){
      MoveDirection.y = JumpSpeed;
      jumpButton.isJump = false;
    }else if(!CheckIsGrounded()){
    //重力の適用
      MoveDirection.y -= Gravity * Time.deltaTime;
    }


    //キャラクターの移動
    _character.Move(MoveDirection*Time.deltaTime);
    //_character.Move(transform.forward*Speed*Time.deltaTime);
  }

  //接地判定
  bool CheckIsGrounded(){
    if (_character.isGrounded) {
      return true;
    }else{
      var targetPosition = this.transform.position - new Vector3(0,0.05f,0);
      return Physics.Linecast(this.transform.position, targetPosition);
    }
  }

  //ゴールについた時
  void OnTriggerEnter(Collider other){
    if(other.gameObject.tag == "Finish"){
      _animator.SetBool("isFinish",true);
      isFinish = true;
      clearStage.Clear();
    }
  }

}

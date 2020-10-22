using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    public GameControllerForAI gameController;
    public int MyButton;
    public bool Mine;
    public Text NumText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      if(Mine) NumText.text = gameController.PlayerA[MyButton].ToString();
      else NumText.text = gameController.PlayerB[MyButton].ToString();
    }

    public void OnClick(){
      gameController.Pocket = MyButton;
    }
}

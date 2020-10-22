using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TryButton : MonoBehaviour
{
    public InputField inputField;
    public CheckSiteswap checkSiteswap;
    public GameObject InvalidText;

    // ボタンが押された場合、今回呼び出される関数
    public void OnClick()
    {
      checkSiteswap.StringSiteswap = inputField.text;
      int isJugglable = checkSiteswap.Convert();

      if(isJugglable == 1){
        SceneManager.LoadScene("HumanBodyTracking3D");
      }else if(isJugglable == 0){
        InvalidText.SetActive(true);
      }
      Debug.Log(isJugglable);
    }
}

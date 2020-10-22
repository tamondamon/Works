using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Back : MonoBehaviour
{

  // ボタンが押された場合、今回呼び出される関数
  public void OnClick()
  {
    GameObject obj1 = GameObject.Find ("CheckSiteswap");
    GameObject obj2 = GameObject.Find ("SetColor");
    Destroy(obj1);
    Destroy(obj2);
    SceneManager.LoadScene("Input");
  }
}

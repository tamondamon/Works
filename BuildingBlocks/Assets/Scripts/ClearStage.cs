using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ClearStage : MonoBehaviour
{
    public GameObject ClearText;
    public AudioClip ClearSound;
    private AudioSource _audioSource;
    public PuzzleBGM puzzleBGM;
    // Start is called before the first frame update
    void Start()
    {
      _audioSource = GetComponent<AudioSource>();
    }

    public void Clear(){
      puzzleBGM.StopMusic();
      _audioSource.PlayOneShot(ClearSound);
      ClearText.GetComponent<TextMesh>().text = "Next Stage ...";
      Invoke("NextStage",2.5f);
    }

    void NextStage(){
      int correntScene = int.Parse(SceneManager.GetActiveScene().name);
      var nextScene = (correntScene+1).ToString();
      SceneManager.LoadScene (nextScene);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Escape : MonoBehaviour
{
    public GameObject pausemenu;

    private bool isPaused;
    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("escape")){
          if(!isPaused){
            pausemenu.SetActive(true);
            isPaused = true;
          }
          else{
            pausemenu.SetActive(false);
            isPaused = false;
          }
        }
    }

    public void ExitButton(){
      Application.Quit();
    }
    public void Retry(){
      Scene scene = SceneManager.GetActiveScene(); 
      SceneManager.LoadScene(scene.name);
    }

    public void toHome(){
      SceneManager.LoadScene("title page");
    }

    public void toSelect(){
      SceneManager.LoadScene("level selector");
    }

    public void Continue(){
      pausemenu.SetActive(false);
      isPaused = false;
    }
}

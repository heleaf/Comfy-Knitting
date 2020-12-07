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
            Time.timeScale = 0;
            Cursor.visible = true;
            isPaused = true;
          }
          else{
            Continue();
          }
        }
    }

    public void ExitButton(){
      Time.timeScale = 1;
      Application.Quit();
    }
    public void Retry(){
      Time.timeScale = 1;
      Scene scene = SceneManager.GetActiveScene(); 
      SceneManager.LoadScene(scene.name);
    }

    public void toSelect(){
      Time.timeScale = 1;
      SceneManager.LoadScene("level selector");
      Destroy(GameObject.FindGameObjectWithTag("DataTransfer"));
    }

    public void Continue(){
      Time.timeScale = 1;
      pausemenu.SetActive(false);
      isPaused = false;
      Cursor.visible = false;
    }

    public void ContinueWithCursor(){
      Time.timeScale = 1;
      pausemenu.SetActive(false);
      isPaused = false;
    }
    
}

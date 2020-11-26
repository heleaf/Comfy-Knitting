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
            Cursor.visible = true;
            isPaused = true;
          }
          else{
            pausemenu.SetActive(false);
            isPaused = false;
            Cursor.visible = false;
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

    public void toSelect(){
      SceneManager.LoadScene("level selector");
      Destroy(GameObject.FindGameObjectWithTag("DataTransfer"));
    }

    public void Continue(){
      pausemenu.SetActive(false);
      isPaused = false;
    }
}

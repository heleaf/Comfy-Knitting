using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtons : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // we probably need to do something like a singleton for the intermediary gameobject in order for these functions to be generic.

    public void toHome(){
      SceneManager.LoadScene("title page");
    }

    public void toExit(){
      Application.Quit();
    }

    public void toSettings(){
      //need to implement settings scene or panel
    }

    public void toTutorial(){
      //need to implement tutorial scene or panel
    }

    public void toCredits(){
      //need to implement credits scene or panel
    }

    public void toSelect(){  //only functional for multiple pages if intermediary is a singleton.
      SceneManager.LoadScene("title page");
    }
}

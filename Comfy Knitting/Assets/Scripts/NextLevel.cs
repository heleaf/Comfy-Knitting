using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class NextLevel : MonoBehaviour
{
    private bool active = false;
    public GameObject endScreen;

    public GameObject pauseMenu;
    public Button nextLevel;
    private SetMap smap;

    public GameObject textObject;
    private TextMeshProUGUI text;

    public GameObject readObject;
    private TextMeshProUGUI readText;

    public GameObject writeObject;
    private TextMeshProUGUI writeText;

    void Start(){
      endScreen.SetActive(false);

      smap = GameObject.FindGameObjectWithTag("DataTransfer").GetComponent<SetMap>();
      if(smap.currentIndex+1 >= smap.maps.Length){
        nextLevel.interactable = false;
      }

      text = textObject.GetComponent<TextMeshProUGUI>();
      readText = readObject.GetComponent<TextMeshProUGUI>();
      writeText = writeObject.GetComponent<TextMeshProUGUI>();
    }

    void Update(){
      if(text.text == "!" && !active){
        endScreen.SetActive(true);
        writeText.text = readText.text;
        active = true;
        pauseMenu.SetActive(false);
        Cursor.visible = true;
      }

    }
    public void toNext(){
      smap.currentIndex += 1;
      smap.getMap(smap.currentIndex);
      Scene scene = SceneManager.GetActiveScene(); 
      SceneManager.LoadScene(scene.name);
    }

    public void Retry(){
      Scene scene = SceneManager.GetActiveScene(); 
      SceneManager.LoadScene(scene.name);
    }

    public void toSelect(){
      SceneManager.LoadScene("level selector");
      Destroy(GameObject.FindGameObjectWithTag("DataTransfer"));
    }
    public void ExitButton(){
      Application.Quit();
    }
}

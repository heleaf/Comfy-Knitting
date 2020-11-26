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

    public GameObject hsObject;
    private TextMeshProUGUI hsText;

    void Start(){
      endScreen.SetActive(false);

      smap = GameObject.FindGameObjectWithTag("DataTransfer").GetComponent<SetMap>();
      if(smap.currentIndex+1 >= smap.maps.Length){
        nextLevel.interactable = false;
      }

      text = textObject.GetComponent<TextMeshProUGUI>();
      readText = readObject.GetComponent<TextMeshProUGUI>();
      writeText = writeObject.GetComponent<TextMeshProUGUI>();
      hsText = hsObject.GetComponent<TextMeshProUGUI>();
    }

    void Update(){
      if(text.text == ">" && !active){
        active = true;

        endScreen.SetActive(true);
        pauseMenu.SetActive(false);
        Cursor.visible = true;

        writeText.text = readText.text;
        hsText.text = "High score: " + convertTime(PlayerPrefs.GetFloat("Highscore" + smap.currentIndex, 0));
      }
    }

    string convertTime(float x){
      float seconds = x % 60;
      float minutes = x / 60;
      return minutes.ToString("00") + ":" + seconds.ToString("00");
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

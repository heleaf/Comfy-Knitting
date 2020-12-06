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

    public Image star1;
    public Image star2;
    public Image star3;

    public Sprite starFilled;

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

        float time = PlayerPrefs.GetFloat("Highscore" + smap.currentIndex, 6000);
        int tiles = smap.currentMap.width * smap.currentMap.height * smap.passwordLengths[smap.currentIndex];
        float bronze = tiles;
        float silver = tiles*.7f;
        float gold = tiles*.45f;
        if(time<bronze) star1.sprite = starFilled;
        if(time<silver) star2.sprite = starFilled;
        if(time<gold) star3.sprite = starFilled;


        pauseMenu.SetActive(false);
        Cursor.visible = true;

        writeText.text = readText.text;
        hsText.text = "High score: " + convertTime(time);
      }
    }

    string convertTime(float x){
      int seconds = (int)(x % 60);
      int minutes = (int)(x / 60);
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

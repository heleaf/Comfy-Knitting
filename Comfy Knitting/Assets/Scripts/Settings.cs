using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
  private AudioSource music;
  private AudioSource clicks;

  public Slider musicSlider;
  public Slider clicksSlider;
  public GameObject confirmButton;
  public GameObject cancelButton;

  private int numLevels = 6;
  private float musicDefault = 0.18f;

  private float keyDefault = 0.7f;
  private int firstPlayInt;
  void Start(){
    cancel();
    music = GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>();
    float musicVol = PlayerPrefs.GetFloat("MusicVol");
    if(musicVol==0){
      musicSlider.value = 1;
      PlayerPrefs.SetFloat("MusicVol", 1.0f);
    }
    else{
      musicSlider.value = musicVol;
    }
    //clicks = GameObject.FindGameObjectWithTag("clicks").GetComponent<AudioSource>();
  }

  public void changeMusic(){
    music.volume = musicSlider.value*musicDefault;
    if(musicSlider.value == 0) PlayerPrefs.SetFloat("MusicVol", 0.00001f);
    else PlayerPrefs.SetFloat("MusicVol", musicSlider.value);
  }

  public void resetScores(){
    confirmButton.SetActive(true);
    cancelButton.SetActive(true);
  }
  public void confirm(){
    for(int i = 0; i<numLevels; i++){
      PlayerPrefs.DeleteKey("Highscore" + i);
    }
    cancel();
  }
  public void cancel(){
    confirmButton.SetActive(false);
    cancelButton.SetActive(false);
  }

}

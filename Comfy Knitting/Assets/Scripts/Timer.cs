using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using Debug=UnityEngine.Debug;
using TMPro;

public class Timer : MonoBehaviour
{
    private int started = 0; //0 is not yet started, 1 is started, 2 is finished.
    private float timeElapsed;

    public GameObject endObject;

    private TextMeshProUGUI endText;

    private TextMeshProUGUI timerText;

    private SetMap smap;

    void Start(){
      smap = GameObject.FindGameObjectWithTag("DataTransfer").GetComponent<SetMap>();

      timerText = gameObject.GetComponent<TextMeshProUGUI>();
      timerText.text = "00:00";
      endText = endObject.GetComponent<TextMeshProUGUI>();
    }
    // Update is called once per frame
    void Update()
    {
        if(started==0){
          if(Input.anyKeyDown){
            started = 1;
            timeElapsed = 0;
            timerText.text = "00:00";
          }
        }
        else if(started==1){
          timeElapsed += Time.deltaTime;
          int seconds = (int)(timeElapsed % 60);
          int minutes = (int)(timeElapsed / 60);
          timerText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
          
          if(endText.text == "!"){
            endText.text = ">";
            started = 2;
            if(PlayerPrefs.GetFloat("Highscore" + smap.currentIndex, 6000.0f) > timeElapsed){
              PlayerPrefs.SetFloat("Highscore" + smap.currentIndex, timeElapsed);
            }
          }
        }
    }
}

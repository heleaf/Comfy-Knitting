using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayData : MonoBehaviour
{
    public GameObject timeObject;
    private TextMeshProUGUI timeText;

    public int index;
    void Start()
    {
      timeText = timeObject.GetComponent<TextMeshProUGUI>();
      Debug.Log(PlayerPrefs.GetFloat("Highscore" + index, 6000.0f));
      Debug.Log(index);
      timeText.text = convertTime(PlayerPrefs.GetFloat("Highscore" + index, 6000.0f));
    }

    string convertTime(float x){
      if(x == 6000.0f){
        return "N/A";
      }
      else{
        int seconds = (int)(x % 60);
        int minutes = (int)(x / 60);
        return minutes.ToString("00") + ":" + seconds.ToString("00");
      }
    }

}

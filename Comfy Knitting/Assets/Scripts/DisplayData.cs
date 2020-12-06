using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DisplayData : MonoBehaviour
{
    public GameObject timeObject;
    private TextMeshProUGUI timeText;

    public Sprite starFilled;
    public Sprite starEmpty;

    public Image star1;
    public Image star2;
    public Image star3;

    public GameObject dataObject;
    private SetMap data;

    public int index;
    void Start()
    {
      data = dataObject.GetComponent<SetMap>();

      int tiles = data.maps[index].width * data.maps[index].height * data.passwordLengths[index];
      float bronze = tiles;
      float silver = tiles*.7f;
      float gold = tiles*.45f;

      float time = PlayerPrefs.GetFloat("Highscore" + index, 6000.0f);
      timeText = timeObject.GetComponent<TextMeshProUGUI>();
      timeText.text = convertTime(time);

      if(time<bronze) star1.sprite = starFilled;
      if(time<silver) star2.sprite = starFilled;
      if(time<gold) star3.sprite = starFilled;
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

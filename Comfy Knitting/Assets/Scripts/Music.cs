using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    void Start()
    {
      float vol = PlayerPrefs.GetFloat("MusicVol");
      if(vol!=0) gameObject.GetComponent<AudioSource>().volume = 0.18f*PlayerPrefs.GetFloat("MusicVol");
      DontDestroyOnLoad(gameObject);

      GameObject[] temp = GameObject.FindGameObjectsWithTag("Music");
      Debug.Log(temp.Length);
      if(temp.Length>1) Destroy(gameObject);
    }

}

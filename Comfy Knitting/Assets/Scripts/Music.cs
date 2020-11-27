using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public float musicVolume;

    private float musicDefault = 0.18f;

    public float keyVolume;

    public float keyDefault = 0.7f;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void setMusicVol(){

    }
}

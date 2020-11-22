using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMap : MonoBehaviour
{
    public Texture2D[] maps;

    public Texture2D currentMap;
    
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void getMap(int index){
      currentMap = maps[index];
    }
    
}

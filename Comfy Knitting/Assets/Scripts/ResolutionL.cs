using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolutionL : MonoBehaviour
{
    private int w;
    private int h;

    private float ratio = 1920/1080;

    private float scalar;        
    // Start is called before the first frame update
    void Start()
    {
      w = Screen.width;
      h = Screen.height;
      Debug.Log(w);
      Debug.Log(h);
      if((float)w/(float)h < ratio){
        scalar = (float)w/1150;
      }
      else{
        scalar = (float)h/647;
      }

      gameObject.transform.localScale = new Vector3(scalar, scalar, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

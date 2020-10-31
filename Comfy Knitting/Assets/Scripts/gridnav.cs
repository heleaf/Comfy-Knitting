using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gridnav : MonoBehaviour
{  
  [SerializeField]
  private int rows = 10;
  [SerializeField]
  private int cols = 10;
  [SerializeField]
  private float tileSize = 1; 
    // Start is called before the first frame update
    void Start()
    {
        generateGrid();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void generateGrid(){
      GameObject reftile = (GameObject)Instantiate(Resources.Load("Square"));
      for (int i = 0; i<rows; i++){
        for (int j = 0; j<cols; j++){
          GameObject tile = (GameObject)Instantiate(reftile, transform);

          float posX = j*tileSize;
          float posY = i*(-tileSize);

          tile.transform.position = new Vector2(posX, posY);

        }
      }
      Destroy(reftile);
      float gridW = cols*tileSize;
      float gridH = rows*tileSize;
      transform.position = new Vector2(-gridW/2 + tileSize/2, gridH/2 - tileSize / 2 );
    }
}

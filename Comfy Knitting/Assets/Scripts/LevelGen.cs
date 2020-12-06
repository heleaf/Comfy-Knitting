using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

public class LevelGen : MonoBehaviour
{
  //private float fullwidth = 100;
  //private float scale;
  public GameObject levelObject;
  private TextMeshProUGUI levelText;



  public Camera mainCam; //Main camera
  private Texture2D map; //The image material for the level
  public ColorToPrefab[] colorMappings; //Tile data array
  public GameObject prefab; //Prefab for tile generation

  public int passwordLength; //length of password

    void Awake()
    {
      Cursor.visible = false;
      map = GameObject.FindGameObjectWithTag("DataTransfer").GetComponent<SetMap>().currentMap;
      passwordLength = PlayerPrefs.GetInt("PasswordLength");
      //scale = fullwidth/map.width;
      //prefab.transform.localScale = new Vector3(scale, scale, 1);

      cameraSetup(); //Sets camera dimensions according to map dimensions

      GenerateLevel(); //Generates array of tile information and instantiates tiles

      levelText = levelObject.GetComponent<TextMeshProUGUI>();
      levelText.text = "Level " + (GameObject.FindGameObjectWithTag("DataTransfer").GetComponent<SetMap>().currentIndex + 1);
    }

    //Sets camera dimensions according to map dimensions. Subject to change.
    void cameraSetup(){
      mainCam.enabled = true;
      mainCam.orthographic = true;
      mainCam.orthographicSize = map.width/1.2f;
      mainCam.transform.position = new Vector3(map.width, map.width/4.0f, -10);
    }

    //Instantiates player, initializes and fills array.
    void GenerateLevel(){
      colorMappings = new ColorToPrefab[map.width*map.height];
      for(int i = 0; i<map.width; i++){
        for(int j = 0; j<map.height; j++){
          GenerateTile(i, j);
        }
      }
    }

    //Generates tile data array and fills initial data.
    void GenerateTile(int x, int y){

      Color pixelColor = map.GetPixel(x, y);
      ColorToPrefab colorMapping = new ColorToPrefab();
      colorMappings[x+y*map.width] = colorMapping;
      colorMapping.password = CreateRandomString(passwordLength);
      colorMapping.pos = new Vector2(x, y);
      colorMapping.color = pixelColor;
      colorMapping.gameobject = Instantiate(prefab, colorMapping.pos, Quaternion.identity, transform);
    } 

    //Generates random array of characters 
    private string[] CreateRandomString(int stringLength) {
        int _stringLength = stringLength - 1;
        string[] randomString = new string[stringLength];
        string[] characters = new string[] {"a", "s", "d", "w"};
        for (int i = 0; i <= _stringLength; i++) {
            randomString[i] = (characters[Random.Range(0, characters.Length)]);
        }
        return randomString;
    }

}

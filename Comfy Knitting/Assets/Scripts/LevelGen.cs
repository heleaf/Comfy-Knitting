using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelGen : MonoBehaviour
{

  public Texture2D map;
  public ColorToPrefab[] colorMappings;
  public GameObject player;
    // Start is called before the first frame update
  public string[] currentPassword;
  public int lettersLeft;
  public int tilesLeft;
    void Start()
    {
        GenerateLevel();
        tilesLeft = colorMappings.Length-1;
        currentPassword = colorMappings[tilesLeft].password;
        lettersLeft = 4;
    }

    void Update()
    {
      if (lettersLeft>=0){
        keyActions(currentPassword[lettersLeft]);
        Debug.Log(currentPassword[lettersLeft]);
      }
      else{
        tilesLeft--;
        currentPassword = colorMappings[tilesLeft].password;
        lettersLeft = 4;
        player.transform.position = colorMappings[tilesLeft].pos;
      }
    }

    void keyActions(string k){
      if (Input.GetKeyDown(k)){
        lettersLeft--;
      }
      else if (Input.anyKey){
        lettersLeft = 4;
      }
    }

    void GenerateLevel(){
      for(int i = 0; i<map.width; i++){
        for(int j = 0; j<map.height; j++){
          GenerateTile(i, j);

          if(i == map.width-1 && j==map.height-1){
            Vector2 pos = new Vector2(i, j);
            Instantiate(player, pos, Quaternion.identity, transform);
          }
        }
      }
    }
    void GenerateTile(int x, int y){
      Color pixelColor = map.GetPixel(x, y);

      if (pixelColor.a == 0) return; //ignores transparent pixel

      foreach (ColorToPrefab colorMapping in colorMappings){
          colorMapping.password = CreateRandomString(5);
          colorMapping.pos = new Vector2(x, y);
          colorMapping.color = pixelColor;
          GameObject temp = Instantiate(colorMapping.prefab, colorMapping.pos, Quaternion.identity, transform);
          temp.GetComponent<SpriteRenderer>().color = pixelColor;
      }
      
    } 
    
    //string implementation of random string generator
    /*private string CreateRandomString(int stringLength) {
        int _stringLength = stringLength - 1;
        string randomString = "";
        string[] characters = new string[] {"q", "w", "e", "r", "a", "s", "d", "f"};
        for (int i = 0; i <= _stringLength; i++) {
            randomString = randomString + characters[Random.Range(0, characters.Length)];
        }
        return randomString;
    }*/
    private string[] CreateRandomString(int stringLength) {
        int _stringLength = stringLength - 1;
        string[] randomString = new string[stringLength];
        string[] characters = new string[] {"a", "s", "d", "f"};
        for (int i = 0; i <= _stringLength; i++) {
            randomString[i] = (characters[Random.Range(0, characters.Length)]);
        }
        return randomString;
    }

}

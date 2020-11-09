
using UnityEngine;

public class LevelGen : MonoBehaviour
{

  public Texture2D map;
  public ColorToPrefab[] colorMappings;
  public GameObject player;
    // Start is called before the first frame update

    void Start()
    {
        GenerateLevel();
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
          Debug.Log(colorMapping.password);
          Vector2 position = new Vector2(x, y);
          GameObject temp = Instantiate(colorMapping.prefab, position, Quaternion.identity, transform);
          temp.GetComponent<SpriteRenderer>().color = pixelColor;
      }
      
    } 
    
    private string CreateRandomString(int stringLength) {
        int _stringLength = stringLength - 1;
        string randomString = "";
        string[] characters = new string[] {"q", "w", "e", "r", "a", "s", "d", "f"};
        for (int i = 0; i <= _stringLength; i++) {
            randomString = randomString + characters[Random.Range(0, characters.Length)];
        }
        return randomString;
    }
}

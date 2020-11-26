using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerControls : MonoBehaviour
{
    public GameObject LevelGenerator;
    private LevelGen LevelScript;
    private ColorToPrefab[] colorMappings;

    public GameObject textObject;
    private TextMeshProUGUI letterText;

    public GameObject nextTextObject;
    private TextMeshProUGUI nextLetterText;

    private string[] currentPassword; //String array of current tile's password
    private int lettersLeft; //Number of letters left
    private int tilesLeft; //Number of tiles left

    private int passwordLength;

    
    
    // Start is called before the first frame update
    void Start()
    {
      
      letterText = textObject.GetComponent<TextMeshProUGUI>();
      nextLetterText = nextTextObject.GetComponent<TextMeshProUGUI>();  

      LevelScript = LevelGenerator.GetComponent<LevelGen>();
      colorMappings = LevelScript.colorMappings;
      passwordLength = LevelScript.passwordLength;

      gameObject.transform.position = colorMappings[colorMappings.Length-1].pos;

      tilesLeft = colorMappings.Length-1;
      currentPassword = colorMappings[tilesLeft].password;
      lettersLeft = passwordLength-1;
      letterText.text = currentPassword[lettersLeft];
      nLT();
    }

    // Update is called once per frame
    void LateUpdate()
    {
      if (lettersLeft>=0){
        keyActions(currentPassword[lettersLeft]);
        nLT();
      }
      else{
        if(tilesLeft>0){
          colorMappings[tilesLeft].gameobject.GetComponent<SpriteRenderer>().color = colorMappings[tilesLeft].color;
          tilesLeft--;
          currentPassword = colorMappings[tilesLeft].password;
          lettersLeft = passwordLength-1;
          letterText.text = currentPassword[lettersLeft];
          nLT();
          gameObject.transform.position = colorMappings[tilesLeft].pos;
        }
        else{
          colorMappings[tilesLeft].gameobject.GetComponent<SpriteRenderer>().color = colorMappings[tilesLeft].color;
          gameObject.transform.position = new Vector2(-100, -100);
          letterText.text = "!";
        }
      }
    }

    void nLT (){
      if(lettersLeft>0){
        nextLetterText.text = joinStrings(currentPassword, lettersLeft);
      }
      else{
        nextLetterText.text = "";
      }
    }
    string joinStrings(string[] k, int length){
      string result = "";
      for(int i = length-1; i>=0; i--){
        result += " " + k[i];
      }
      return result;
    }

    //Uses player input to progress passwords.
    void keyActions(string k){
      if (Input.GetKeyDown(k)){
        lettersLeft--;
        if(lettersLeft>=0) letterText.text = currentPassword[lettersLeft];
      }
      else if (Input.anyKeyDown){
        lettersLeft = passwordLength-1;
        letterText.text = currentPassword[lettersLeft];
      }
    }
}

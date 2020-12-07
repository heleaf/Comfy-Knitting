using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WASD : MonoBehaviour
{
    public Image box;
    public Button WKey;
    public Button AKey;
    public Button SKey;
    public Button DKey;
    public TextMeshProUGUI letterText;
    
    private Color32 newRed = new Color32(227, 56, 50, 255);
    private Color32 newBlue = new Color32(120, 156, 227, 255);

    private Color32 boxDefault;
    private Color32 boxLight;

    void Start(){
      boxDefault = box.color;
      boxLight = box.color + new Color32(15, 15, 15, 0);
    }
    void Update()
    {
        if(Input.GetKeyDown("w")){
          if (string.Equals("w", letterText.text)){
            box.color = boxLight;
            WKey.GetComponent<Image>().color = newBlue;
          }
          else{
            WKey.GetComponent<Image>().color = newRed;
            box.color = newRed;
          }
          gameObject.GetComponent<AudioSource>().Play();
        }
        if(Input.GetKeyUp("w")){
          WKey.GetComponent<Image>().color = Color.white;
          box.color = boxDefault;
        }
        

        if(Input.GetKeyDown("a")){
          if (string.Equals("a", letterText.text)){
            box.color = boxLight;
            AKey.GetComponent<Image>().color = newBlue;
          }
          else{
            AKey.GetComponent<Image>().color = newRed;
            box.color = newRed;
          }
          gameObject.GetComponent<AudioSource>().Play();
        }
        if(Input.GetKeyUp("a")){
          AKey.GetComponent<Image>().color = Color.white;
          box.color = boxDefault;
        }



        if(Input.GetKeyDown("s")){
          if (string.Equals("s", letterText.text)){
            box.color = boxLight;
            SKey.GetComponent<Image>().color = newBlue;
          }
          else{
            SKey.GetComponent<Image>().color = newRed;
            box.color = newRed;
          }
          gameObject.GetComponent<AudioSource>().Play();
        }
        if(Input.GetKeyUp("s")){
          SKey.GetComponent<Image>().color = Color.white;
          box.color = boxDefault;
        }



        if(Input.GetKeyDown("d")){
          if (string.Equals("d", letterText.text)){
            box.color = boxLight;
            DKey.GetComponent<Image>().color = newBlue;
          }
          else{
            DKey.GetComponent<Image>().color = newRed;
            box.color = newRed;
          }
          gameObject.GetComponent<AudioSource>().Play();
        }
        if(Input.GetKeyUp("d")){
          DKey.GetComponent<Image>().color = Color.white;
          box.color = boxDefault;
        }
    }
}

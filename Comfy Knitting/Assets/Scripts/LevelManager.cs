using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public GameObject Music;
    private int pageIndex;

    private Image canvasImage;

    public GameObject[] pages;

    public Sprite[] backgrounds;

    public GameObject leftButton;

    public GameObject rightButton;
    
    // Start is called before the first frame update
    void Start()
    {
      pageIndex = 0;
      canvasImage = gameObject.GetComponent<Image>();
      setInactiveOnStart();
      leftButton.SetActive(false);
      rightButton.SetActive(true);

      GameObject[] temp = GameObject.FindGameObjectsWithTag("Music");
      Debug.Log(temp.Length);
      if(temp.Length>1) Destroy(Music);
    }

    void setInactiveOnStart(){
      foreach(GameObject g in pages){
        g.SetActive(false);
      }
      pages[pageIndex].SetActive(true);
      canvasImage.sprite = backgrounds[0];
    }

    public void forwardPage(){
      pages[pageIndex].SetActive(false);
      pageIndex++;
      pages[pageIndex].SetActive(true);
      canvasImage.sprite = backgrounds[pageIndex];

      if(pageIndex == pages.Length-1) rightButton.SetActive(false);

      leftButton.SetActive(true);
    }

    public void backwardPage(){
      pages[pageIndex].SetActive(false);
      pageIndex--;
      pages[pageIndex].SetActive(true);
      canvasImage.sprite = backgrounds[pageIndex];
      
      if(pageIndex == 0) leftButton.SetActive(false);

      rightButton.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

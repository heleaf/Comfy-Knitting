using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private int pageIndex;

    public GameObject[] pages;

    public GameObject leftButton;

    public GameObject rightButton;
    
    // Start is called before the first frame update
    void Start()
    {
      pageIndex = 0;
      setInactiveOnStart();
      leftButton.SetActive(false);
      rightButton.SetActive(true);
    }

    void setInactiveOnStart(){
      foreach(GameObject g in pages){
        g.SetActive(false);
      }
      pages[pageIndex].SetActive(true);
    }

    public void forwardPage(){
      pages[pageIndex].SetActive(false);
      pageIndex++;
      pages[pageIndex].SetActive(true);

      if(pageIndex == pages.Length-1) rightButton.SetActive(false);

      leftButton.SetActive(true);
    }

    public void backwardPage(){
      pages[pageIndex].SetActive(false);
      pageIndex--;
      pages[pageIndex].SetActive(true);
      
      if(pageIndex == 0) leftButton.SetActive(false);

      rightButton.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

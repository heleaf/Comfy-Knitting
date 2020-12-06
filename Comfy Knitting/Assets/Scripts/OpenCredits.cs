using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCredits : MonoBehaviour
{
    public GameObject credits;
    private bool isOpen = false;

    void Start(){
      credits.SetActive(isOpen);
    }
    public void openPanel() { 
      isOpen = !isOpen;
      credits.SetActive(isOpen);
    }
}

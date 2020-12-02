using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCredits : MonoBehaviour
{
    public GameObject Panel;
    public bool isOpen = false;
    public void openPanel() { 
        if(Panel!=null){
            if (isOpen == true)
            {
                isOpen = false;
                Panel.SetActive(isOpen);
            }
            else
            {
                isOpen = true;
                Panel.SetActive(isOpen);
            }
            
        }
    }
}

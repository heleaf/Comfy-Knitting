using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelMovement : MonoBehaviour
{
  public void grow(){
    gameObject.transform.localScale = new Vector3 (1.1f, 1.1f, 1);
  }

  public void shrink(){
    gameObject.transform.localScale = new Vector3 (1, 1, 1);
  }

  public void playclick(){
    gameObject.GetComponent<AudioSource>().Play();
  }
}

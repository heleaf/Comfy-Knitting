using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    public void resetScores(){
      PlayerPrefs.DeleteAll();
    }
}

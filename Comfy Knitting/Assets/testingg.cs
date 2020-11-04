using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class testingg : MonoBehaviour
{
    public void playGame()
    {
        SceneManager.LoadScene("Level Selector");
    }

    public void backToTitlePage()
    {
        SceneManager.LoadScene("Title Page");
    }

    public void loadLevel(int num)
    {
        SceneManager.LoadScene("Level " + num);
    }
}


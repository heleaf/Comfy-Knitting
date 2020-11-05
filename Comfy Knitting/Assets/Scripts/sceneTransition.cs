using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneTransition : MonoBehaviour
{
    public void goToLevelSelector()
    {
        SceneManager.LoadScene("level selector");
    }

    public void goToTitlePage()
    {
        SceneManager.LoadScene("title page");
    }
}

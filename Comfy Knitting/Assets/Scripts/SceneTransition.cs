using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
        public void goToTitlePage()
        {
            SceneManager.LoadScene("title page");
        }

        public void goToLevelSelector()
        {
            SceneManager.LoadScene("level selector");
        }
    
}


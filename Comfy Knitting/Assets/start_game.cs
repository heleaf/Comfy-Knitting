using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class start_game : MonoBehaviour
{

    public void playGame()
    {
        SceneManager.LoadScene("Level Selector");
    }
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene("Level Selector");
        Debug.Log("clc");
    }

    // Update is called once per frame
    //void Update()
    //{
        
    //}
}

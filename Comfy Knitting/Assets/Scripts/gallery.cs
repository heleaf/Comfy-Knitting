using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gallery : MonoBehaviour
{
    public Image[] img;
    public GameObject lockPrefab;
    public GameObject enlargedBG;
    public Image enlargedIMG;
    // Start is called before the first frame update
    void Start()
    {
      for (int i = 0; i<img.Length; i++){
        if(PlayerPrefs.GetFloat("Highscore" + i, 6000.0f) == 6000.0f){
          Debug.Log(PlayerPrefs.GetFloat("Highscore" + i, 6000.0f));
          makeLocked(i);
        }
      }
    }

    void makeLocked(int i){
      Debug.Log("lock");
      Instantiate(lockPrefab, img[i].transform.position, Quaternion.identity, transform);
      img[i].GetComponent<Button>().interactable = false;
    }

    public void showImg(int index){
      enlargedBG.SetActive(true);
      enlargedIMG.sprite = img[index].sprite;
    }
    public void hideImg(){
      enlargedBG.SetActive(false);
    }

    void Update(){
      if(Input.GetKeyDown("escape")){
        if(enlargedBG.activeSelf) hideImg();
        else{
          SceneManager.LoadScene("level selector");
          Destroy(GameObject.FindGameObjectWithTag("DataTransfer"));
        }
      }
    }
}
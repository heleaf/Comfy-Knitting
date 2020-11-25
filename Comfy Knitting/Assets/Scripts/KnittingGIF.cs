using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KnittingGIF : MonoBehaviour
{
    public Sprite[] frames;

    private Image img;
    public float fps;

    // Start is called before the first frame update
    void Start()
    {
        img = gameObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        int index = (int)(Time.time*fps);
        index = index % frames.Length;
        img.sprite = frames[index];
    }
}

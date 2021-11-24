using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Video;

public class introVideoController : MonoBehaviour
{
    public RawImage img;
    public VideoPlayer vpStart;
    public VideoPlayer vpLoop;
    public GameObject start;
    public GameObject exit;
    public GameObject tutLevel;
    public GameObject level1;
    public GameObject level2;

    // Update is called once per frame
    void Update()
    {
        if (vpStart.clip.length - vpStart.time <= 0.1)
        {
            img.texture = vpLoop.texture;
            start.SetActive(true);
            exit.SetActive(true);
            tutLevel.SetActive(true);
            level1.SetActive(true);
            level2.SetActive(true);
        } else
        {
            img.texture = vpStart.texture;
        }
    }
}

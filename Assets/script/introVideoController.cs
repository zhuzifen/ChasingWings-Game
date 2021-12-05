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
    public GameObject levelSelect;

    bool playing = true;

    // Update is called once per frame
    void Update()
    {
        if (playing && Input.GetMouseButton(1))
        {
            vpStart.playbackSpeed = 5;
        } else if (playing)
        {
            vpStart.playbackSpeed = 1;
        }
        if (vpStart.clip.length - vpStart.time <= 0.1)
        {
            img.texture = vpLoop.texture;
            start.SetActive(true);
            exit.SetActive(true);
            levelSelect.SetActive(true);
            levelSelect.SetActive(true);

            playing = false;
        } else
        {
            img.texture = vpStart.texture;
        }
    }
}

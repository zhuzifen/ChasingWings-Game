using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateItemNumber : MonoBehaviour
{
    public GameObject springNumberObj;
    public GameObject fanNumberObj;
    public GameObject boardNumberObj;

    private Text springNumberText;

    private Text fanNumberText;

    private Text boardNumberText;
    // Start is called before the first frame update
    void Start()
    {
        springNumberText = springNumberObj.GetComponent<Text>();
        fanNumberText = fanNumberObj.GetComponent<Text>();
        boardNumberText = boardNumberObj.GetComponent<Text>();
    }

    public void UpdateSpringText(int num)
    {
        springNumberText.text = "" + num;
    }

    public void UpdateFanText(int num)
    {
        fanNumberText.text = "" + num;
    }

    public void UpdateBoardText(int num)
    {
        boardNumberText.text = "" + num;
    }
}

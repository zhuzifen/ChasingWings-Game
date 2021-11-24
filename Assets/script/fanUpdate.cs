using System.Collections;
using System.Collections.Generic;
using script.User_Control;
using UnityEngine;
using UnityEngine.UI;

public class fanUpdate : MonoBehaviour
{
    Image sr;

    public UpdateItemNumber updateItemNumber;
    
    public UserControl fanLogic;

    void Start()
    {
        sr = this.gameObject.GetComponent<Image>();
        updateItemNumber = FindObjectOfType<UpdateItemNumber>();
    }

    // Update is called once per frame
    void Update()
    {
        int toSet = fanLogic.fanLimit - fanLogic.fanCount;
        switch(toSet)
        {
            case 0:
                updateItemNumber.UpdateFanText(0);
                break;
            case 1:
                updateItemNumber.UpdateFanText(1);
                break;
            case 2:
                updateItemNumber.UpdateFanText(2);
                break;
            case 3:
                updateItemNumber.UpdateFanText(3);
                break;
            case 4:
                updateItemNumber.UpdateFanText(4);
                break;
            case 5:
                updateItemNumber.UpdateFanText(5);
                break;
            case 6:
                updateItemNumber.UpdateFanText(6);
                break;
            case 7:
                updateItemNumber.UpdateFanText(7);
                break;
            case 8:
                updateItemNumber.UpdateFanText(8);
                break;
            case 9:
                updateItemNumber.UpdateFanText(9);
                break;
            default:
                updateItemNumber.UpdateFanText(10);
                break;
        }
    }
}

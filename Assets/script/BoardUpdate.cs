using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using script.User_Control;
using UnityEngine.UI;

public class BoardUpdate : MonoBehaviour
{
    Image sr;

    public UpdateItemNumber updateItemNumber;
    
    public UserControl boardLogic;

    void Start()
    {
        sr = this.gameObject.GetComponent<Image>();
        updateItemNumber = FindObjectOfType<UpdateItemNumber>();
    }

    // Update is called once per frame
    void Update()
    {
        int toSet = boardLogic.directionBoardLimit - boardLogic.directionBoardCount;
        switch(toSet)
        {
            case 0:
                updateItemNumber.UpdateBoardText(0);
                break;
            case 1:
                updateItemNumber.UpdateBoardText(1);
                break;
            case 2:
                updateItemNumber.UpdateBoardText(2);
                break;
            case 3:
                updateItemNumber.UpdateBoardText(3);
                break;
            case 4:
                updateItemNumber.UpdateBoardText(4);
                break;
            case 5:
                updateItemNumber.UpdateBoardText(5);
                break;
            case 6:
                updateItemNumber.UpdateBoardText(6);
                break;
            case 7:
                updateItemNumber.UpdateBoardText(7);
                break;
            case 8:
                updateItemNumber.UpdateBoardText(8);
                break;
            case 9:
                updateItemNumber.UpdateBoardText(9);
                break;
            default:
                updateItemNumber.UpdateBoardText(10);
                break;
        }
    }
}

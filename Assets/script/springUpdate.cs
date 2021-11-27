using System.Collections;
using System.Collections.Generic;
using script.User_Control;
using UnityEngine;
using UnityEngine.UI;

public class springUpdate : MonoBehaviour
{
    Image sr;

    public UpdateItemNumber updateItemNumber;
    
    public UserControl springLogic;
    
    void Start()
    {
        sr = this.gameObject.GetComponent<Image>();
        updateItemNumber = FindObjectOfType<UpdateItemNumber>();
    }

    // Update is called once per frame
    void Update()
    {
        int toSet = springLogic.springLimit - springLogic.springCount;
        switch (toSet)
        {
            case 0:
                updateItemNumber.UpdateSpringText(0);
                break;
            case 1:
                updateItemNumber.UpdateSpringText(1);
                break;
            case 2:
                updateItemNumber.UpdateSpringText(2);
                break;
            case 3:
                updateItemNumber.UpdateSpringText(3);
                break;
            case 4:
                updateItemNumber.UpdateSpringText(4);
                break;
            case 5:
                updateItemNumber.UpdateSpringText(5);
                break;
            case 6:
                updateItemNumber.UpdateSpringText(6);
                break;
            case 7:
                updateItemNumber.UpdateSpringText(7);
                break;
            case 8:
                updateItemNumber.UpdateSpringText(8);
                break;
            case 9:
                updateItemNumber.UpdateSpringText(9);
                break;
            default:
                updateItemNumber.UpdateSpringText(10);
                break;
        }
    }
}

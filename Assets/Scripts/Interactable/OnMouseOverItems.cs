using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMouseOverItems : MonoBehaviour
{
    public string message;


    public void ShowTooltip()
    {
        
        EventBroker.CallSetupTooltip(message);
    }

    public void HideTooltip()
    {
        
        EventBroker.CallHideTooltip();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventBroker
{

    public static event Action<Vector3> PlayerMove;

    public static event Action<string> SetupTooltip;

    public static event Action HideTooltip;


    public static void CallPlayerMove(Vector3 point)
    {
        if (PlayerMove != null)
        {
            PlayerMove(point);
        }
    }

    public static void CallSetupTooltip(string message)
    {
        if (SetupTooltip != null)
        {
            SetupTooltip(message);
        }
    }

    public static void CallHideTooltip()
    {
        if (HideTooltip != null)
        {
            HideTooltip();
        }
    }
}

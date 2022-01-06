using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventBroker
{

    public static event Action<Vector3> PlayerMove;

    public static event Action PlayerStop;

    public static event Action<string> SetupTooltip;

    public static event Action HideTooltip;

    public static event Action<string> PlaySound;

    public static event Action<string> StopSound;

    public static event Action ItemChanged;




    public static void CallPlayerMove(Vector3 point)
    {
        if (PlayerMove != null)
        {
            PlayerMove(point);
        }
    }

    public static void CallPlayerStop()
    {
        if (PlayerStop != null)
        {
            PlayerStop();
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

    public static void CallPlaySound(string name)
    {
        if (PlaySound != null)
        {
            PlaySound(name);
        }
    }

    public static void CallStopSound(string name)
    {
        if (StopSound != null)
        {
            StopSound(name);
        }
    }

    public static void CallItemChanged()
    {
        if (ItemChanged != null)
        {
            ItemChanged();
        }
    }


}

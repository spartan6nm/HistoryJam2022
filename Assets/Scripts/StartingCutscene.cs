using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingCutscene : MonoBehaviour
{
    private void Start()
    {
        EventBroker.CallPlaySound("theme");
    }
}

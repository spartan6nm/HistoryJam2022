using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : ScriptableObject
{
    public string questName;

    [TextArea(1,5)]
    public string questDescription;

    List<Item> goalItems;

    Item rewardItem;
}

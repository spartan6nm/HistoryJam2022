using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour
{
    public GameObject tooltip;
    public Text text;
    public RectTransform backgroundTransform;
    public float textPadding;

    bool show = false;

    private void Awake()
    {
        EventBroker.SetupTooltip += ShowTooltip;
        EventBroker.HideTooltip += HideTooltip;
        tooltip.SetActive(false);
    }
    private void OnDestroy()
    {
        EventBroker.SetupTooltip -= ShowTooltip;
        EventBroker.HideTooltip -= HideTooltip;
    }

    private void Update()
    {
        Vector3 screenPoint = Input.mousePosition;
        screenPoint.z = 20.0f; //distance of the plane from the camera
        if (Input.mousePosition.x < Screen.width / 2)
        {
            screenPoint = new Vector3(Input.mousePosition.x - 20, Input.mousePosition.y);

            tooltip.transform.position = Camera.main.ScreenToWorldPoint(screenPoint);
        }
        else
        {
            screenPoint = new Vector3(Input.mousePosition.x + 20, Input.mousePosition.y);

            tooltip.transform.position = Camera.main.ScreenToWorldPoint(screenPoint);
        }
        

    }

    private void ShowTooltip(string message)
    {
        Debug.LogWarning("1");
        show = true;
        tooltip.SetActive(true);
        text.text = message;
        Vector2 backgroundSize = new Vector2(text.preferredWidth + (textPadding * 2), text.preferredHeight + (textPadding * 2));
        backgroundTransform.sizeDelta = backgroundSize;



    }

    private void HideTooltip()
    {
        Debug.LogWarning("1");
        show = false;
        tooltip.SetActive(false);

    }

}

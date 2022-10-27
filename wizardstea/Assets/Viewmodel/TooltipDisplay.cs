using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class TooltipDisplay : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject tooltip;
    public string display;
    public TMP_Text displayText;
    private Coroutine delayedShowing;
    public float waitTime;
    private Transform canvas;
    private Transform originalParent;

    private void Start()
    {
        canvas = GameObject.FindGameObjectWithTag("Canvas").transform;
        originalParent = transform.parent;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        delayedShowing = StartCoroutine(DelayedShowing());
    }

    //tooltip is shown after a short delay to give a smooth feel
    private IEnumerator DelayedShowing()
    {
        yield return new WaitForSeconds(waitTime);
        if (display != "")
        {
            displayText.text = display;
            //ensure that tooltip is shown on top of other UI elements
            tooltip.transform.SetParent(canvas);
            tooltip.transform.SetAsLastSibling();
            tooltip.SetActive(true);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //cancel showing tooltip
        StopCoroutine(delayedShowing);
        tooltip.transform.SetParent(originalParent);
        tooltip.SetActive(false);
    }
}

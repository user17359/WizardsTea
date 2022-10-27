using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollSlider : MonoBehaviour
{

    public DragBlock Rect;
    public Slider Slider;

    private void OnEnable()
    {
        Slider.onValueChanged.AddListener(UpdateScrollPosition);
    }

    private void OnDisable()
    {
        Slider.onValueChanged.RemoveListener(UpdateScrollPosition);
    }

    private void UpdateScrollPosition(float value)
    {
        Rect.verticalNormalizedPosition = 1 - value;
    }
}

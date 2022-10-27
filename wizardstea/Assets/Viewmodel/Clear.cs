using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clear : MonoBehaviour
{

    public CurrentRecipe currentRecipe;
    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
    }

    public void SetActive(bool active)
    {
        button.interactable = active;
    }

    public void ClearIngridients()
    {
        currentRecipe.ClearIngridients(false);
    }
}

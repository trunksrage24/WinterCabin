using System;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

public class Highlightable : Interactable
{
    [field: SerializeField]
    private GameObject pin;

    [field: SerializeField]
    public int id { get; private set; }

    private bool isSelected = false;

    public override void Activate()
    {
        OnCLick?.Invoke(this);
        SelectionUpdate();
        Debug.Log($"{isSelected}");
        return;
    }

    public void UpdatePin()
    {
        if (isSelected == true)
            pin.SetActive(true);
        else if (isSelected == false)
            pin.SetActive(false);
    }

    public void SelectionUpdate()
    {
        isSelected = !isSelected;
        UpdatePin();
    }
    public event Action <Highlightable> OnCLick;
}

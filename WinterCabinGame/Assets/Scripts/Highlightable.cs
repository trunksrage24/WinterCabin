using System;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

public class Highlightable : Interactable
{
    [field: SerializeField]
    private Material highlight;

    [field: SerializeField]
    public int id { get; private set; }

    private bool isSelected = false;

    public override void Activate()
    {
        OnCLick?.Invoke(this);
        isSelected = !isSelected;
        return;
    }

    public void ChangeMaterial(Material oldMaterial)
    {
        if (isSelected)
            this.material = highlight;
        else
            this.material = oldMaterial;
    }

    public event Action <Highlightable> OnCLick;
}

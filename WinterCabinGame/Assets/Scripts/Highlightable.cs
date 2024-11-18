using System;
using UnityEditor;
using UnityEngine;

public class Highlightable : Interactable
{
    [field: SerializeField]
    public int id { get; private set; }

    public override void Activate()
    {
        OnCLick?.Invoke(this);
        return;
    }

    public event Action <Highlightable> OnCLick;
}

using System;
using UnityEditor;
using UnityEngine;

public class Button : Interactable
{
    public override void Activate()
    {
        OnCLick?.Invoke(this);
        return;
    }

    public event Action <Button> OnCLick;
}


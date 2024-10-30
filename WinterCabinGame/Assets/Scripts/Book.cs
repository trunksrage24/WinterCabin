using UnityEngine;

public class Book : Interactable
{
    [field: SerializeField]
    public int id { get; private set; }

    /*[field: SerializeField]
    public int Position { get; private set; } */

    public override void Activate()
    {
        return;
    }
}

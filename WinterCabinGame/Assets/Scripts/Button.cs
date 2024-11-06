using UnityEngine;

public abstract class Button : Interactable
{
    [field: SerializeField]
    public int id { get; private set; }

    public void Start()
    {
        //public BookDisplay master = you.GetComponentInParent<BookDisplay>();
    }

    public override void Activate()
    {
        return;
    }
}


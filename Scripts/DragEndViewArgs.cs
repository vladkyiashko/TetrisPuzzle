using UnityEngine;

public struct DragEndViewArgs
{
    public DragEndViewArgs(int slotIndex, Collider2D collider2D) : this()
    {
        SlotIndex = slotIndex;
        Collider2D = collider2D;
    }

    public int SlotIndex { get; private set; }
    public Collider2D Collider2D { get; private set; }
}

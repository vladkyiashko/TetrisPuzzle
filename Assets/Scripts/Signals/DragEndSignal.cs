using strange.extensions.signal.impl;
using UnityEngine;

public class DragEndSignal : Signal<DragEndArgs> {}

public struct DragEndArgs
{
    public DragEndArgs(int blockSlotIndex, Collider2D collider2D) : this()
    {
        BlockSlotIndex = blockSlotIndex;
        Collider2D = collider2D;
    }

    public int BlockSlotIndex { get; private set; }
    public Collider2D Collider2D { get; private set; }
}
using strange.extensions.signal.impl;
using UnityEngine;

public class BlockTypeMovedToBoardSignal : Signal<BlockTypeMovedToBoardArgs> {}

public struct BlockTypeMovedToBoardArgs
{
    public BlockTypeMovedToBoardArgs(BlockType blockType, Collider2D collider2D) : this()
    {        
        BlockType = blockType;
        Collider2D = collider2D;
    }
       
    public BlockType BlockType { get; private set; }
    public Collider2D Collider2D { get; private set; }
}
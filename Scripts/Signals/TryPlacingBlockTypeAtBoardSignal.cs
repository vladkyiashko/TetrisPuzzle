using strange.extensions.signal.impl;
using UnityEngine;

public class TryPlacingBlockTypeAtBoardSignal : Signal<TryPlacingBlockTypeAtBoardSignalArgs> {}

public struct TryPlacingBlockTypeAtBoardSignalArgs
{
    public TryPlacingBlockTypeAtBoardSignalArgs(BlockType blockType, CellCoordinates cellCoordinates) : this()
    {
        BlockType = blockType;
        CellCoordinates = cellCoordinates;
    }

    public BlockType BlockType { get; private set; }
    public CellCoordinates CellCoordinates { get; private set; }
}
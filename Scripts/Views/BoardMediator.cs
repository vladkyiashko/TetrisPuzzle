using System.Collections.Generic;
using strange.extensions.mediation.impl;
using UnityEngine;

public class BoardMediator : Mediator
{
    [Inject]
    public BoardView View { get; set; }

    [Inject]
    public BlockTypeMovedToBoardSignal BlockTypeMovedToBoardSignal { get; set; }

    [Inject]
    public TryPlacingBlockTypeAtBoardSignal TryPlacingBlockTypeAtBoardSignal { get; set; }

    [Inject]
    public BlockPlacedOnBoardSuccessfullySignal BlockPlacedOnBoardSuccessfullySignal { get; set; }

    [Inject]
    public BoardRowIsOccupiedSignal BoardRowIsOccupiedSignal { get; set; }

    public override void OnRegister()
    {
        BlockTypeMovedToBoardSignal.AddListener(OnBlockTypeMovedToBoard);
        BlockPlacedOnBoardSuccessfullySignal.AddListener(OnBlockPlacedOnBoardSuccessfully);
        BoardRowIsOccupiedSignal.AddListener(OnBoardRowIsOccupied);
    }

    public override void OnRemove()
    {
        BlockTypeMovedToBoardSignal.RemoveListener(OnBlockTypeMovedToBoard);
        BlockPlacedOnBoardSuccessfullySignal.RemoveListener(OnBlockPlacedOnBoardSuccessfully);
        BoardRowIsOccupiedSignal.RemoveListener(OnBoardRowIsOccupied);
    }

    private void OnBlockTypeMovedToBoard(BlockTypeMovedToBoardArgs blockTypeMovedToBoardArgs)
    {
        BoardCellView boardCellView = blockTypeMovedToBoardArgs.Collider2D.GetComponent<BoardCellView>();
        if (boardCellView == null) return;
        
        TryPlacingBlockTypeAtBoardSignal.Dispatch(new TryPlacingBlockTypeAtBoardSignalArgs(blockTypeMovedToBoardArgs.BlockType, boardCellView.CellCoordinates));        
    }

    private void OnBlockPlacedOnBoardSuccessfully(List<CellCoordinates> cellCoordinatesList)
    {
        foreach (CellCoordinates cellCoordinates in cellCoordinatesList)
        {
            View.ToggleCell(cellCoordinates, true);
        }
    }

    private void OnBoardRowIsOccupied(int x)
    {
        for (int y = 0; y < Config.ColumnCellsCount; y++)
        {
            CellCoordinates cellCoordinates = new CellCoordinates(x, y);
            View.ToggleCell(cellCoordinates, false);
        }
    }
}

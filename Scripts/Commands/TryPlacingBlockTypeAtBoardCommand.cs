using System;
using System.Collections.Generic;
using UnityEngine;
using strange.extensions.command.impl;

public class TryPlacingBlockTypeAtBoardCommand : Command
{
    [Inject]
    public IBoardModel BoardModel { get; set; }
    [Inject]
    public BlockPlacedOnBoardSuccessfullySignal BlockPlacedOnBoardSuccessfullySignal { get; set; }

    private TryPlacingBlockTypeAtBoardSignalArgs _tryPlacingBlockTypeAtBoardSignalArgs;
    private List<CellCoordinates> _targetCellCoordinates;

    public override void Execute()
    {
        Debug.Log("TryPlacingBlockTypeAtBoardCommand.Execute");        
        GetArgs();
        GetTargetCellCoordinates();

        if (CheckAnyTargetCellIsOccupied())
        {
            Debug.Log("AnyTargetCellIsOccupied");
        }
        else
        {
            Debug.Log("AnyTargetCellIsNonOccupied");
            BlockPlacedOnBoardSuccessfullySignal.Dispatch(_targetCellCoordinates);
        }
    }

    private void GetArgs()
    {
        object[] datas = (object[])data;
        _tryPlacingBlockTypeAtBoardSignalArgs = (TryPlacingBlockTypeAtBoardSignalArgs)datas[0];
    }

    private void GetTargetCellCoordinates()
    {
        CellCoordinates pivotCellCoordinates = _tryPlacingBlockTypeAtBoardSignalArgs.CellCoordinates;
        List<CellCoordinatesOffset> offsets = Config.BlockTypeCellCoordinatesOffsets[_tryPlacingBlockTypeAtBoardSignalArgs.BlockType];
        _targetCellCoordinates = new List<CellCoordinates>();
        foreach (CellCoordinatesOffset offset in offsets)
        {
            CellCoordinates cellCoordinates = new CellCoordinates(pivotCellCoordinates.X + offset.X, pivotCellCoordinates.Y + offset.Y);
            _targetCellCoordinates.Add(cellCoordinates);
        }        
    }

    private bool CheckAnyTargetCellIsOccupied()
    {
        bool anyTargetCellIsOccupied = false;
        try
        {
            foreach (CellCoordinates targetCellCoordinate in _targetCellCoordinates)
            {
                if (BoardModel.CellsOccupiedStatus[targetCellCoordinate])
                {
                    anyTargetCellIsOccupied = true;
                    break;
                }
            }
        }
        catch (Exception)
        {
            anyTargetCellIsOccupied = true;
        }
        return anyTargetCellIsOccupied;
    }
}

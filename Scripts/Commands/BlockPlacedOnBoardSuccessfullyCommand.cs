using System.Collections.Generic;
using UnityEngine;
using strange.extensions.command.impl;

public class BlockPlacedOnBoardSuccessfullyCommand : Command
{
    [Inject]
    public IBoardModel BoardModel { get; set; }

    [Inject]
    public BoardRowIsOccupiedSignal BoardRowIsOccupiedSignal { get; set; }

    private List<CellCoordinates> _args;

    public override void Execute()
    {
        GetArgs();
        foreach (CellCoordinates cellCoordinate in _args)
        {
            BoardModel.CellsOccupiedStatus[cellCoordinate] = true;
        }

        CheckBoardRowIsOccupied();
    }

    private void CheckBoardRowIsOccupied()
    {
        for (int x = 0; x < Config.RowCellsCount; x++)
        {
            for (int y = 0; y < Config.ColumnCellsCount; y++)
            {
                CellCoordinates cellCoordinates = new CellCoordinates(x, y);
                if (!BoardModel.CellsOccupiedStatus[cellCoordinates])
                {
                    break;
                }
                if (y == Config.ColumnCellsCount - 1)
                {
                    Debug.Log("Row is occupied " + x + "." + y);
                    BoardRowIsOccupiedSignal.Dispatch(x);
                }
            }
        }
    }

    private void GetArgs()
    {
        object[] datas = (object[])data;
        _args = (List<CellCoordinates>)datas[0];
    }
}

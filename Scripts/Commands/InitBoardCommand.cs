using System.Collections.Generic;
using UnityEngine;
using strange.extensions.command.impl;

public class InitBoardCommand : Command
{
    [Inject]
    public IBoardModel BoardModel { get; set; }

    public override void Execute()
    {
        InitCellsOccupiedStatus();        
    }

    private void InitCellsOccupiedStatus()
    {
        BoardModel.CellsOccupiedStatus = new Dictionary<CellCoordinates, bool>(Config.BoardCellsCount);
        for (int x = 0; x < Config.RowCellsCount; x++)
        {
            for (int y = 0; y < Config.ColumnCellsCount; y++)
            {
                CellCoordinates cellCoordinates = new CellCoordinates(x, y);
                BoardModel.CellsOccupiedStatus[cellCoordinates] = false;
            }
        }
    }
}

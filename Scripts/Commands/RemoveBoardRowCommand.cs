using strange.extensions.command.impl;
using UnityEngine;

public class RemoveBoardRowCommand : Command
{
    [Inject]
    public IBoardModel BoardModel { get; set; }

    private int _removeBoardRowXArg;

    public override void Execute()
    {
        GetArgs();
        for (int y = 0; y < Config.ColumnCellsCount; y++)
        {
            CellCoordinates cellCoordinates = new CellCoordinates(_removeBoardRowXArg, y);
            BoardModel.CellsOccupiedStatus[cellCoordinates] = false;
        }
    }

    private void GetArgs()
    {
        object[] datas = (object[])data;
        _removeBoardRowXArg = (int)datas[0];
    }
}

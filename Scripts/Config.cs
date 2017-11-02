using System.Collections.Generic;

public static class Config
{
    public const int BoardCellsCount = 100;
    public const int RowCellsCount = 10;
    public const int ColumnCellsCount = 10;
    public const int SlotsCount = 3;
    public static readonly Dictionary<BlockType, List<CellCoordinatesOffset>> BlockTypeCellCoordinatesOffsets = new Dictionary<BlockType, List<CellCoordinatesOffset>>
    {
        {BlockType.I, new List<CellCoordinatesOffset> { new CellCoordinatesOffset(0, -1), new CellCoordinatesOffset(0, 0), new CellCoordinatesOffset(0, 1), new CellCoordinatesOffset(0, 2) } },
        {BlockType.J, new List<CellCoordinatesOffset> { new CellCoordinatesOffset(-1, 0), new CellCoordinatesOffset(0, 0), new CellCoordinatesOffset(0, 1), new CellCoordinatesOffset(0, 2) } },
        {BlockType.L, new List<CellCoordinatesOffset> { new CellCoordinatesOffset(1, -1), new CellCoordinatesOffset(1, 0), new CellCoordinatesOffset(1, 1), new CellCoordinatesOffset(0, 1) } },
        {BlockType.O, new List<CellCoordinatesOffset> { new CellCoordinatesOffset(0, 0), new CellCoordinatesOffset(0, 1), new CellCoordinatesOffset(1, 0), new CellCoordinatesOffset(1, 1) } },
        {BlockType.S, new List<CellCoordinatesOffset> { new CellCoordinatesOffset(0, 0), new CellCoordinatesOffset(0, 1), new CellCoordinatesOffset(-1, -1), new CellCoordinatesOffset(-1, 0) } },
        {BlockType.T, new List<CellCoordinatesOffset> { new CellCoordinatesOffset(-1, 0), new CellCoordinatesOffset(0, -1), new CellCoordinatesOffset(0, 0), new CellCoordinatesOffset(0, 1) } },
        {BlockType.Z, new List<CellCoordinatesOffset> { new CellCoordinatesOffset(0, -1), new CellCoordinatesOffset(0, 0), new CellCoordinatesOffset(-1, 0), new CellCoordinatesOffset(-1, 1) } }
    };
}

public struct CellCoordinatesOffset
{
    public CellCoordinatesOffset(int x, int y) : this()
    {
        X = x;
        Y = y;
    }

    public int X { get; private set; }
    public int Y { get; private set; }
}
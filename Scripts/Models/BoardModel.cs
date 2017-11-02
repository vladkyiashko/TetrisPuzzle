using System.Collections.Generic;

public class BoardModel : IBoardModel
{
    public Dictionary<CellCoordinates, bool> CellsOccupiedStatus { get; set; }
}

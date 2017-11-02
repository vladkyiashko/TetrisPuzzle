using System.Collections.Generic;

public interface IBoardModel
{
    Dictionary<CellCoordinates, bool> CellsOccupiedStatus { get; set; }    
}

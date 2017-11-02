using System.Collections.Generic;

public interface IBlockSlotsModel
{
    List<BlockType> BlockTypes { get; set; }   
    int LastBlockSlotIndex { get; set; }
    int ActiveBlockSlotsCount { get; set; }
}
using System.Collections.Generic;

public class BlockSlotsModel : IBlockSlotsModel
{    
    public List<BlockType> BlockTypes { get; set; }
    public int LastBlockSlotIndex { get; set; }
    public int ActiveBlockSlotsCount { get; set; }
}

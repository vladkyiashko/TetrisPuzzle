using strange.extensions.command.impl;
using UnityEngine;

public class RemoveLastBlockSlotCommand : Command
{
    [Inject]
    public IBlockSlotsModel BlockSlotsModel { get; set; }

    [Inject]
    public RemoveBlockSlotSignal RemoveBlockSlotSignal { get; set; }

    [Inject]
    public GenerateBlockTypesInBlockSlotsSignal GenerateBlockTypesInBlockSlotsSignal { get; set; }

    public override void Execute()
    {        
        if (BlockSlotsModel.ActiveBlockSlotsCount <= 0) return;

        RemoveBlockSlotSignal.Dispatch(BlockSlotsModel.LastBlockSlotIndex);
        BlockSlotsModel.ActiveBlockSlotsCount--;

        if (BlockSlotsModel.ActiveBlockSlotsCount <= 0)
        {
            GenerateBlockTypesInBlockSlotsSignal.Dispatch();
        }
    }
}

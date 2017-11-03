using strange.extensions.command.impl;

public class DragEndCommand : Command
{
    [Inject]
    public IBlockSlotsModel BlockSlotsModel { get; set; }

    [Inject]
    public BlockTypeMovedToBoardSignal BlockTypeMovedToBoardSignal { get; set; }

    private DragEndArgs _dragEndArgs;

    public override void Execute()
    {
        GetArgs();
        BlockType blockType = BlockSlotsModel.BlockTypes[_dragEndArgs.BlockSlotIndex];
        BlockSlotsModel.LastBlockSlotIndex = _dragEndArgs.BlockSlotIndex;
        BlockTypeMovedToBoardSignal.Dispatch(new BlockTypeMovedToBoardArgs(blockType, _dragEndArgs.Collider2D));
    }

    private void GetArgs()
    {
        object[] datas = (object[])data;
        _dragEndArgs = (DragEndArgs)datas[0];
    }
}

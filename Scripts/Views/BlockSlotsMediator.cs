using System.Collections.Generic;
using strange.extensions.mediation.impl;
using UnityEngine;

public class BlockSlotsMediator : Mediator
{
    [Inject]	
    public BlockSlotsView View { get; set; }

    [Inject]
    public BlockSlotsGeneratedSignal BlockSlotsGeneratedSignal { get; set; }

    [Inject]
    public DragEndSignal DragEndSignal { get; set; }

    [Inject]
    public RemoveBlockSlotSignal RemoveBlockSlotSignal { get; set; }

    [Inject]
    public ClickSignal ClickSignal { get; set; }

    public override void OnRegister()
    {
        BlockSlotsGeneratedSignal.AddListener(OnBlockSlotsGenerated);
        View.DragStartedViewSignal.AddListener(OnViewDragStarted);
        View.DragEndViewSignal.AddListener(OnDragEndView);
        RemoveBlockSlotSignal.AddListener(OnRemoveBlockSlot);
    }

    public override void OnRemove()
    {
        BlockSlotsGeneratedSignal.RemoveListener(OnBlockSlotsGenerated);
        View.DragStartedViewSignal.RemoveListener(OnViewDragStarted);
        View.DragEndViewSignal.RemoveListener(OnDragEndView);
        RemoveBlockSlotSignal.RemoveListener(OnRemoveBlockSlot);
    }

    private void OnBlockSlotsGenerated(List<BlockType> blockTypes)
    {
        Debug.Log("OnBlockSlotsGenerated");
        View.SetBlockTypeSlotsSprites(blockTypes);
    }

    private void OnViewDragStarted(int blockSlotIndex)
    {
        Debug.Log("OnViewDragStarted " + blockSlotIndex);
        ClickSignal.Dispatch();
    }

    private void OnDragEndView(DragEndViewArgs dragEndViewArgs)
    {
        DragEndSignal.Dispatch(new DragEndArgs(dragEndViewArgs.SlotIndex, dragEndViewArgs.Collider2D));
    }

    private void OnRemoveBlockSlot(int blockSlotIndex)
    {
        View.RemoveBlockSlot(blockSlotIndex);
    }
}

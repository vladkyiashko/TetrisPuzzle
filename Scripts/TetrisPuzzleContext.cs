using System;
using UnityEngine;
using strange.extensions.context.api;
using strange.extensions.context.impl;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.dispatcher.eventdispatcher.impl;
using strange.extensions.command.api;
using strange.extensions.command.impl;

public class TetrisPuzzleContext : MVCSContext
{

    public TetrisPuzzleContext(MonoBehaviour view) : base(view)
    {
    }

    public TetrisPuzzleContext(MonoBehaviour view, ContextStartupFlags flags) : base(view, flags)
    {
    }
    
    protected override void addCoreComponents()
    {
        base.addCoreComponents();
        injectionBinder.Unbind<ICommandBinder>();
        injectionBinder.Bind<ICommandBinder>().To<SignalCommandBinder>().ToSingleton();
    }
    
    public override IContext Start()
    {
        base.Start();
        StartSignal startSignal = injectionBinder.GetInstance<StartSignal>();
        startSignal.Dispatch();
        return this;
    }

    protected override void mapBindings()
    {
        commandBinder.Bind<StartSignal>().To<GenerateBlockTypesInBlockSlotsCommand>().To<InitBoardCommand>().Once();
        commandBinder.Bind<GenerateBlockTypesInBlockSlotsSignal>().To<GenerateBlockTypesInBlockSlotsCommand>();
        commandBinder.Bind<DragEndSignal>().To<DragEndCommand>();
        commandBinder.Bind<TryPlacingBlockTypeAtBoardSignal>().To<TryPlacingBlockTypeAtBoardCommand>();
        commandBinder.Bind<BlockPlacedOnBoardSuccessfullySignal>()
            .To<BlockPlacedOnBoardSuccessfullyCommand>()
            .To<RemoveLastBlockSlotCommand>();
        commandBinder.Bind<BoardRowIsOccupiedSignal>().To<RemoveBoardRowCommand>();

        injectionBinder.Bind<IBlockSlotsModel>().To<BlockSlotsModel>().ToSingleton();
        injectionBinder.Bind<IBoardModel>().To<BoardModel>().ToSingleton();

        injectionBinder.Bind<BlockSlotsGeneratedSignal>().ToSingleton();
        injectionBinder.Bind<BlockTypeMovedToBoardSignal>().ToSingleton();
        injectionBinder.Bind<RemoveBlockSlotSignal>().ToSingleton();
        injectionBinder.Bind<ClickSignal>().ToSingleton();

        mediationBinder.Bind<BlockSlotsView>().To<BlockSlotsMediator>();
        mediationBinder.Bind<BoardView>().To<BoardMediator>();
        mediationBinder.Bind<AudioView>().To<AudioMediator>();
    }
}
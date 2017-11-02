using System;
using System.Collections.Generic;
using UnityEngine;
using strange.extensions.command.impl;
using Random = UnityEngine.Random;

public class GenerateBlockTypesInBlockSlotsCommand : Command
{
    [Inject]
    public IBlockSlotsModel BlockSlotsModel { get; set; }

    [Inject]
    public BlockSlotsGeneratedSignal BlockSlotsGeneratedSignal { get; set; }

    public override void Execute()
    {
        Debug.Log("GenerateBlockTypesInBlockSlotsCommand Execute " + BlockSlotsModel);

        BlockSlotsModel.BlockTypes = GenerateRandomBlockTypes();
        BlockSlotsModel.ActiveBlockSlotsCount = Config.SlotsCount;
        BlockSlotsGeneratedSignal.Dispatch(BlockSlotsModel.BlockTypes);
    }

    private List<BlockType> GenerateRandomBlockTypes()
    {
        List<BlockType> randomBlockTypes = new List<BlockType>();
        for (int i = 0; i < Config.SlotsCount; i++)
        {
            Array values = Enum.GetValues(typeof(BlockType));
            BlockType randomBlockType = (BlockType)Random.Range(0, values.Length);
            randomBlockTypes.Add(randomBlockType);
        }
        return randomBlockTypes;
    }    
}

using System;
using System.Collections.Generic;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using UnityEngine;

public class BlockSlotsView : View
{
    public Signal<int> DragStartedViewSignal = new Signal<int>();
    public Signal<DragEndViewArgs> DragEndViewSignal = new Signal<DragEndViewArgs>();

    private readonly Vector3 BlockSlotScale = new Vector3(0.3f, 0.3f, 0.3f);
    private readonly Vector3 BlockDragScale = new Vector3(0.5f, 0.5f, 0.5f);

    [SerializeField] private Transform[] _blockSlotPositions;

    [SerializeField] private GameObject _blockTypeIPrefab;
    [SerializeField] private GameObject _blockTypeJPrefab;
    [SerializeField] private GameObject _blockTypeLPrefab;
    [SerializeField] private GameObject _blockTypeOPrefab;
    [SerializeField] private GameObject _blockTypeSPrefab;
    [SerializeField] private GameObject _blockTypeTPrefab;
    [SerializeField] private GameObject _blockTypeZPrefab;

    private Dictionary<BlockType, GameObject> _blockTypePrefabs;

    private void OnEnable()
    {
        DragDetector.DragStarted += OnDragDetectorOnDragStarted;
        DragDetector.DragEnded += DragDetectorOnDragEnded;
    }    

    private void OnDisable()
    {
        DragDetector.DragStarted -= OnDragDetectorOnDragStarted;
        DragDetector.DragEnded -= DragDetectorOnDragEnded;
    }

    protected override void Awake()
    {
        _blockTypePrefabs = new Dictionary<BlockType, GameObject>
        {
            { BlockType.I, _blockTypeIPrefab },
            { BlockType.J, _blockTypeJPrefab },
            { BlockType.L, _blockTypeLPrefab },
            { BlockType.O, _blockTypeOPrefab },
            { BlockType.S, _blockTypeSPrefab },
            { BlockType.T, _blockTypeTPrefab },
            { BlockType.Z, _blockTypeZPrefab }
        };
    }

    public void SetBlockTypeSlotsSprites(List<BlockType> blockTypes)
    {
        ClearBlockSlotPositionsChilds();
        for (int i = 0; i < blockTypes.Count; i++)
        {
            BlockType blockType = blockTypes[i];
            GameObject blockTypePrefab = _blockTypePrefabs[blockType];
            GameObject block = Instantiate(blockTypePrefab, _blockSlotPositions[i], false);
            block.GetComponent<Transform>().localScale = BlockSlotScale;
        }
    }

    public void RemoveBlockSlot(int blockSlotIndex)
    {
        foreach (Transform blockSlotPositionChild in _blockSlotPositions[blockSlotIndex])
        {
            Destroy(blockSlotPositionChild.gameObject);
        }
    }

    private void OnDragDetectorOnDragStarted(int blockSlotIndex)
    {
        DragStartedViewSignal.Dispatch(blockSlotIndex);
        _blockSlotPositions[blockSlotIndex].GetChild(0).localScale = BlockDragScale;
    }

    private void DragDetectorOnDragEnded(int blockSlotIndex)
    {
        _blockSlotPositions[blockSlotIndex].GetChild(0).localScale = BlockSlotScale;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);        
        Debug.Log("DragDetectorOnDragEnded " + hit.collider);
        if (hit.collider != null)
        {
            DragEndViewSignal.Dispatch(new DragEndViewArgs(blockSlotIndex, hit.collider));
        }        
    }    

    private void ClearBlockSlotPositionsChilds()
    {
        foreach (Transform blockSlotPosition in _blockSlotPositions)
        {
            foreach (Transform blockSlotPositionChild in blockSlotPosition)
            {
                Destroy(blockSlotPositionChild.gameObject);
            }
        }
    }
}

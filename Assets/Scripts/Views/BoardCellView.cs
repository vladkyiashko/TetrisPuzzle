using strange.extensions.mediation.impl;
using UnityEngine;

public class BoardCellView : View
{
    [SerializeField]
    private CellCoordinates _cellCoordinates;

    public CellCoordinates CellCoordinates
    {
        get { return _cellCoordinates; }
    }

    public SpriteRenderer SpriteRenderer { get; private set; }

    protected override void Awake()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }
}
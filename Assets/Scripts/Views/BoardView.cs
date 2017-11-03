using System.Collections.Generic;
using strange.extensions.mediation.impl;
using UnityEngine;

public class BoardView : View
{
    private List<BoardCellView> _boardCellViews;

    private Dictionary<CellCoordinates, SpriteRenderer> _boardCellSpriteRenderers;

    protected override void Awake()
    {
        InitBoardCellViews();
        InitBoardCellSpriteRenderers();
    }

    private void InitBoardCellViews()
    {
        _boardCellViews = new List<BoardCellView>();
        foreach (Transform child in transform)
        {
            BoardCellView boardCellView = child.GetComponent<BoardCellView>();
            if (boardCellView != null)
            {
                _boardCellViews.Add(boardCellView);
            }
        }
        Debug.Log(_boardCellViews);
    }

    private void InitBoardCellSpriteRenderers()
    {
        _boardCellSpriteRenderers = new Dictionary<CellCoordinates, SpriteRenderer>();
        foreach (BoardCellView boardCellView in _boardCellViews)
        {
            _boardCellSpriteRenderers.Add(boardCellView.CellCoordinates, boardCellView.SpriteRenderer);
        }
        Debug.Log(_boardCellSpriteRenderers);
    }

    public void ToggleCell(CellCoordinates cellCoordinates, bool active)
    {
        _boardCellSpriteRenderers[cellCoordinates].enabled = active;
    }
}

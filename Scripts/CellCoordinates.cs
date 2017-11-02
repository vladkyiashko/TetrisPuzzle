using System;
using UnityEngine;

[Serializable]
public struct CellCoordinates
{
    [SerializeField]
    private int _x;
    [SerializeField]
    private int _y;

    public CellCoordinates(int x, int y) : this()
    {
        _x = x;
        _y = y;
    }

    public int X
    {
        get { return _x; }
    }

    public int Y
    {
        get { return _y; }
    }
}
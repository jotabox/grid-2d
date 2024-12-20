using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private BoardManager _boardManager;
    private Vector2Int playerPosition;

    public void Spawn(BoardManager boardManager , Vector2Int cell)
    {
        _boardManager = boardManager;
        playerPosition = cell;

        transform.position = _boardManager.CellToWorld(cell);
    }

}

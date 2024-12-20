using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private BoardManager _boardManager;
    private Vector2Int _playerPosition;

    public void Spawn(BoardManager boardManager, Vector2Int cell)
    {
        _boardManager = boardManager;
        _playerPosition = cell;

        transform.position = _boardManager.CellToWorld(cell);
    }

    public void MoveTo(Vector2Int cell) {
        _playerPosition = cell;
        transform.position = _boardManager.CellToWorld(_playerPosition);
    }

    private void Update()
    {
        Vector2Int newCellTarget = _playerPosition;
        bool hasMoved = false;

        if (Keyboard.current.upArrowKey.wasPressedThisFrame)
        {
            newCellTarget.y += 1;
            hasMoved = true;
        }
        else if (Keyboard.current.downArrowKey.wasPressedThisFrame)
        {
            newCellTarget.y -= 1;
            hasMoved = true;
        }
        else if (Keyboard.current.rightArrowKey.wasPressedThisFrame)
        {
            newCellTarget.x += 1;
            hasMoved = true;
        }
        else if (Keyboard.current.leftArrowKey.wasPressedThisFrame)
        {
            newCellTarget.x -= 1;
            hasMoved = true;
        }

        if (hasMoved)
        {
            BoardManager.CellData cellData = _boardManager.GetCellData(newCellTarget);

            if (cellData != null && cellData.Passable)
            {
                MoveTo(newCellTarget);
            }


        }

    }
}

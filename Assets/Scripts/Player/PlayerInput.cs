using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMove))]
public class PlayerInput : MonoBehaviour
{
    private PlayerMove _playerMove;

    private void Awake()
    {
        _playerMove = GetComponent<PlayerMove>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) 
        {
            _playerMove.TryMoveUp();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            _playerMove.TryMoveDown();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _stepSize;
    [SerializeField] private float _minHeight;
    [SerializeField] private float _maxHeight;

    private Rigidbody2D _rigidbody2D;
    private Vector3 _targetPosition;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _targetPosition = transform.position;
    }

    private void FixedUpdate()
    {
        _rigidbody2D.MovePosition(Vector2.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime));
    }

    public void TryMoveUp()
    {
        if(_targetPosition.y < _maxHeight)
        {
            SetNextPosition(_stepSize);
        }
    }

    public void TryMoveDown()
    {
        if (_targetPosition.y > _minHeight)
        {
            SetNextPosition(-_stepSize);
        }
    }

    private void SetNextPosition(float stepSize) 
    {
        _targetPosition = new Vector2(_targetPosition.x, _targetPosition.y + stepSize);
    }
}

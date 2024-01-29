using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CarMovementSystem : MonoBehaviour
{
    #region Variables

    [SerializeField] private MovementBlocker forwardBlocker;
    [SerializeField] private MovementBlocker backBlocker;

    [SerializeField] private float carMovementSpeed = 10;
    
    private bool _canMove = false;

    private Vector3 _localMovementDirection;

    private Vector3 _previousMousePosition;

    private readonly float _dragThreshHold = 0.1f;

    private Rigidbody _rigidbody;
    
    #endregion

    #region Public Methods

    

    #endregion

    #region Unity Callbacks

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnMouseDrag()
    {
        CalculateMovementDirection(Input.mousePosition, _previousMousePosition);

        _previousMousePosition = Input.mousePosition;
    }

    private void CalculateMovementDirection(Vector3 currentMousePosition, Vector3 previousMousePosition)
    {
        Vector3 mouseDelta = currentMousePosition - previousMousePosition;
        mouseDelta.z = mouseDelta.y;
        mouseDelta.y = 0;

        float mouseDeltaDotLocalForward = Vector3.Dot(transform.forward, mouseDelta);

        if (mouseDeltaDotLocalForward > _dragThreshHold && forwardBlocker.CanMove)
            _localMovementDirection = transform.forward;
        else if (mouseDeltaDotLocalForward < -_dragThreshHold && backBlocker.CanMove)
            _localMovementDirection = -transform.forward;
        else 
        {
            //Debug.Log("Called");
            
            if (!forwardBlocker && !backBlocker)
            {
                _localMovementDirection = Vector3.zero;
                
            }

        }
             
    }

    private void OnMouseDown()
    {
        _canMove = true;
        _previousMousePosition = Input.mousePosition;
        
    }

    private void OnMouseUp()
    {
        _canMove = false;
        _localMovementDirection = Vector3.zero;
    }

    private void FixedUpdate()
    {
        if (_canMove)
            MoveCarOneStep();

    }

    #endregion

    #region Private Methods
    
    private void MoveCarOneStep()
    {
        if (transform.forward == _localMovementDirection && forwardBlocker.CanMove)
            _rigidbody.MovePosition(_rigidbody.position + (_localMovementDirection * carMovementSpeed));

        if (-transform.forward == _localMovementDirection && backBlocker.CanMove)
            _rigidbody.MovePosition(_rigidbody.position + (_localMovementDirection * carMovementSpeed));
    }

    #endregion
}

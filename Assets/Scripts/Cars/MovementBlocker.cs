using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBlocker : MonoBehaviour
{
    #region Variables

    public bool CanMove { get; private set; } = true;

    #endregion

    #region Public Methods



    #endregion

    #region Unity Callbacks

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car") || other.CompareTag("Boarder"))
        {
            if (other.transform == transform.parent)
                return;
            
            CanMove = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Car") || other.CompareTag("Boarder"))
        {
            CanMove = true;
        }
    }

    #endregion

    #region Private Methods



    #endregion
}

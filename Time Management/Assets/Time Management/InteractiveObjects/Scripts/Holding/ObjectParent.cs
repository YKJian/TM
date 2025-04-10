using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class ObjectParent : MonoBehaviour
{
    [SerializeField] private Transform _holdPoint;
    [SerializeField] internal GameObject _kidObject;

    public Transform GetParentHoldPoint()
    {
        return _holdPoint;
    }

    private void SetKidObject(GameObject kidObject)
    {
        _kidObject = kidObject;
        _kidObject.GetComponent<Object>().SetObjectParent(this.gameObject);
    }

    public void SwitchParentFor(GameObject newParent)
    {
        newParent.TryGetComponent<ObjectParent>(out var n);

        // Player has
        if ((_kidObject != null) && (n._kidObject == null))
        {
            n.SetKidObject(_kidObject);
            _kidObject = null;
            return;
        }

        // Player doesn't
        if ((_kidObject == null) && (n._kidObject != null))
        {
            SetKidObject(n._kidObject);
            n._kidObject = null;
        }
    }
}

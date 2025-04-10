using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    [SerializeField] internal GameObject _objectParent;

    public void SetObjectParent(GameObject objectParent)
    {
        _objectParent = objectParent;
        Transform parentHoldPoint = _objectParent.GetComponent<ObjectParent>().GetParentHoldPoint();
        transform.SetParent(parentHoldPoint);
        transform.position = parentHoldPoint.position;
    }
}

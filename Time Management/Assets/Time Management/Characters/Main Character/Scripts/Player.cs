using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Scripting.APIUpdating;

public class Player : MonoBehaviour
{
    private PlayerInput _inputs;
    [SerializeField] private float _speed;

    [SerializeField] private Transform _floorCheckerPivot;
    [SerializeField] private float _checkFloorRadius;
    [SerializeField] private LayerMask _floorMask;

    [SerializeField] private GameObject _interactionText;
    [SerializeField] private GameObject _noteUI;

    private Rigidbody _rb;
    private bool _isGrounded;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();

        _inputs = new PlayerInput();
        _inputs.Player.Enable();

        _inputs.Player.Jump.performed += Jump_performed;
    }

    private void FixedUpdate()
    {
        Walk();
        _isGrounded = IsOnTheGround();
    }

    private void OnTriggerStay(Collider other)
    {
        _interactionText.SetActive(true);
        if (_inputs.Player.Interact.WasPerformedThisFrame())
        {
            if (other.gameObject.tag == "Notes")
            {
                _noteUI.SetActive(true);
            }
            if (other.GetComponent<ObjectParent>())
            {
                GetComponent<ObjectParent>().SwitchParentFor(other.gameObject);
            }

            if (other.TryGetComponent<FastCompletable>(out var f))
            {
                f.CompleteTask();
                GetComponent<CountTasks>().AddScore(1);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        _interactionText.SetActive(false);
        _noteUI.SetActive(false);
    }

    private void Walk()
    {
        Vector2 inputVector = _inputs.Player.Walk.ReadValue<Vector2>();

        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);

        // TransformDirection: world ---> local
        transform.position += transform.TransformDirection(moveDir) * _speed * Time.deltaTime;
    }

    private void Jump_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (_isGrounded) 
        {
            Vector3 moveDir = new Vector3(0f, 0.5f, 0f);
            _rb.AddForce(moveDir, ForceMode.Impulse);
        }
    }

    private bool IsOnTheGround()
    {
        // от какой точки, r , с чем взаимодействует
        bool result = Physics.CheckSphere(_floorCheckerPivot.position, _checkFloorRadius, _floorMask);
        return result;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerController : MonoBehaviour
{
    private Animator _animator;
    private bool _isHitting = false;

    [SerializeField] private Camera _mainCam;
    [SerializeField] private LayerMask _layerMask;

    void Start()
    {
        _animator = this.GetComponent<Animator>();
    }
    public void Update()
    {
        if (Time.timeScale != 0)
        {
            Ray _ray = _mainCam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(_ray, out RaycastHit _raycastHit, float.MaxValue, _layerMask))
            {
                transform.position = _raycastHit.point;
            }
        }

        if (Input.GetMouseButtonDown(0))
            _isHitting = true;
    }
    public void FixedUpdate()
    {
        Hit();
    }
    public void Hit()
    {
        if (!_isHitting)
            return;

        _isHitting = false;
        _animator.SetTrigger("Hit");
    }
    private void SetIsHittingFales()
    {
        _isHitting = false;
    }
}


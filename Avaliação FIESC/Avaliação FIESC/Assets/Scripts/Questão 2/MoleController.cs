using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleController : MonoBehaviour
{
    private GameManager _gameManager;
    private CapsuleCollider _capCollider;
    private Animator _animator;
    //private bool _isHit = false;

    void Start()
    {
        _animator = this.GetComponentInParent<Animator>();
        _capCollider = this.GetComponent<CapsuleCollider>();
        _gameManager = FindObjectOfType<GameManager>();
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Hammer")
            return;

        _gameManager.IncrementScore();
        _animator.Play("Hide");
        _animator.speed = 5f;
    }
}

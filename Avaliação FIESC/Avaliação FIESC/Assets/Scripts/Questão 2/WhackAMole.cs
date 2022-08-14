using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class WhackAMole : MonoBehaviour
{
    [SerializeField] private List<GameObject> _moles;
    private float _timerMole;
    private float _interval;
    private float _increment = 0f;

    public void Start()
    {
        _increment = 0f;
        //moles.ForEach(x => x.GetComponentInChildren<CapsuleCollider>().enabled = false);
        _timerMole = 80;
        _interval = 80;
    }
    public void FixedUpdate()
    {
        _timerMole -= 1;
        if (_timerMole <= 0)
        {
            ActiveMole();
            if (_interval > 10)
            {
                _interval -= 2;
            }
            _timerMole = _interval;
        }
    }

    public void ActiveMole()
    {

        var _moleToActive = Random.Range(0, _moles.Count);
        var _selectedMole = _moles[_moleToActive];

        var _selectedMoleAnimator = _selectedMole.GetComponent<Animator>();
        if (!_selectedMoleAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            return;

        //selectedMole.GetComponentInChildren<CapsuleCollider>().enabled = true;
        _selectedMoleAnimator.speed = 1;
        if (_interval < 70)
        {
            if (_increment < 1)
                _increment += 0.1f;
            _selectedMoleAnimator.speed += _increment;
        }
        _selectedMoleAnimator.SetTrigger("Show");
    }
}

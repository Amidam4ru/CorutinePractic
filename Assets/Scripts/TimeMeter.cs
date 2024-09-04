using System.Collections;
using UnityEngine;
using TMPro;
using System;

public class TimeMeter : MonoBehaviour
{
    [SerializeField] private float _delay = 0.5f;
    [SerializeField] private RegisterationMouseClick _mouseClick;

    private bool _isWork;
    private int _counter;
    private WaitForSeconds waitingTime;

    public event Action TimeChange;


    private void Start()
    {
        waitingTime = new WaitForSeconds(_delay);
        _isWork = false;
    }

    private void OnEnable()
    {
        _mouseClick.MouseClick += ChangeState;
    }

    private void OnDisable()
    {
        _mouseClick.MouseClick -= ChangeState;
    }

    private void ChangeState()
    {
        _isWork = !_isWork;

        if (_isWork)
        {
            StartCoroutine(IncreaseCounter(_delay));
        }
    }

    private IEnumerator IncreaseCounter(float delay)
    {
        while (_isWork)
        {
            TimeChange?.Invoke();
            yield return waitingTime;
        }
    }
}

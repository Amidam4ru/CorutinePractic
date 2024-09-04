using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
[RequireComponent(typeof(TimeMeter))]

public class Counter : MonoBehaviour
{
    private TimeMeter _timeMeter;
    private TextMeshProUGUI _text;
    private int _counter;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
        _timeMeter = GetComponent<TimeMeter>();
        _counter = 0;
    }

    private void OnEnable()
    {
        _timeMeter.TimeChange += IncreaseCounter;
    }

    private void OnDisable()
    {
        _timeMeter.TimeChange -= IncreaseCounter;
    }

    private void IncreaseCounter()
    {
        _counter++;
        _text.text = "Counter: " + _counter.ToString();
    }
}

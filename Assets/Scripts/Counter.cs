using System.Collections;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]

public class Counter : MonoBehaviour
{
    [SerializeField] private float _delay = 0.5f;
    [SerializeField] private RegisterMouseClick _mouseClick;

    private bool _isWork;
    private int _counter;
    private TextMeshProUGUI _text;

    private void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
        _counter = 0;
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
        WaitForSeconds wait = new WaitForSeconds(delay);
        while (_isWork)
        {
            _counter++;
            _text.text = "Counter: " + _counter.ToString();
            
            yield return wait;
        }
    }
}

using System;
using UnityEngine;

public class RegisterationMouseClick : MonoBehaviour
{
    private int _idLeftMouseButton;

    public event Action MouseClick;

    private void Awake()
    {
        _idLeftMouseButton = 0;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(_idLeftMouseButton))
        {
            MouseClick?.Invoke();
        }
    }
}

using System;
using UnityEngine;

public class RegisterationMouseClick : MonoBehaviour
{
    public event Action MouseClick;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MouseClick?.Invoke();
        }
    }
}

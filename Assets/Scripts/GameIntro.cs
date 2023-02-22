using System;
using UnityEngine;

public class GameIntro : MonoBehaviour
{
    public static event Action OnStarted;

    private bool _isStarted = false;

    private void Update()
    {
        if (_isStarted) return;

        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            _isStarted = true;

            OnStarted?.Invoke();
        }
    }
}
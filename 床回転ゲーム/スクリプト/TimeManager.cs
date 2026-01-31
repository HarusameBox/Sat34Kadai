using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using TMPro;
using System;
using Random = UnityEngine.Random;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private float _waitingTimeToSpin;

    [SerializeField] private SpinningFloor _spinningFloor;

    [SerializeField] private TextMeshProUGUI _textMeshProUGUI;

    [SerializeField] private bool _isRotateStart;

    private void Start()
    {
        _waitingTimeToSpin = Random.Range(5.0f, 10.0f);
        _textMeshProUGUI.text = _waitingTimeToSpin.ToString("f1");
    }

    private void Update()
    {
        _waitingTimeToSpin -= Time.deltaTime;
        if (_waitingTimeToSpin >= 0)
        {
            _textMeshProUGUI.text = _waitingTimeToSpin.ToString("f1");
        }
        else
        {
            _textMeshProUGUI.text = "0";
            if (!_isRotateStart)
            {
                _spinningFloor.SpinFloor();
                _isRotateStart = true;
            }

        }
    }


}

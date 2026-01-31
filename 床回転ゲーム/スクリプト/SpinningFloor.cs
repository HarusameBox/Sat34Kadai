using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using System;
using DG.Tweening;

public class SpinningFloor : MonoBehaviour
{
    [SerializeField] private float _howManyRolling;

    [SerializeField] private float _spinTime;

    [SerializeField] private KnocksPlayer _knocksPlayer;

    public void SpinFloor()
    {
        transform.DORotate(Vector3.forward * _howManyRolling, _spinTime, RotateMode.LocalAxisAdd);
        _knocksPlayer.FlyAway();
    }

}

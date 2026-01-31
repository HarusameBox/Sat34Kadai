using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using Random = UnityEngine.Random;

public class FloorDeleter : MonoBehaviour
{
    [SerializeField] private FloorManager _floorManager;

    private List<GameObject> _floors;

    [Header("床が消滅＆復活までの猶予"), SerializeField] private float _delayTime;

    [Header("最低でも削る床の数"), SerializeField] private int _minDeleteAmount = 0;

    [Header("最低でも残ってほしい床の数"), SerializeField] private int　_minRemainAmount = 10;

    private void Awake()
    {
        _floors = _floorManager.FloorsGetter;
        foreach (GameObject floor in _floors)
        {
            floor.SetActive(true);
        }
        DeleteRandomFloors();
    }

    async private void DeleteRandomFloors()
    {
        int deleteNumAmount = Random.Range(_minDeleteAmount, _floors.Count - _minRemainAmount + 1);

        List<int> usedNum = new List<int>();

        await UniTask.Delay(TimeSpan.FromSeconds(_delayTime));

        for (int i = 0; i < deleteNumAmount; i++)
        {
            int deleteSoonNum;

            do
            {
                deleteSoonNum = Random.Range(0, _floors.Count);
            }
            while (usedNum.Contains(deleteSoonNum));

            usedNum.Add(deleteSoonNum);
            _floors[deleteSoonNum].SetActive(false);
        }

        await UniTask.Delay(TimeSpan.FromSeconds(_delayTime));

        foreach (int num in usedNum)
        {
            _floors[num].SetActive(true);
        }

        ReduceDeleteTime();
        UpMinDeleteAmount();
        DeleteRandomFloors();

    }
    
    private void ReduceDeleteTime()
    {
        if (_delayTime > 2f)
        {
            _delayTime -= 0.05f;
        }
    }

    private void UpMinDeleteAmount()
    {  
        if (_minDeleteAmount != _floors.Count - _minRemainAmount)
        {
            _minDeleteAmount += 1;
        }

    }
}

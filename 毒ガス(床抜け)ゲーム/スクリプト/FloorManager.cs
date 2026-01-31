using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-100)]

public class FloorManager : MonoBehaviour
{
    [SerializeField] private GameObject _floorParent;

    [SerializeField] private List<GameObject> _floors;

    private void Awake()
    {
        _floors = new List<GameObject>();

        for (int i = 0; i < _floorParent.transform.childCount; i++)
        {
            _floors.Add(_floorParent.transform.GetChild(i).gameObject);
        }
    }

    public List<GameObject> FloorsGetter
    {
        get { return _floors; }
    }
}

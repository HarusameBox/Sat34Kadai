using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorMaterialSet : MonoBehaviour
{
    [SerializeField] private List<Material> _materials;
    [SerializeField] private FloorManager _floorManager;
    

    private void Awake()
    {
        
    }
}

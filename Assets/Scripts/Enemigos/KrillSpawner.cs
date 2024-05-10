using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KrillSpawner : MonoBehaviour
{
    private Transform _transform;
    private Vector2 initialPosition;

    void Start()
    {
        _transform = this.gameObject.transform;
        initialPosition = _transform.position;
    }
    
    }

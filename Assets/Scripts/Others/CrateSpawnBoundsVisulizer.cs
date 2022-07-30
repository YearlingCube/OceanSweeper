using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class CrateSpawnBoundsVisulizer : MonoBehaviour
{
    /*
        Only Here To Visulize Crate Spawn Boundries / Not Needed
     */
    public Vector2 _BoundsMin;

    public Vector2 _BoundsMax;

    private BoxCollider2D _BoxCol;

    void Awake()
    {
        _BoxCol = GetComponent<BoxCollider2D>();

        _BoundsMax = _BoxCol.bounds.max;
        _BoundsMin = _BoxCol.bounds.min;
    }
}
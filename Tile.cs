using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{

    /// <summary>
    /// This script will create a grid of invisible objects to snap the cones to
    /// </summary>

    [SerializeField]
    private GameObject _gridTile;

    void Start()
    {

        for (int i = 0; i < 11; i++)
        {
            for (int j = 0; j < 11; j++)
            {
                Instantiate(_gridTile, new Vector3(i * 3.6875f - 39.5f, 1.55f, j * 3.6875f - 39.5f), Quaternion.identity);
            }
        }
    }
}
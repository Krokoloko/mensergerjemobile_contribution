using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSnap : MonoBehaviour {

    /// <summary>
    /// This script will snap the cones to a grid
    /// </summary>

    void OnTriggerStay(Collider other)
    {
        if (Input.touchCount == 0 && !Input.GetMouseButton(0))
        {
            if (other.tag == "GridTile")
            {
                transform.localPosition = new Vector3(other.transform.localPosition.x, 0f, other.transform.localPosition.z);
            }
        }
    }
}

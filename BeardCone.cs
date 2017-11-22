using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeardCone : MonoBehaviour
{

    /// <summary>
    /// This script will move the position of the Beard Cones
    /// This script also sends the command to switch turns
    /// </summary>

    private InputManager _inputManager;
    private string _colour = "Cone-Red";
    public string currentColour;
    private PlayerTurn _turn;

    void Start()
    {
        _inputManager = GetComponent<InputManager>();
        _turn = GetComponent<PlayerTurn>();
    }

    void Update()
    {
        switch (currentColour)
        {
            case ("green"):
                _colour = "Cone-Green";
                break;
            case ("yellow"):
                _colour = "Cone-Yellow";
                break;
            case ("red"):
                _colour = "Cone-Red";
                break;
            case ("blue"):
                _colour = "Cone-Blue";
                break;
        }

        // Debug
        /*
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 100);
            if (Physics.Raycast(ray.origin, ray.direction, out hit))
            {
                if (hit.collider.tag == "Cone-Green" || hit.collider.tag == "Cone-Blue" || hit.collider.tag == "Cone-Red" || hit.collider.tag == "Cone-Yellow")
                {
                    Debug.Log("colliding with green");
                    Transform cone = hit.collider.GetComponent<Transform>();
                    cone.transform.position = new Vector3(hit.point.x, 1.6f, hit.point.z);
                }
                if (hit.collider.tag == "nextButton")
                {
                    _turn.NextPlayer();
                }
            }

        }
        */
        // End of debug

        if (_inputManager.OneFinger())
        {
            DragCone();
        }
    }

    // Drags the cone
    void DragCone()
    {
        Touch zero = _inputManager.touchZero;
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(zero.position);
        Debug.DrawRay(ray.origin, ray.direction * 100);
        if (Physics.Raycast(ray.origin, ray.direction, out hit))
        {
            if (hit.collider.tag == "Cone-Green" || hit.collider.tag == "Cone-Blue" || hit.collider.tag == "Cone-Red" || hit.collider.tag == "Cone-Yellow")
            {
                Transform cone = hit.collider.GetComponent<Transform>();
                cone.transform.position = new Vector3(hit.point.x, 1.6f, hit.point.z);
            }
            if (hit.collider.tag == "nextButton")
            {
                _turn.NextPlayer();
            }
        }

    }
}

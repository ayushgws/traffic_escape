using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehiclePoint : MonoBehaviour
{
    [SerializeField] private Canvas _canvas;

    [SerializeField] private float speed = 1f;
    [SerializeField] private ObjectDirection direction;
    [SerializeField] private Direction ownDirection;
    [SerializeField] private Vehicle vehicle;

    private void Start()
    {
        _canvas.worldCamera = Camera.main;
        vehicle.SetDirections(direction, ownDirection);
    }

    private void OnMouseDown()
    {
        vehicle.StartMoving();
    }


}

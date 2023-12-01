using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VehiclePoint : MonoBehaviour
{
    [SerializeField] private Canvas _canvas;

    [SerializeField] private float speed = 1f;
    [SerializeField] private ObjectDirection direction;
    [SerializeField] private Direction ownDirection;
    [SerializeField] private Vehicle vehicle;
    [SerializeField] private Image directionImage;
    [SerializeField] private Sprite spriteStraight;
    [SerializeField] private Sprite spriteLeft;
    [SerializeField] private Sprite spriteRight;

    private void Start()
    {
        _canvas.worldCamera = Camera.main;
        vehicle.SetDirections(direction, ownDirection);
        vehicle.SetSpeed(speed);
        SetArrow();
        
    }

    public Vehicle GetVehicle() { return vehicle; }

  

    public void SetArrow()
    {
        switch(direction)
        {
            case ObjectDirection.Left:
                directionImage.sprite = spriteLeft;
                break;
                case ObjectDirection.Right:
                directionImage.sprite = spriteRight;
                break;
            case ObjectDirection.Straight:
                directionImage.sprite =spriteStraight;
                break;
        }
    }
}

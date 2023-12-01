using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{

    [SerializeField] private Canvas _canvas;
    [SerializeField] private Vehicle_AudioSound _audioSound;

    [SerializeField] private float speed = 1f;
    private ObjectDirection direction;
    private Direction ownDirection;

    private Vector3 moveDirection = Vector3.forward;

    private bool b_move;
    private bool returnBack = false;
    private bool checkSquare = false;
    private Vector3 squarePosition;
    private GameObject square;
    private bool turnTaken;
    private bool destroyed;
    public void SetDirections(ObjectDirection direction,Direction ownDirection)
    {
        this.direction = direction;
        this.ownDirection = ownDirection;
    }
    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }

    void Start()
    {

        LevelManager.Instance().AddSpaceShip();
       
    }

    // Update is called once per frame
    void Update()
    {
        MoveObject();

    }

    public void MoveObject()
    {
        if (b_move)
        {
            transform.Translate(moveDirection * speed * Time.deltaTime);
          
            if (checkSquare)
            {
            
              
                if (ownDirection == Direction.Left || ownDirection == Direction.Right)
                {

                    if (Mathf.Abs(transform.position.x - squarePosition.x) < 0.1f)
                    {
                        Turn();

                    }
                }

                else if (ownDirection == Direction.Up || ownDirection == Direction.Down)
                {
                    if (Mathf.Abs(transform.position.z - squarePosition.z) < 0.1f)
                    {
                        Turn();

                    }
                }

            }
        }
    }

    public void StartMoving()
    {
        //_audioSound.MoveSound();
        LevelManager.Instance().Move();
        
        _canvas.gameObject.SetActive(false);
        b_move = true;
    }
    void StopMoving()
    {
        LevelManager.Instance().CheckMove();
        b_move = false;
    }

    private void OnMouseDown()
    {
        if (!LevelManager.Instance().isMoving() && !LevelManager.Instance().IsPaused())
            StartMoving();
    }

    private void Turn()
    {
        checkSquare = false;
        if (!returnBack)
        {
            switch (direction)
            {
                case ObjectDirection.Straight:

                    break;
                case ObjectDirection.Left:
                    switch (ownDirection)
                    {
                        case Direction.Right:
                            ownDirection = Direction.Up;
                            break;
                        case Direction.Left:
                            ownDirection = Direction.Down;
                            break;
                        case Direction.Down:
                            ownDirection = Direction.Right;
                            break;
                        case Direction.Up:
                            ownDirection = Direction.Left;
                            break;
                    }


                    transform.Rotate(0, -90, 0);
                    break;
                case ObjectDirection.Right:

                    switch (ownDirection)
                    {
                        case Direction.Right:

                            ownDirection = Direction.Down;
                            break;
                        case Direction.Left:
                            ownDirection = Direction.Up;
                            break;
                        case Direction.Down:
                            ownDirection = Direction.Left;
                            break;
                        case Direction.Up:
                            ownDirection = Direction.Right;
                            break;
                    }

                    transform.Rotate(0, 90, 0);
                    break;

            }
            turnTaken = true;
        }
        else// For Returning Back
        {
            
                
                switch (direction)
                {
                    case ObjectDirection.Straight:

                        break;
                    case ObjectDirection.Left:
                        switch (ownDirection)
                        {
                            case Direction.Right:

                                ownDirection = Direction.Down;
                                break;
                            case Direction.Left:
                                ownDirection = Direction.Up;
                                break;
                            case Direction.Down:
                                ownDirection = Direction.Left;
                                break;
                            case Direction.Up:
                                ownDirection = Direction.Right;
                                break;
                        }

                        transform.Rotate(0, 90, 0);
                        break;
                    case ObjectDirection.Right:
                        switch (ownDirection)
                        {
                            case Direction.Right:

                                ownDirection = Direction.Up;
                                break;
                            case Direction.Left:
                                ownDirection = Direction.Down;
                                break;
                            case Direction.Down:
                                ownDirection = Direction.Right;
                                break;
                            case Direction.Up:
                                ownDirection = Direction.Left;
                                break;
                        }


                        transform.Rotate(0, -90, 0);
                        break;

                
            }
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Square")
        {
             if (!turnTaken)
            {
                if ((returnBack && square == other.gameObject || !returnBack)){
                    square = other.gameObject;
                  checkSquare = true;
                    squarePosition = other.transform.position;
                }
            }
        }
        if (other.transform.tag == "FinishLine")
        {
            if (!destroyed)
            {
                LevelManager.Instance().CheckSpaceShipCount();
                LevelManager.Instance().ScoreCount();
                LevelManager.Instance().StopMoving();
                LevelManager.Instance().CheckMove();
                destroyed = true;
                Destroy(gameObject);
            }
        }

        if(other.transform.tag =="VehiclePoint")
        {
            if (other.GetComponent<VehiclePoint>().GetVehicle() == this)
            {
                _canvas.gameObject.SetActive(true);
                turnTaken = false;
                StopMoving();
                LevelManager.Instance().StopMoving();
                LevelManager.Instance().CheckMove();
                returnBack = false;
                moveDirection = Vector3.forward;
            }
        }

    }

    private void OnCollisionEnter(Collision collision)
    { 
        if (b_move && collision.gameObject.tag == "Vehicle")
        {
            _audioSound.CollisionSound();
            moveDirection = Vector3.back;
           // _audioSound.ReturnSound();
            returnBack = true;
            turnTaken = false;
        }
    }
}

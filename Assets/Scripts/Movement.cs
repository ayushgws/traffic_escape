using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public enum ObjectDirection
{
    Straight,
    Left,
    Right

}
public enum Direction
{
    Up,
    Down,
    Left,
    Right

}
public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody _rigidbody;

    
    [SerializeField] private float speed = 1f;
    [SerializeField] private ObjectDirection direction;
    [SerializeField] private Direction ownDirection;
    
    private Direction initialDirection;

    private Vector3 moveDirection = Vector3.forward;

    private bool b_move;
    private bool returnBack = false;
    private bool checkSquare = false;
    private Vector3 initialposition;
    private Vector3 squarePosition;
    
    

    void Start()
    {

        LevelManager.Instance().AddSpaceShip();
        _rigidbody = GetComponent<Rigidbody>();
        initialposition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        MoveObject();
       
    }

    public void MoveObject()
    {
        if(b_move)
        {
            transform.Translate(moveDirection * speed * Time.deltaTime);

            if(checkSquare)
            {
               
                if (ownDirection == Direction.Left || ownDirection == Direction.Right)
                {
                    
                    if(Mathf.Abs(transform.position.x - squarePosition.x) < 0.05f)
                    {
                        Turn();
                        
                    }
                }

                else if (ownDirection == Direction.Up || ownDirection == Direction.Down)
                {
                    if (Mathf.Abs(transform.position.z - squarePosition.z) < 0.05f)
                    {
                        Turn();
                        
                    }
                }



            }

            if (returnBack && Vector3.Distance(transform.position, initialposition) < 0.1f)
            {
                StopMoving();
                returnBack = false;
                moveDirection = Vector3.forward;
            }


            //if (returnBack)
            //{

            //    if (initialDirection == Direction.Left || initialDirection == Direction.Right)
            //    {

            //        if (Mathf.Abs(transform.position.x - initialposition.x) < 0.05f)
            //        {
            //            StopMoving();
            //            returnBack = false;
            //            moveDirection = Vector3.forward;

            //        }
            //    }

            //    else if (initialDirection == Direction.Up || initialDirection == Direction.Down)
            //    {
            //        if (Mathf.Abs(transform.position.z - initialposition.z) < 0.05f)
            //        {
            //            StopMoving();
            //            returnBack = false;
            //            moveDirection = Vector3.forward;

            //        }
            //    }
            //}
        }

       
    }

    private void StartMoving()
    {
        LevelManager.Instance().Move();
        
        b_move = true;
    }
    void StopMoving()
    {
        LevelManager.Instance().CheckMove();
        b_move = false;
    }

    private void OnMouseDown()
    {
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
                    
                    switch(ownDirection)
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
            checkSquare = true;
            squarePosition = other.transform.position;

        }
        if (other.transform.tag == "FinishLine")
        {
            LevelManager.Instance().CheckSpaceShipCount();
            LevelManager.Instance().ScoreCount();
            Destroy(gameObject);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (b_move&& collision.gameObject.tag == "MovingObject")
        {
            moveDirection = Vector3.back;
            returnBack = true;
        }
    }

}


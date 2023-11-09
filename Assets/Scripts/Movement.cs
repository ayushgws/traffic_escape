using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public enum ObjectDirection
{
    Straight,
    Left,
    Right,
    LeftUTurn,
    RightUTurn,
}

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody _rigidbody;

    
    [SerializeField] private float speed = 1f;
    [SerializeField] private ObjectDirection direction;

    private Vector3 moveDirection = Vector3.forward;

    private bool b_move;
    private bool returnBack = false;
    private Vector3 initialposition;
    

    void Start()
    {
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
            if (returnBack && Vector3.Distance(transform.position, initialposition) < 0.1f)
            {
                StopMoving();
                returnBack = false;
                moveDirection = Vector3.forward;
            }
        }

       
    }

    private void StartMoving()
    {
        b_move = true;
    }
    void StopMoving()
    {
        b_move = false;
    }

    private void OnMouseDown()
    {
        StartMoving();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Square")
        {
            if (!returnBack)
            {
                switch (direction)
                {
                    case ObjectDirection.Straight:
                        break;
                    case ObjectDirection.Left:
                        transform.Rotate(0, -90, 0);
                        break;
                    case ObjectDirection.Right:
                        transform.Rotate(0, 90, 0);
                        break;
                    case ObjectDirection.LeftUTurn:
                        transform.Rotate(0, -90, 0);
                        break;
                    case ObjectDirection.RightUTurn:
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
                        transform.Rotate(0, 90, 90);
                        break;
                    case ObjectDirection.Right:
                        transform.Rotate(0, -90, 90);
                        break;
                    case ObjectDirection.LeftUTurn:
                        transform.Rotate(0, 90, 90);
                        break;
                    case ObjectDirection.RightUTurn:
                        transform.Rotate(0, -90, 90);
                        break;
                }
            }

        }
        if (other.transform.tag == "FinishLine")
        {
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


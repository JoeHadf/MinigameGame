using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FourDirectionalMovement : MonoBehaviour
{
    [SerializeField] private EntitySpeed speed;
    [SerializeField] private bool allowHorizontal;
    [SerializeField] private bool allowVertical;

    private MovementDirection horizontalDirection;
    private MovementDirection verticalDirection;

    private bool isActive;

    void Awake()
    {
        horizontalDirection = MovementDirection.Right;
        verticalDirection = MovementDirection.Up;

        isActive = true;
    }
    void Update()
    {
        if (isActive)
        {
            float horizontalAxis = (allowHorizontal) ? Input.GetAxis("Horizontal") : 0;
            float verticalAxis = (allowVertical) ? Input.GetAxis("Vertical") : 0;

            UpdateMovementDirections(horizontalAxis, verticalAxis);

            float horizontalMovement = speed * horizontalAxis * Time.deltaTime;
            float verticalMovement = speed * verticalAxis * Time.deltaTime;
            
            transform.Translate(horizontalMovement, verticalMovement, 0);

            BoundPosition();
        }
    }

    public void SetActive(bool active)
    {
        this.isActive = active;
    }

    public bool IsMovingLeft()
    {
        return IsMovingInDirection(MovementDirection.Left);
    }
    
    public bool IsMovingRight()
    {
        return IsMovingInDirection(MovementDirection.Right);
    }
    
    public bool IsMovingUp()
    {
        return IsMovingInDirection(MovementDirection.Up);
    }
    
    public bool IsMovingDown()
    {
        return IsMovingInDirection(MovementDirection.Down);
    }
    
    private void UpdateMovementDirections(float horizontalAxis, float verticalAxis)
    {
        if (horizontalAxis < 0 && horizontalDirection == MovementDirection.Right)
        {
            horizontalDirection = MovementDirection.Left;
        }
        else if (horizontalAxis > 0 && horizontalDirection == MovementDirection.Left)
        {
            horizontalDirection = MovementDirection.Right;
        }
        
        if (verticalAxis < 0 && verticalDirection == MovementDirection.Up)
        {
            verticalDirection = MovementDirection.Down;
        }
        else if (verticalAxis > 0 && verticalDirection == MovementDirection.Down)
        {
            verticalDirection = MovementDirection.Up;
        }
    }
    
    private void BoundPosition()
    {
        Vector3 currentPosition = transform.position;

        if (currentPosition.x < ScreenSpaceCalculator.minX)
        {
            currentPosition.x = ScreenSpaceCalculator.minX;
        }
        if (currentPosition.x > ScreenSpaceCalculator.maxX)
        {
            currentPosition.x = ScreenSpaceCalculator.maxX;
        }

        if (currentPosition.y < ScreenSpaceCalculator.minY)
        {
            currentPosition.y = ScreenSpaceCalculator.minY;
        }
        if (currentPosition.y > ScreenSpaceCalculator.maxY)
        {
            currentPosition.y = ScreenSpaceCalculator.maxY;
        }

        transform.position = currentPosition;
    }

    private bool IsMovingInDirection(MovementDirection direction)
    {
        if (direction == MovementDirection.Left || direction == MovementDirection.Right)
        {
            return direction == horizontalDirection;
        }

        return direction == verticalDirection;
    }

    public enum MovementDirection
    {
        Right = 1,
        Left = 2,
        Up = 3,
        Down = 4
    }
}

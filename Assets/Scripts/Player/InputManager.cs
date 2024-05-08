using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private Directions mDirections;
    public Directions MDirections { get => mDirections; set => mDirections = value; }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            MDirections = Directions.Up;
        
        }else if (Input.GetKey(KeyCode.S))
        {
            MDirections = Directions.Down;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            MDirections = Directions.Left;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            MDirections = Directions.Right;
        }
        else
        {
            MDirections = Directions.Stay;
        }
    }
}

public enum Directions
{
    Stay,
    Right,
    Left,
    Up,
    Down
}
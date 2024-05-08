using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private Directions mDirections;
    public Directions MDiections => mDirections;

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            mDirections = Directions.Up;
        
        }else if (Input.GetKey(KeyCode.S))
        {
            mDirections = Directions.Down;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            mDirections = Directions.Left;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            mDirections = Directions.Right;
        }
        else
        {
            mDirections = Directions.Stay;
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
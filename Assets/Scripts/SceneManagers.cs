using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManagers : MonoBehaviour
{
    public static directions DestinationDirection { get; private set; }
    public enum directions
    {
        LEFT,
        RIGHT, 
        UP,
        DOWN
    }
    public static void SetDestinaionDirection(directions direction)
    {
        DestinationDirection = direction;
    }
}

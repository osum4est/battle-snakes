using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prefabs : MonoBehaviour
{
    private static Prefabs i;
    [SerializeField]
    private GameObject snakePartHead;
    [SerializeField]
    private GameObject snakePartBody;

    public static GameObject SnakePartHead { get { return i.snakePartHead; } }
    public static GameObject SnakePartBody { get { return i.snakePartBody; } }

    void Start()
    {
        i = this;
    }
}

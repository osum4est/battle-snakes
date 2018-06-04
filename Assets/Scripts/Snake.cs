using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Rewired;
using UnityEngine;

public class Snake : MonoBehaviour {

    [SerializeField]
    private int startLength = 5;
    [SerializeField]
    private int moveSpeed = 100;

    private SnakePart head;
    private List<SnakePart> body;

    private Stopwatch moveWatch;
    private Direction direction;
    private Queue<Direction> movementQueue;

    private int playerId = 0;
    private Player player;

    void Start() {
        moveWatch = new Stopwatch();
        moveWatch.Start();
        direction = Direction.Left;
        movementQueue = new Queue<Direction>();

        player = ReInput.players.GetPlayer(playerId);

        GameObject headGameObject = Instantiate(Prefabs.SnakePartHead, transform);
        head = headGameObject.GetComponent<SnakePart>();

        body = new List<SnakePart>();
        for (int i = 0; i < startLength; i++) {
            GameObject bodyGameObject = Instantiate(Prefabs.SnakePartBody, new Vector3(-Constants.GridSize * (i + 1), 0, 0), Quaternion.identity, transform);
            body.Add(bodyGameObject.GetComponent<SnakePart>());
        }
    }
    
    void Update() {
        if (moveWatch.ElapsedMilliseconds > moveSpeed) {
            Move();
            moveWatch.Restart();
        }

        Direction lastDirection = Direction.None;
        if (movementQueue.Count > 0)
            lastDirection = movementQueue.Peek();

        if (player.GetButtonDown(RewiredConsts.Action.Move_Up) && lastDirection != Direction.Up)
            movementQueue.Enqueue(Direction.Up);
        else if (player.GetButtonDown(RewiredConsts.Action.Move_Down) && lastDirection != Direction.Down)
            movementQueue.Enqueue(Direction.Down);
        else if (player.GetButtonDown(RewiredConsts.Action.Move_Left) && lastDirection != Direction.Left)
            movementQueue.Enqueue(Direction.Left);
        else if (player.GetButtonDown(RewiredConsts.Action.Move_Right) && lastDirection != Direction.Right)
            movementQueue.Enqueue(Direction.Right);
    }

    private void Move() {
        if (movementQueue.Count > 0)
            direction = movementQueue.Dequeue();

        for (int i = body.Count - 1; i > 0; i--)
            body[i].transform.SetPositionAndRotation(body[i - 1].transform.position, body[i - 1].transform.rotation);
        body[0].transform.SetPositionAndRotation(head.transform.position, head.transform.rotation);
        head.transform.Translate(Constants.GridSize * direction.GetVector().x, Constants.GridSize * direction.GetVector().y, 0);
    }
}

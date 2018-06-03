using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Snake : MonoBehaviour {

    [SerializeField]
    private int startLength = 5;
    [SerializeField]
    private int moveSpeed = 100;
    [SerializeField]
    private float size = .25f;

    private SnakePart head;
    private List<SnakePart> body;

    private Stopwatch moveWatch;

    private Direction direction;

    void Start() {
        moveWatch = new Stopwatch();
        moveWatch.Start();

        direction = Direction.Left;

        GameObject headGameObject = Instantiate(Prefabs.SnakePartHead, transform);
        head = headGameObject.GetComponent<SnakePart>();

        body = new List<SnakePart>();
        for (int i = 0; i < startLength; i++) {
            GameObject bodyGameObject = Instantiate(Prefabs.SnakePartBody, new Vector3(-size * (i + 1), 0, 0), Quaternion.identity, transform);
            body.Add(bodyGameObject.GetComponent<SnakePart>());
        }
    }
    
    void Update() {
        if (moveWatch.ElapsedMilliseconds > moveSpeed) {
            Move();
            moveWatch.Restart();
        }
    }

    private void Move() {
        for (int i = body.Count - 1; i > 0; i--)
            body[i].transform.SetPositionAndRotation(body[i - 1].transform.position, body[i - 1].transform.rotation);
        body[0].transform.SetPositionAndRotation(head.transform.position, head.transform.rotation);
        head.transform.Translate(size * direction.GetVector().x, size * direction.GetVector().y, 0);
    }
}

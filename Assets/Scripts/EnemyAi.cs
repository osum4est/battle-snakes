using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{

    [SerializeField]
    private int moveSpeed;
    [SerializeField]
    private float chanceToMove;
    [SerializeField]
    private float chanceToMoveTowards;

    private GameObject target;
    private Stopwatch moveWatch;

    void Start()
    {
        target = BattleSnakes.i.GetPlayerManager().GetPlayer(0).gameObject;
        moveWatch = new Stopwatch();
        moveWatch.Start();
    }

    void Update()
    {
        if (moveWatch.ElapsedMilliseconds > moveSpeed)
        {
            Move();
            moveWatch.Restart();
        }
    }

    void Move()
    {
        if (Random.Range(0f, 1f) >= chanceToMove)
            return;

        if (Random.Range(0f, 1f) >= chanceToMoveTowards)
        {
            Direction direction = DirectionExtensions.GetRandomDirection();
            transform.Translate(Constants.GridSize * direction.GetVector().x, Constants.GridSize * direction.GetVector().y, 0);
        }
    }
}

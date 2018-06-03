using UnityEngine;

public enum Direction
{
    Up,
    Down,
    Left,
    Right
}

public static class DirectionExtensions
{
    private static Vector2 up = new Vector2(0, 1);
    private static Vector2 down = new Vector2(0, -1);
    private static Vector2 left = new Vector2(-1, 0);
    private static Vector2 right = new Vector2(1, 0);

    public static Vector2 GetVector(this Direction direction)
    {
        switch (direction)
        {
            case Direction.Up:
                return up;
            case Direction.Down:
                return down;
            case Direction.Left:
                return left;
            case Direction.Right:
                return right;
        }
        return Vector2.zero;
    }
}
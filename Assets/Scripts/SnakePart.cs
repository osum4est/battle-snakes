using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakePart : MonoBehaviour {
    public void SetSprite(Sprite sprite) {
        GetComponent<SpriteRenderer>().sprite = sprite;
    }
}

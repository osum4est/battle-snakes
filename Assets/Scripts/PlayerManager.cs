using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    private List<Snake> players;

    void Start() {
        players = new List<Snake>();

        GameObject snakeGameObject = Instantiate(Prefabs.Snake);
        players.Add(snakeGameObject.GetComponent<Snake>());
    }

    public Snake GetPlayer(int playerId) {
        return players[playerId];
    }
}

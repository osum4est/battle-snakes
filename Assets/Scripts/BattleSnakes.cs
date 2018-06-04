using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSnakes : MonoBehaviour
{
    public static BattleSnakes i { get; private set; }

    private PlayerManager playerManager;

    void Start()
    {
        i = this;
        playerManager = GetComponent<PlayerManager>();
    }

    public PlayerManager GetPlayerManager() {
        return playerManager;
    }
}

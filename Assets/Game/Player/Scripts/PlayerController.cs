using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BaseComponentController {

    public Action onKillEnemy = delegate { };
    // Use this for initialization
    void Start()
    {
        GameController.Instance.players.Add(this);
        onDead += OnDead;
        onKillEnemy += OnKillEnemy;
        GameController.Instance.onStartGame += OnStartGame;
    }
    void OnDead()
    {
        GameController.Instance.players.Remove(this);
        GameController.Instance.Loose();
    }
    void OnKillEnemy()
    {
        GameController.Instance.killedEnemyCount++;
    }
    void OnDisable()
    {        
        GameController.Instance.onStartGame -= OnStartGame;
    }
    void OnStartGame()
    {
        GameController.Instance.players.Remove(this);
        Destroy(this.gameObject);
    }

}

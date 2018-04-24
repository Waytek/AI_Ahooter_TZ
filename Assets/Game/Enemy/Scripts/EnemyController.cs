using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : BaseComponentController {
    PlayerController _target;
    List<PlayerController> players = new List<PlayerController>();
    public PlayerController target
    {
        get
        {
            if (!GameController.Instance.players.Contains(_target))
            {
                //players.Clear();
                if (GameController.Instance.players.Count > 1)
                {
                    players = GameController.Instance.players;
                    players.Sort((p1, p2) => Vector3.Distance(transform.position, p1.transform.position).CompareTo(Vector3.Distance(transform.position, p2.transform.position)));
                    return _target = players[0];
                }
                else
                {
                    if (GameController.Instance.players.Count > 0)
                        return _target = GameController.Instance.players[0];
                    else
                        return null;
                }
            }
            else
            {
                return _target;
            }
        }
    }
    void Start()
    {
        onDead += OnDead;
        GameController.Instance.onStartGame += OnStartGame;
    }
    void OnDisable()
    {
        onDead -= OnDead;
        GameController.Instance.onStartGame -= OnStartGame;
    }
    void OnDead()
    {
        Destroy(this.gameObject, 3);
    }
    void OnStartGame()
    {
        Destroy(this.gameObject);
    }

}

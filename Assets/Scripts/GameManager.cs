using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public BallBase ball;
    public static GameManager Instance;
    public float timeToSetBallFree = 1;
    public StateMachine stateMachine;

    public Player[] players;

    [Header("Menus")]
    public GameObject uiMainMenu;

    private void Awake()
    {
        Instance = this;
        players = FindObjectsOfType<Player>();//nao aconselhavel a usar pq nao é otimizado, recomendavel a referenciar na mao...
    }

    public void ResetBall()
    {
        ball.CanMove(false);
        ball.resetBall();
        Invoke(nameof(SetBallFree), timeToSetBallFree);
    }

    public void ResetPlayers()
    {
        foreach (var player in players)
        {
            player.ResetPlayer();
        }
    }

    private void SetBallFree()
    {
        ball.CanMove(true);
    }

    public void startGame()
    {
        ball.CanMove(true);
    }

    public void endGame()
    {
        stateMachine.SwitchState(StateMachine.States.END_GAME);
        
    }

    public void ShowMenu()
    {
        uiMainMenu.SetActive(true);
        ball.CanMove(false);
    }

}

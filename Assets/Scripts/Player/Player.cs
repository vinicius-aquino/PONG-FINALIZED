using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    public int maxPoints = 2;
    public float speed = 10;
    public Image uiPlayer;
    public string playerName;

    [Header("key setup")]
    public KeyCode keyCodeMoveUp = KeyCode.UpArrow;
    public KeyCode keyCodeMoveDown = KeyCode.DownArrow;

    public Rigidbody2D Myrigidbody2D;

    [Header("Points")]
    public int currentPoints;
    public TextMeshProUGUI uiTextPoints;

    

    private void Awake()
    {
        
        ResetPlayer();

    }

    public void SetName(string s)
    {
        playerName = s;
    }

    public void ResetPlayer()
    {
        currentPoints = 0;
        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(keyCodeMoveUp))
           Myrigidbody2D.MovePosition(transform.position + transform.up * speed);
           //transform.Translate(transform.up * speed);
        else if (Input.GetKey(keyCodeMoveDown))
           Myrigidbody2D.MovePosition(transform.position + transform.up * -speed);
           //transform.Translate(transform.up * speed * -1);       
    }

    public void addPoint()
    {
        currentPoints++;
        UpdateUI();
        CheckMaxPoints();

    }

    public void ChangeColor(Color c)
    {
        uiPlayer.color = c;
    }

    private void UpdateUI()
    {
        uiTextPoints.text = currentPoints.ToString();
    }


    private void CheckMaxPoints()
    {
        if(currentPoints == maxPoints)
        {
            GameManager.Instance.endGame();
            HighscoreManager.Instance.SavePlayerWin(this);
        }
    }
}

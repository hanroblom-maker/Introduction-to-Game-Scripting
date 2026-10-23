using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    public int score = 0;
    public int health = 3;
    public TMP_Text scoreText;
    public TMP_Text healthText;
    private void Start()
    {
        UpdateUI();
    }

    public GameObject WinConditionText;
    public GameObject LoseConditionText;
    public void AddScore()
    {
        score++;

        UpdateUI();

        Debug.Log("Score: " + score);

        CheckWinCondition();

    }
    public void RemoveHealth()
    {
        health--;

        UpdateUI();

        Debug.Log("Health: " + health);

        CheckLoseCondition();
    }
    private void CheckWinCondition()
    {
        if (score >= 5)
        {
            Debug.Log("Win condition reached");

            WinConditionText.SetActive(true);

            FindObjectOfType<PlayerController>().StopMovement();
        }
    }

    private void CheckLoseCondition()
    {
        if (health <= 0)
        {
            Debug.Log("Game Over");

            LoseConditionText.SetActive(true);

            FindObjectOfType<PlayerController>().StopMovement();
        }
    }

    private void UpdateUI()
    {
        scoreText.text = "Score: " + score;
        healthText.text = "Health: " + health;
    }

}

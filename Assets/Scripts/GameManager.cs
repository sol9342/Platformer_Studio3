using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private int score = 0;
    public TextMeshProUGUI scoreText;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }else{
            Destroy(gameObject);
        }
    }
    void Start()
    {
        UpdateScoreUI();   
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        if(scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }
}

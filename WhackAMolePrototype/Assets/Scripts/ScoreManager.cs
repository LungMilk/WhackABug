using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }
    public float totalScore;
    public float currentMultiplier;
    public TextMeshProUGUI totalScoreText;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    private void Start()
    {
        ////    GlobalTurnManager.Instance.RegisterListener(this);
        UpdateText();
    }
    public void Update()
    {
        UpdateText();
    }
    public void UpdateText()
    {
        totalScoreText.text = $"Score: {totalScore.ToString()} ";
    }
    public void IncreaseTotalScore(float Increase)
    {
        totalScore += Increase * currentMultiplier;
        totalScoreText.text = "Score: " + totalScore.ToString();
    }
}

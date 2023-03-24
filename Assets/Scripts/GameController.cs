using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }

    [SerializeField] public int initialBudget = 0;

    private float startTime;
    private float endTime;
    private int budgetUsed;
    public int survivorsRemaining;
    private bool gameEnded;

    private void Awake()
    {
        Instance = this;
        startTime = Time.time;
        budgetUsed = 0;
        gameEnded = false;
    }

    //private void Update()
    //{
    //    CheckGameOver();
    //}

    public void UpdateSurvivorsRemaining(int change)
    {
        Debug.Log("Check survivors!");
        survivorsRemaining += change;
        CheckGameOver();
    }

    public void AddToBudgetUsed(int amount)
    {
        budgetUsed += amount;
    }

    private void CheckGameOver()
    {
        if (survivorsRemaining <= 0)
        {
            endTime = Time.time;
            gameEnded = true;
            ShowResults();
        }
    }
    public GameObject resultsPanel; // 拖动UI面板到该变量上
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI scoreText;
    public Button nextlevelButton;

    public void ShowResults()
    {
        float elapsedTime = endTime - startTime;
        int score = CalculateScore(elapsedTime, budgetUsed);
        // 更新UI中的文本，显示得分、时间等
        resultsPanel.SetActive(true);
        //timeText = GameObject.Find("timetext").GetComponent<TextMeshProUGUI>();
        timeText.text = "Elapsed Time: " + elapsedTime + "s";
        //scoreText = GameObject.Find("scoretext").GetComponent<TextMeshProUGUI>();
        scoreText.text = "Your Score: " + score;
    }

    private int CalculateScore(float time, int budget)
    {
        // 这只是一个示例公式，您可以根据需要修改它
        float timeScore = 1000 / time;
        int budgetScore = initialBudget - budget;
        return Mathf.RoundToInt(timeScore + budgetScore);
    }
}

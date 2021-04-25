using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int scoreTotal;
	public TextMeshProUGUI score;
	public TextMeshProUGUI finalScore;

    // Start is called before the first frame update
    void Start()
    {
        scoreTotal = 0;
    }

    // Update is called once per frame
    public void UpdateScore(int points)
    {
        scoreTotal += points;
		score.text = "Score: " + scoreTotal;
		finalScore.text = "Final Score:\n" + scoreTotal;
    }
}

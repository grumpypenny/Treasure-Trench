using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int scoreTotal;

    // Start is called before the first frame update
    void Start()
    {
        scoreTotal = 0;
    }

    // Update is called once per frame
    public void UpdateScore(int points)
    {
        scoreTotal += points;
    }
}

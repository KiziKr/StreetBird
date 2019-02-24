using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {
    private ScoreBase scoreBest;

    void Start ()
    {
        scoreBest = GetComponent<ScoreBase>();
        scoreBest.DisplayScore(ScoreGame.instance.myScore);
    }
}

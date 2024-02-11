using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static int score;
    public TMP_Text scoreText;

    private void Update()
    {
        print(score);
        scoreText.text = score.ToString();
    }
}

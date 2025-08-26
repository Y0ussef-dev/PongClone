using UnityEngine;
using UnityEngine.UI; // for Text UI
using TMPro;

public class GameManager : MonoBehaviour
{
    public int leftScore = 0;
    public int rightScore = 0;

    public TMP_Text leftScoreText;
    public TMP_Text rightScoreText;

    public Ball Ball; // reference to the ball script

    public void LeftScored()
    {
        leftScore++;
        leftScoreText.text = leftScore.ToString();
        ResetBall();
    }

    public void RightScored()
    {
        rightScore++;
        rightScoreText.text = rightScore.ToString();
        ResetBall();
    }

    private void ResetBall()
    {
        Ball.ResetBall();
    }
}

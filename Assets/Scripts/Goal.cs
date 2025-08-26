using UnityEngine;

public class Goal : MonoBehaviour
{
    public bool isLeftGoal;
    private GameManager gameManager;

    void Start()
    {

        gameManager = Object.FindFirstObjectByType<GameManager>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball"))
        {
            if (isLeftGoal)
                gameManager.RightScored();
            else
                gameManager.LeftScored();
        }
    }
}

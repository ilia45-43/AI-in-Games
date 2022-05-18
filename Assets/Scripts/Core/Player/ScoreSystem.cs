using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    public Text scoreText;

    [SerializeField]
    private int countScoreForAdd;

    private int score = 0;
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void AddScore()
    {
        score += countScoreForAdd;
        scoreText.text = "Score = " + score.ToString();

        if (score % 10 == 0)
        {
            player.GetComponent<AttackSystem>().AddDamage();
        }
    }
}

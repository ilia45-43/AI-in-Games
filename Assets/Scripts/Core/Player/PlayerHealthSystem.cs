using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthSystem : MonoBehaviour
{
    public Text healthText;
    public GameObject canvas;
    public float health = 100;

    [SerializeField]
    private int amoutForRegen;
    private SceneUIScr sceneUI;

    private void Start()
    {
        sceneUI = canvas.GetComponent<SceneUIScr>();
    }

    public void TakeDamage(int amout)
    {
        health -= amout;
        healthText.text = "Helth = " + health.ToString();
        if(health <= 0)
        {
            sceneUI.GameOver();
        }
    }

    public void Regen()
    {
        health += amoutForRegen;
        if (health >= 100)
            health = 100;
        healthText.text = "Helth = " + health.ToString();
    }
}

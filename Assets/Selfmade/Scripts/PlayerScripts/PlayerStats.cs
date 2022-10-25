
using UnityEngine;
using UnityEngine.AI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance;
    public LayerMask whatIsGround, whatIsEnemy;

    public float playerHealth;

    public TextMeshProUGUI healthDisplay;


    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        healthDisplay.SetText(playerHealth + " Health");
    }

    public void IncreaseHealth(float value)
    {
        playerHealth += value;
        healthDisplay.SetText(playerHealth + " Health");
    }

    public void TakeDamage(int damage)
    {

        playerHealth -= damage;
        Debug.Log("PlayerHealth: " + playerHealth);
        if (playerHealth <= 0)
        {
            Invoke(nameof(DestroyPlayer), 0.5f);
        }

        if (healthDisplay != null)
            healthDisplay.SetText(playerHealth + " Health");
    }
    private void DestroyPlayer()
    {
        Destroy(gameObject);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

}

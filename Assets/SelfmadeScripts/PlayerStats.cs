
using UnityEngine;
using UnityEngine.AI;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    /*public Transform Enemyplayer;
    */
    public LayerMask whatIsGround, whatIsEnemy;

    public float playerHealth;

    public TextMeshProUGUI healthDisplay;


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
    }

}

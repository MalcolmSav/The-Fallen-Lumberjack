using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public float enemyHealth;
    public TextMeshProUGUI healthDisplay;
    public void TakeDamage(int damage)
    {
        enemyHealth -= damage;
        Debug.Log("EnemyHealth: " + enemyHealth);
        if (healthDisplay != null)
            healthDisplay.SetText(enemyHealth + " Enemy Health");
    }
}

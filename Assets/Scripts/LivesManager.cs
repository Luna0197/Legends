using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesManager : MonoBehaviour
{
    public int lives = 1;
    private int livesAdd = 1;
    public ScoreManager scoreManager;
    public bool awardedLife = false;
    public bool lostLife = false;
    public Text livesText;
    private HealthManager healthManager;
   

    void Awake()
    {
        scoreManager = GetComponent<ScoreManager>();
        healthManager = FindObjectOfType<HealthManager>(); // Find the HealthManager script in the scene
    }

    void Update()
    {
        LivesToAdd();
        livesText.text = "Lives: " + lives;
        LivesToTake();
    }

    void LivesToAdd()
    {
        int currentScore = ScoreManager.score;

        // Check if the score is a multiple of 100
        if (currentScore % 100 == 0 && currentScore != 0 && !awardedLife)
        {
            lives += livesAdd; // Increment lives when score reaches multiples of 100
            Debug.Log("Extra life awarded! Lives: " + lives);
            awardedLife = true;
        }
        else if (currentScore % 100 != 0)
        {
            awardedLife = false;
        }
    }

    void LivesToTake()
    {
        int currentHealth = healthManager.health;

        if (currentHealth <= 0 && !lostLife) // Check if health is zero or below and a life hasn't been lost yet in this instance
        {
            lives -= livesAdd; // Decrement lives
            lostLife = true; // Mark that a life has been lost in this instance
            healthManager.health = 100;

        }
        else if (currentHealth > 0)
        {
            lostLife = false; // Reset lostLife flag if health is greater than zero
        }
    }
}

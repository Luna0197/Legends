using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthManager : MonoBehaviour
{
    
    public float currentHealth;
    public float maxHealth;

    public int health;
    public GetHit getHitScript;
    private int hurtDamage = 25;
    public bool takenDamage = false;
    public Text healthText;
    // Start is called before the first frame update
    void Start()
    {
        health = 100;

        // Find the GameObject with the GetHit script attached to it
        GameObject getHitGameObject = GameObject.FindWithTag("Player");
        if (getHitGameObject != null)
        {
            getHitScript = getHitGameObject.GetComponent<GetHit>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        Damage();
        healthText.text = "Health:" + health;
    }

    void Damage()
    {
        
        if (getHitScript != null && getHitScript.hurt && !takenDamage)
        {
            health -= hurtDamage;
            takenDamage = true; 
        }
        else if (!getHitScript.hurt)
        {
            takenDamage = false; 
            
        }
    }

}


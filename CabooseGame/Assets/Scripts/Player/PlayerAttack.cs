using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 10;
    public bool playerIsAttacking = false;
    public int swingID;
    public float experience;
    public int level;
    public int kills;
    public int stamina;
    public int staminaPerSwing;
    public Slider experienceSlider;
    public Slider staminaSlider;
    public Text levelDisplay;
    public Text killCount;
    public int staminaRegen;

    Animator anim;
    GameObject enemy;
    HeroHealth playerHealth;
    EnemyHealth enemyHealth;
    bool enemyInRange;
    float timer;
    float experienceThreshold;

    void Awake()
    {
        playerHealth = GetComponent<HeroHealth>();
        anim = GetComponent<Animator>();
        swingID = 0;
        experience = 0f;
        level = 1;
        experienceThreshold = 500f;
        stamina = 100;
        staminaPerSwing = 33;
        staminaRegen = 5;
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == enemy)
        {
            enemyInRange = true;
        }
    }

    public bool GetIsAttacking()
    {
        return playerIsAttacking;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == enemy)
        {
            enemyInRange = false;
        }
    }


    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timeBetweenAttacks && playerHealth.currentHealth > 0 && stamina >= staminaPerSwing)
        {
            if (Input.GetMouseButtonUp(0))
            {
                Attack();
                stamina -= staminaPerSwing;
            }
        }

        if (timer >= 1f && stamina < 100)
        {
            stamina += staminaRegen;
        }
        staminaSlider.value = stamina;

    }


    void Attack()
    {
        timer = 0f;

        if (playerHealth.currentHealth > 0)
        {

            anim.SetTrigger("Attack6Trigger");
            swingID++;
            //enemyHealth.TakeDamage (attackDamage);


        }
    }


    public int GetSwingID()
    {
        Debug.Log("getSwingID was called: " + swingID);
        return swingID;
    }

    public void GainExperience(float xp)
    {
        Debug.Log("GainExperience was called: " + xp);
        kills++;
        killCount.text = "Kills: " + kills;
        experience += xp;

        if (experience >= experienceThreshold)
        {
            experience = experience - experienceThreshold;
            experienceThreshold = experienceThreshold * 1.1f;
            LevelUp();
        }
        experienceSlider.value = (experience / experienceThreshold)*100;
    }
    public void LevelUp()
    {
        level++;
        levelDisplay.text = "Level: " + level;
        attackDamage = (attackDamage)/2 * 3;
        if (staminaPerSwing > 15)
        {
            staminaPerSwing = staminaPerSwing / 4 * 3;
        }
        playerHealth.maxHealth += 25;
        playerHealth.currentHealth += (playerHealth.maxHealth - playerHealth.currentHealth);
    }
}
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 10;
    public bool playerIsAttacking = false;
    public float experience;
    public int level;
    public int kills;
    public float stamina;
    public float staminaPerSwing;
    public Slider experienceSlider;
    public Slider staminaSlider;
    public Text levelDisplay;
    public Text killCount;
    public float staminaRegen;
    public GameObject waveZone;
    public Collider waveCollider;
    public bool weaponActive;
    public float swingDelay;
    public float swingTimer;
    public float swingLength;
    public float regenDelay;
    public Collider weapon;

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
        experience = 0f;
        level = 1;
        experienceThreshold = 500f;
        stamina = 100;
        staminaPerSwing = 33;
        staminaRegen = 5;
        toggleWeaponCollider(false);
        swingTimer = 5f;
        regenDelay = 1.5f;
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
        swingTimer += Time.deltaTime;

        if (timer >= timeBetweenAttacks && playerHealth.currentHealth > 0)
        {
            if (Input.GetMouseButtonUp(0) && stamina >= staminaPerSwing)
            {
                Attack(0);
                swingTimer = 0f;
                timer = 0;
                stamina -= staminaPerSwing;
            }
            else if (Input.GetMouseButtonUp(1) && stamina >= staminaPerSwing)
            {
                Attack(1);
                swingTimer = 0f;
                timer = 0;
                stamina -= staminaPerSwing/3 * 2;
            }
            else if (Input.GetKeyUp("f") && stamina >= 99)
            {
                WaveAttack();
                timer = 0;
                stamina -= 99;
            }
        }
        
        if (swingTimer >= swingDelay && swingTimer <= swingLength)
        {
            if (!weaponActive)
            {
                toggleWeaponCollider(true);
            }
        }
        if (swingTimer >= swingLength)
        {
            if (weaponActive)
            {
                toggleWeaponCollider(false);
            }
        }
        if (timer >= 0.25f)
        {
            EndWaveAttack();
        }

        if (timer >= regenDelay && stamina < 100)
        {
            stamina += staminaRegen*0.1f;
        }
        staminaSlider.value = stamina;

    }


    void Attack(int attackType)
    {
        timer = 0f;

        if (playerHealth.currentHealth > 0)
        {
            if (attackType == 0)
            {
                anim.SetTrigger("Attack6Trigger");
                //enemyHealth.TakeDamage (attackDamage);
            }
            else
            {
                anim.SetTrigger("AttackKick1Trigger");
            }
        }
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
        experienceSlider.value = (experience / experienceThreshold) * 100;
    }
    public void LevelUp()
    {
        level++;
        //levelDisplay.text = "Level: " + level;
        attackDamage = (attackDamage) / 2 * 3;
        if (staminaPerSwing > 15)
        {
            staminaPerSwing = staminaPerSwing / 4 * 3;
        }
        playerHealth.maxHealth += 25;
        playerHealth.currentHealth += (playerHealth.maxHealth - playerHealth.currentHealth);
    }

    public void WaveAttack()
    {
        waveZone.SetActive(true);
    }
    public void EndWaveAttack()
    {
        waveZone.SetActive(false);
    }

    public void toggleWeaponCollider(bool toggle)
    {
        if (toggle)
        {
            weapon.enabled = true;
            weaponActive = true;
            Debug.Log("Player Weapon set active");
        }
        else
        {
            weapon.enabled = false;
            weaponActive = false;
            Debug.Log("PlayerWeapon set inactive");
        }
    }
}
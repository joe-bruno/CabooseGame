using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class EnemyAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 2f;
    public int attackDamage = 10;
    public float attackRange = 2.5f;
    public int swingID;
    public Collider weapon;
    public bool weaponActive;
    public float swingDelay;
    public float swingLength;
    public bool isAttacking;

    Animator anim;
    GameObject player;
    HeroHealth playerHealth;
    EnemyHealth enemyHealth;
    bool playerInRange;
    float timer;
    float swingTimer;


    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<HeroHealth>();
        enemyHealth = GetComponent<EnemyHealth>();
        anim = GetComponent<Animator>();
        toggleWeaponCollider(false);
        isAttacking = false;
    }


    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player Collided With!");
            playerInRange = true;
        }
    }


    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerInRange = false;
        }
    }


    void Update()
    {
        timer += Time.deltaTime;
        swingTimer += Time.deltaTime;
        if ((timer >= timeBetweenAttacks) && playerInRange && (enemyHealth.currentHealth > 0))
        {
            Debug.Log("Enemy Attacking!!");
            Attack();
            timer = 0;
            swingTimer = 0;
            isAttacking = true;
        }

        if (playerHealth.currentHealth <= 0)
        {
            //anim.SetTrigger ("PlayerDead");
        }

        if (swingTimer >= swingDelay && isAttacking)
        {
            if (!weaponActive)
            {
                toggleWeaponCollider(true);
            }
        }
        if (swingTimer > swingLength)
        {
            if (weaponActive)
            {
                toggleWeaponCollider(false);
                isAttacking = false;
            }
        }

    }


    void Attack()
    {
        timer = 0f;

        if (playerHealth.currentHealth > 0)
        {
            //playerHealth.TakeDamage (attackDamage);
            anim.SetTrigger("Attack3Trigger");
            swingID++;
        }
        toggleWeaponCollider(false);
    }

    public int GetSwingID()
    {
        Debug.Log("getSwingID was called: " + swingID);
        return swingID;
    }

    public void toggleWeaponCollider(bool toggle)
    {
        if (toggle)
        {
            weapon.enabled = true;
            weaponActive = true;
            Debug.Log("Enemy Weapon set active");
        }
        else
        {
            weapon.enabled = false;
            weaponActive = false;
            Debug.Log("Enemy Weapon set inactive");
        }
    }
}
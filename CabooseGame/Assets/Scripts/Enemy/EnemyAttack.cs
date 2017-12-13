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

    Animator anim;
    GameObject player;
    HeroHealth playerHealth;
    EnemyHealth enemyHealth;
    bool playerInRange;
    float timer;
    float swingTimer;


    void Awake ()
    {
        player = GameObject.FindGameObjectWithTag ("Player");
        playerHealth = player.GetComponent <HeroHealth> ();
        enemyHealth = GetComponent<EnemyHealth>();
        anim = GetComponent <Animator> ();
    }


    void OnTriggerEnter (Collider other)
    {
        
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Player Collided With!");
            playerInRange = true;
        }
    }


    void OnTriggerExit (Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerInRange = false;
        }
    }


    void Update ()
    {
        timer += Time.deltaTime;
        swingTimer += Time.deltaTime;
        Debug.Log(timer);
        Debug.Log(playerInRange);
        Debug.Log(enemyHealth.currentHealth);
        if ((timer >= timeBetweenAttacks) && playerInRange &&  (enemyHealth.currentHealth > 0))
        {
            Debug.Log("Enemy Attacking!!");
            Attack ();
            swingTimer = 0;
        }

        if(playerHealth.currentHealth <= 0)
        {
            //anim.SetTrigger ("PlayerDead");
        }

        if (swingTimer >= swingDelay)
        {
            if (!weaponActive)
            {
                toggleWeaponCollider(true);
            }
        }

    }


    void Attack ()
    {
        timer = 0f;

        if(playerHealth.currentHealth > 0)
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
        }
        else weapon.enabled = false;
        weaponActive = false;
    }
}

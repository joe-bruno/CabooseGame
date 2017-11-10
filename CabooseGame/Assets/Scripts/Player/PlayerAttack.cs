using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 10;
    public bool playerIsAttacking = false;

    Animator anim;
    GameObject enemy;
    HeroHealth playerHealth;
    EnemyHealth enemyHealth;
    bool enemyInRange;
    float timer;


    void Awake ()
    {
        enemy = GameObject.FindGameObjectWithTag ("Enemy");
        enemyHealth = enemy.GetComponent <EnemyHealth> ();
        playerHealth = GetComponent<HeroHealth>();
        anim = GetComponent <Animator> ();
    }


    void OnTriggerEnter (Collider other)
    {
        if(other.gameObject == enemy)
        {
            enemyInRange = true;
        }
    }

    public bool GetIsAttacking()
    {
        return playerIsAttacking;
    }

    void OnTriggerExit (Collider other)
    {
        if(other.gameObject == enemy)
        {
            enemyInRange = false;
        }
    }


    void Update ()
    {
        timer += Time.deltaTime;

        if(timer >= timeBetweenAttacks &&  playerHealth.currentHealth > 0)
        {
            if (Input.GetMouseButtonUp(0)) {
                Attack();
            }
        }

        if (enemyHealth.currentHealth <= 0)
        {
            //anim.SetTrigger ("PlayerDead");
        }

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("standing_melee_attack_360_low"))
        {
            playerIsAttacking = false;
        }
    }


    void Attack ()
    {
        timer = 0f;

        if(playerHealth.currentHealth > 0)
        {
            playerIsAttacking = true;
            anim.SetTrigger("Attack6Trigger");
            //enemyHealth.TakeDamage (attackDamage);
            
            
        }
    }
}

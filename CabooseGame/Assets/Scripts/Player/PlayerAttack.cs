using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 10;


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

        if(timer >= timeBetweenAttacks && enemyInRange &&  playerHealth.currentHealth > 0)
        {
            Attack ();
        }

        if(enemyHealth.currentHealth <= 0)
        {
            //anim.SetTrigger ("PlayerDead");
        }
    }


    void Attack ()
    {
        timer = 0f;

        if(enemyHealth.currentHealth > 0)
        {
            enemyHealth.TakeDamage (attackDamage);
        }
    }
}

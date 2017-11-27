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


    Animator anim;
    GameObject player;
    HeroHealth playerHealth;
    EnemyHealth enemyHealth;
    bool playerInRange;
    float timer;


    void Awake ()
    {
        player = GameObject.FindGameObjectWithTag ("Player");
        playerHealth = player.GetComponent <HeroHealth> ();
        enemyHealth = GetComponent<EnemyHealth>();
        anim = GetComponent <Animator> ();
    }


    void OnTriggerEnter (Collider other)
    {
        if(other.gameObject == player)
        {
            playerInRange = true;
        }
    }


    void OnTriggerExit (Collider other)
    {
        if(other.gameObject == player)
        {
            playerInRange = false;
        }
    }


    void Update ()
    {
        timer += Time.deltaTime;

        if((timer >= timeBetweenAttacks) && playerInRange &&  (enemyHealth.currentHealth > 0))
        {
            Attack ();
        }

        if(playerHealth.currentHealth <= 0)
        {
            //anim.SetTrigger ("PlayerDead");
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
    }

    public int GetSwingID()
    {
        Debug.Log("getSwingID was called: " + swingID);
        return swingID;
    }
}

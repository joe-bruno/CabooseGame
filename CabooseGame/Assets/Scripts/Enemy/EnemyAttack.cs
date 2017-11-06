using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class EnemyAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 10;


    Animator anim;
    GameObject player;
    HeroHealth playerHealth;
    EnemyHealth enemyHealth;
    bool playerInRange;
    float timer;
    float range=3;
    float distance;



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
        distance = Vector3.Distance(player.transform.position, transform.position);
        Debug.Log("Distance to other: " + distance);
        if (timer >= timeBetweenAttacks && distance<=range  &&  enemyHealth.currentHealth > 0)
        {
            Attack ();
            Debug.Log("Enemy Tried to Attack");
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
            playerHealth.TakeDamage (attackDamage);
            anim.SetTrigger("Attack3Trigger");
        }
    }
}

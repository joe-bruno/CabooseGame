using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class ArcherAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 10;
    public float attackRange = 2.5f;
    public float minRange = 10f;

    Animator anim;
    GameObject player;
    HeroHealth playerHealth;
    EnemyHealth enemyHealth;
    bool playerInRange;
    float timer;
    private Transform target;
    private ArrowHandler arrowHandler;


    void Awake ()
    {
        player = GameObject.FindGameObjectWithTag ("Player");
        playerHealth = player.GetComponent <HeroHealth> ();
        enemyHealth = GetComponent<EnemyHealth>();
        anim = GetComponent <Animator> ();
        target = player.transform;
    }

    public Transform getTarget()
    {
        return target;
    }

    /* void OnTriggerEnter (Collider other)
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
    } */


    void Update ()
    {
        timer += Time.deltaTime;

        float distance = Vector3.Distance(transform.position, target.position);
        bool playerInRange = distance < minRange;

        if(timer >= timeBetweenAttacks && playerInRange &&  enemyHealth.currentHealth > 0)
        {
            transform.LookAt(target);
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
            arrowHandler.LaunchArrow();
        }
    }
    

}

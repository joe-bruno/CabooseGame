using UnityEngine;
using System.Collections;

public class ArcherMovement : MonoBehaviour
{
    Transform player;
    HeroHealth heroHealth;
    EnemyHealth enemyHealth;
    UnityEngine.AI.NavMeshAgent nav;

    void Awake ()
    {
        player = GameObject.FindGameObjectWithTag ("Player").transform;
        heroHealth = player.GetComponent <HeroHealth> ();
        enemyHealth = GetComponent <EnemyHealth> ();
        nav = GetComponent <UnityEngine.AI.NavMeshAgent> ();
    }

    void Update ()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        if (enemyHealth.currentHealth > 0 && heroHealth.currentHealth > 0)
        {
            if (distance > 5f)
            {
                nav.SetDestination(player.position);
            }
            if (distance < 5f)
            {
                nav.SetDestination((transform.position-player.position)*4);
            }
        }
        else
        {
           nav.enabled = false;
        }
    }
}

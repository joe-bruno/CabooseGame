using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class ArcherAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 0.75f;
    public float attackRange = 2.5f;
    public float minRange = 10f;
    public Transform firePoint;
    public GameObject arrow;
    public float thrust = 1000f;

    Animator anim;
    GameObject player;
    public HeroHealth playerHealth;
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
        arrowHandler = GetComponentInParent<ArrowHandler>();
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

        if(timer >= timeBetweenAttacks && playerInRange && enemyHealth.currentHealth > 0)
        {
            transform.LookAt(target);
            if ((playerHealth.currentHealth >= 0)&&(distance>5f))
            {
                Debug.Log("Still attacking");
                Attack();
            }
        }
    }


    void Attack ()
    {
        timer = 0f;

        if(playerHealth.currentHealth > 0)
        {
            //playerHealth.TakeDamage (attackDamage);
            Debug.Log("Inside Attack Definition");
            anim.SetTrigger("Attack3Trigger");
            //arrowHandler.LaunchArrow();
            GameObject arrowInstance = Instantiate(arrow, firePoint.position, firePoint.rotation);
            arrowInstance.transform.LookAt(player.transform);
            
            arrowInstance.GetComponent<Rigidbody>().AddForce(arrowInstance.transform.forward * thrust);
            Debug.Log(firePoint.rotation);
            Destroy(arrowInstance, 3f);
        }
    }
    

}

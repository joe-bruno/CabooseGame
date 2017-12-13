using System.Timers;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    public float sinkSpeed = 2.5f;
    public int scoreValue = 10;
    public AudioClip deathClip;
    public PlayerAttack playerAtt;
    public Rigidbody rb;
    EnemyController enemyController;
    enemyWeapon weapon;

    Animator anim;
    AudioSource enemyAudio;
    ParticleSystem hitParticles;
    CapsuleCollider capsuleCollider;
    
    public bool isDead;
    bool isSinking;
    int swingID;

    private HeroHealth playerHealth;

    void Awake ()
    {
        anim = GetComponent <Animator> ();
        rb = GetComponent<Rigidbody>();
        // enemyAudio = GetComponent <AudioSource> ();
        // hitParticles = GetComponentInChildren <ParticleSystem> ();
        enemyController = GetComponent<EnemyController>();
        capsuleCollider = GetComponent <CapsuleCollider> ();
        weapon = GetComponentInChildren<enemyWeapon>();
        if (playerAtt != null)
        {
            Debug.Log("PlayerAttack sucessfully found");
        }
        swingID = 0;
        currentHealth = startingHealth;
    }


    void Update ()
    {
        GameObject player = GameObject.FindWithTag("Player");
        playerHealth = player.GetComponent<HeroHealth>();

        if (isDead)
        {
            if (isSinking)
            {
                transform.Translate(-Vector3.up * sinkSpeed * Time.deltaTime);
            }
        } else if(isPlayerDead())
        {
            Death();
            Destroy(gameObject, 2f);
        }

    }

    private bool isPlayerDead()
    {
        if (playerHealth.currentHealth <= 0)
            return true;
        else
            return false;
    }

    public int TakeDamage(int amount, int newSwingID)
    {
        if(isDead)
            return 0;

       if (newSwingID!=swingID)
        {
        currentHealth -= amount;
        anim.SetTrigger("GetHit1Trigger");
        swingID = newSwingID;
        }

        if (currentHealth <= 0)
        {
            Death ();
            return 1;

        }
        else
        {
            return 0;
        }
    }

    public int TakeDamage(int amount, float force)
    {
        if (isDead)
        {
            return 0;
        }
        anim.SetTrigger("GetHit1Trigger");
        currentHealth -= amount;
        rb.AddForce(transform.forward * force);

        if (currentHealth <= 0)
        {
            Death();
            return 1;

        }
        else
        {
            return 0;
        }
    }


    void Death ()
    {
        isDead = true;

        capsuleCollider.isTrigger = true;

        enemyController.enemyDeath();
        enemyController.enabled = false;

        weapon.weaponActive = false;
    }


    public void StartSinking ()
    {
        GetComponent <UnityEngine.AI.NavMeshAgent> ().enabled = false;
        GetComponent <Rigidbody> ().isKinematic = true;
        isSinking = true;
        //ScoreManager.score += scoreValue;
        Destroy (gameObject, 2f);
    }
}

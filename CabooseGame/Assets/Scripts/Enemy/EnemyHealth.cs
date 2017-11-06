using System.Timers;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    public float sinkSpeed = 2.5f;
    public int scoreValue = 10;
    public AudioClip deathClip;
    EnemyController enemyController;


    Animator anim;
    AudioSource enemyAudio;
    ParticleSystem hitParticles;
    CapsuleCollider capsuleCollider;
    bool isDead;
    bool isSinking;


    void Awake ()
    {
        anim = GetComponent <Animator> ();
        // enemyAudio = GetComponent <AudioSource> ();
        // hitParticles = GetComponentInChildren <ParticleSystem> ();
        enemyController = GetComponent<EnemyController>();
        capsuleCollider = GetComponent <CapsuleCollider> ();


        currentHealth = startingHealth;
    }


    void Update ()
    {
        if (isDead)
        {
            
            //StartSinking();
            if (isSinking)
            {
                transform.Translate(-Vector3.up * sinkSpeed * Time.deltaTime);
            }
        }
    }


    public void TakeDamage (int amount)
    {
        if(isDead)
            return;

       // enemyAudio.Play ();

        currentHealth -= amount;
            
       // hitParticles.transform.position = hitPoint;
       // hitParticles.Play();

        if(currentHealth <= 0)
        {
            Death ();
        }
    }


    void Death ()
    {
        isDead = true;

        capsuleCollider.isTrigger = true;

        enemyController.enemyDeath();
        enemyController.enabled = false;
        

        /* anim.SetTrigger ("Dead");

        enemyAudio.clip = deathClip;
        enemyAudio.Play (); */


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

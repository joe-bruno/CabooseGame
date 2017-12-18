using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class enemyWeapon : MonoBehaviour {
    public int attackPower;
    public bool weaponActive = true;
    HeroHealth playerHealth;
    GameObject player;
    EnemyAttack enemyAttack;
    

    // Use this for initialization
    void Start ()
    {
        player = GameObject.FindGameObjectWithTag ("Player");
        playerHealth = player.GetComponent<HeroHealth> ();
        enemyAttack = GetComponentInParent<EnemyAttack>();
    }
	
	// Update is called once per frame
	void Update () {
        //playerIsAttacking = player.GetIsAttacking();
    }
    
    void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.tag == "Player")&&(weaponActive))
        {  
            HeroHealth hHealth = other.gameObject.GetComponent<HeroHealth>();
            hHealth.TakeDamage(attackPower);
            enemyAttack.toggleWeaponCollider(false);
            enemyAttack.isAttacking = false;

        }
    }
}

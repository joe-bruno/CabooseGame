using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class enemyWeapon : MonoBehaviour {
    EnemyAttack enemyAttack;
    public int attackPower = 25;
    public bool weaponActive = true;
    HeroHealth playerHealth;
    GameObject player;
    float swingTimer;

    int swingID;
    int newSwingID;

    // Use this for initialization
    void Start () {
        enemyAttack = GetComponentInParent<EnemyAttack>();
        player = GameObject.FindGameObjectWithTag ("Player");
        playerHealth = player.GetComponent<HeroHealth> ();
    }
	
	// Update is called once per frame
	void Update () {
        //playerIsAttacking = player.GetIsAttacking();
        
    }
    
    void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.tag == "Player")&&(weaponActive))
        {
            swingID = enemyAttack.GetSwingID();
            HeroHealth hHealth = other.gameObject.GetComponent<HeroHealth>();
            hHealth.TakeDamage(attackPower,swingID);
        }
    }
}

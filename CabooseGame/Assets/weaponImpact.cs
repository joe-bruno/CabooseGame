using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponImpact : MonoBehaviour {
    PlayerAttack player;
    public int attackPower = 50;
    bool playerIsAttacking;
    
	// Use this for initialization
	void Start () {
       player = GetComponent<PlayerAttack>();
    }
	
	// Update is called once per frame
	void Update () {
        //playerIsAttacking = player.GetIsAttacking();
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            //if (playerIsAttacking) {
                EnemyHealth eHealth = other.gameObject.GetComponent<EnemyHealth>();
                eHealth.TakeDamage(attackPower);
            //}

        }
    }
}

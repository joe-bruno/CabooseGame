using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponImpact : MonoBehaviour {
    PlayerAttack playerAttack;
    public int attackPower = 50;
    bool playerIsAttacking;
    int swingID;
    int newSwingID;
    
    
	// Use this for initialization
	void Start () {
       playerAttack = GetComponentInParent<PlayerAttack>();

       swingID = 0;
    }
	
	// Update is called once per frame
	void Update () {
        //playerIsAttacking = player.GetIsAttacking();
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            swingID = playerAttack.GetSwingID();
            
            EnemyHealth eHealth = other.gameObject.GetComponent<EnemyHealth>();
            eHealth.TakeDamage(attackPower,swingID);
        }
    }
}

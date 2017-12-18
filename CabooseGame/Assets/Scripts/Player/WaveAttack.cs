using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveAttack : MonoBehaviour {
    public PlayerAttack playerAttack;
    public int attackPower = 50;
    bool playerIsAttacking;
    int takeDamageReturn;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            EnemyHealth eHealth = other.gameObject.GetComponent<EnemyHealth>();
            takeDamageReturn = eHealth.TakeDamage(attackPower);
            if (takeDamageReturn == 1)
            {
                playerAttack.GainExperience(100f);
            }
        }
    }
}

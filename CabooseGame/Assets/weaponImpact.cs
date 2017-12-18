using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponImpact : MonoBehaviour
{
    PlayerAttack playerAttack;
    public int attackPower = 50;
    bool playerIsAttacking;
    int takeDamageReturn;


    // Use this for initialization
    void Start()
    {
        playerAttack = GetComponentInParent<PlayerAttack>();

    }

    // Update is called once per frame
    void Update()
    {
        //playerIsAttacking = player.GetIsAttacking();
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

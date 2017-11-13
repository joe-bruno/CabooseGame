using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class enemyWeapon : MonoBehaviour {
    public int attackPower = 25;
    public bool weaponActive = true;
    HeroHealth playerHealth;
    GameObject player;
    

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag ("Player");
    playerHealth = player.GetComponent<HeroHealth> ();
    }
	
	// Update is called once per frame
	void Update () {
        //playerIsAttacking = player.GetIsAttacking();
    }
    
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collider Detected");
        if ((other.gameObject.tag == "Player")&&(weaponActive))
        {
            Debug.Log("Collider is Player");
            HeroHealth hHealth = other.gameObject.GetComponent<HeroHealth>();
            hHealth.TakeDamage(attackPower);
        }
    }
}

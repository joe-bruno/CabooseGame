using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shieldScript : MonoBehaviour {
    public PlayerAttack playerAttack;
    public int attackPower = 50;
    bool playerIsAttacking;
    int swingID;
    int newSwingID;
    
    
	// Use this for initialization
	void Start () {


    }
	
	// Update is called once per frame
	void Update () {

    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Arrow")
        {
            Destroy(other.gameObject,0f);
        }
    }
}

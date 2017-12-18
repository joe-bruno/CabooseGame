using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour {

    public AudioSource audioSource;
    
	// Use this for initialization
	void Start () {
        audioSource.loop = true;
        audioSource.Play();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

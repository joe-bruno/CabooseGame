using UnityEngine;

public class EnemyManager : MonoBehaviour
{
	private GameObject playerObj;
    public HeroHealth playerHealth;
    public GameObject enemy;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;
    public PlayerAttack playerAtt;


    void Start ()
    {
		// Get the player and pull its herohealth instance
		playerObj = GameObject.Find("The Hero");
		playerHealth = playerObj.GetComponent<HeroHealth> ();

        InvokeRepeating ("Spawn", spawnTime, spawnTime);
    }


    void Spawn ()
    {
        if(playerHealth.isDead)
        {
            return;
        }

        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        Instantiate (enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }
}

using UnityEngine;

public class EnemyManager : MonoBehaviour
{
	public GameObject playerObj;
    public HeroHealth playerHealth;
    public GameObject enemy;
    public GameObject enemy2;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;
    public PlayerAttack playerAtt;
    public Transform[] spawnPoints2;

    void Start ()
    {
		// Get the player and pull its herohealth instance
		playerObj = GameObject.FindGameObjectWithTag("Player");
		//playerHealth = playerObj.GetComponent<HeroHealth> ();

        InvokeRepeating ("Spawn", spawnTime, spawnTime);
    }


    void Spawn ()
    {
        if(playerHealth.isDead)
        {
            return;
        }

        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        Instantiate(enemy2, spawnPoints2[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        Instantiate (enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }
}

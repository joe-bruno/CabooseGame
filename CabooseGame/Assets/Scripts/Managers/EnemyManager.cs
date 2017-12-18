using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    // Controls the # of enemies spawned each time
    private static int[] roundConfiguration = { 3, 5, 10, 15, 25, 45, 75, 125, 250, 275, 350 };
    private int currentRound;
    private int enemiesRemaining;

    // Configurable
    public HeroHealth playerHealth;
    public GameObject[] enemy;
    private float spawnTime = 3f;
    public Transform[] spawnPoints;
    public Text roundLabel;

    void Start ()
    {
        currentRound = 0;
        enemiesRemaining = roundConfiguration[currentRound];

        InvokeRepeating ("Spawn", spawnTime, spawnTime);
    }

    private void Update()
    {
        if(enemiesRemaining == 0)
        {
            spawnTime = currentRound + 1;
            currentRound++;
            enemiesRemaining = roundConfiguration[currentRound];
            roundLabel.text = "Round " + currentRound;
            InvokeRepeating("Spawn", spawnTime, spawnTime);
        }
    }

    public void enemyDestroyed()
    {
        if (enemiesRemaining > 0)
            enemiesRemaining--;
    }


    void Spawn ()
    {
        if (playerHealth.currentHealth > 0f && enemiesRemaining > 0)
        {
            int enemyType = Random.Range(0, enemy.Length);
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);

            Instantiate(enemy[enemyType], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        }
    }
}

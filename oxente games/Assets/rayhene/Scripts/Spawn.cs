using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject boss;
    public float timer;
    public float timeToSpawn;
    public Transform spawnPoint;

    public bool stopTimer = false;

    void Update()
    {
        if (!stopTimer)
        {
            timer += Time.deltaTime;
        }
        
        if (timer >= timeToSpawn && stopTimer == false)
        {
            stopTimer = true;
            SpawnBoss();
            
        }
    }
    private void SpawnBoss()
    {
        Instantiate(boss, spawnPoint.position, spawnPoint.rotation);
    }
}

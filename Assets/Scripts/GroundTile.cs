using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;
public class GroundTile : MonoBehaviour
{
    public GameObject coin;
    private GroundSpawner groundSpawner;

    public GameObject[] ObstaclePrefabs;
    public Transform[] spawnPoints;
    

    private void Awake()
    {
        groundSpawner = GameObject.FindAnyObjectByType<GroundSpawner>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Spawnobs();
        SpawnCoin();
    }
    private void OnTriggerExit(Collider other)
    {
     groundSpawner.spawnTile();   
     Destroy(gameObject,5f);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawnobs()
    {
        int chooseSpawnPoint = Random.Range(0, spawnPoints.Length);
        int SpawnPrefab = Random.Range(0, ObstaclePrefabs.Length);

        Instantiate(ObstaclePrefabs[SpawnPrefab], spawnPoints[chooseSpawnPoint].transform.position, Quaternion.identity, transform);
;    }

public void SpawnCoin ()
{
    int spawnAmount = 1;
    for(int i = 0; i< spawnAmount; i++)
    {
        GameObject tempCoin = Instantiate(coin);
        tempCoin.transform.position = SpawnRandomPoint(GetComponent<Collider>());
    }
}
Vector3 SpawnRandomPoint(Collider col)
 {
//     Vector3 point = new Vector3(Random.Range(col.bounds.min.x,col.bounds.max.x),Random.Range(col.bounds.min.y,col.bounds.max.y),Random.Range(col.bounds.min.z,col.bounds.max.z));
//     point.y = 1;
//     return point;
 float x = Random.Range(-4f, 4f); // Adjust width
    float z = Random.Range(2f, 8f);  // Adjust depth
    return transform.position + new Vector3(x, 1f, z); // 1f above ground
}
}

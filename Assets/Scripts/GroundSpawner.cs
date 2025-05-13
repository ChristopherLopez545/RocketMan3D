using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject groundTilePre;
    Vector3 nextSpawnPoint;


    public void spawnTile(){
        GameObject tempGround = Instantiate(groundTilePre,nextSpawnPoint,Quaternion.identity);
        nextSpawnPoint = tempGround.transform.GetChild(1).transform.position;
    }   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    { 
        for(int i = 0;i < 10; i++){
            spawnTile();
        }
    }


}

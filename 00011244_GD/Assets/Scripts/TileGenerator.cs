using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGenerator : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    private float spawnPos = 0;
    private float tileLength = 100;

    [SerializeField] private Transform player;
    private int startTiles = 6;

    private List<GameObject> actieTiles = new List<GameObject>();

    private void DeleteTile(){
        Destroy(actieTiles[0]);
        actieTiles.RemoveAt(0);
    }

    // Start is called before the first frame update
    void Start()
    {
      for(int i=0; i < startTiles; i++){
        SpawnTile(Random.Range(0, tilePrefabs.Length));
      } 
    }

    // Update is called once per frame
    void Update()
    {
         if(player.position.z - 60 > spawnPos - (startTiles * tileLength))
         {
            SpawnTile(Random.Range(0, tilePrefabs.Length));
            DeleteTile();
         }
    }

    private void SpawnTile(int tileIndex)
    {
        GameObject nextTile = Instantiate(tilePrefabs[tileIndex], transform.forward * spawnPos, transform.rotation);
        actieTiles.Add(nextTile);
        spawnPos += tileLength;
    }
}

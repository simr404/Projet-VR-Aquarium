using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishGenerator : MonoBehaviour
{
    public int nbMaxOfFishes, spawnRadius, minimumSpawnHeight = 8, distanceThreshold;
    public GameObject[] fishesPrefabs;
    
    Vector3[] spawnSphereMeshVertices;

    public static List<GameObject> fishesList = new List<GameObject>();

    void Awake()
    {
        GameObject spawnSphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        spawnSphere.transform.parent = transform;
        spawnSphere.transform.localScale = new Vector3(spawnRadius, spawnRadius, spawnRadius);
        spawnSphereMeshVertices = spawnSphere.GetComponent<MeshFilter>().sharedMesh.vertices;
        Destroy(spawnSphere);
    }

    void Start()
    {
        SpawnStartFishes(nbMaxOfFishes);
        InvokeRepeating("CheckFishesDistance", 2f, 2f);
    }

    void CheckFishesDistance()
    {
        foreach (GameObject fish in GameObject.FindGameObjectsWithTag("Fish"))
        {
            if (Vector3.Distance(fish.transform.position, transform.position) > distanceThreshold)
            {
                Destroy(fish);
                if (GameObject.FindGameObjectsWithTag("Fish").Length < nbMaxOfFishes) SpawnRandomFish();
            }
        }
    }

    void SpawnRandomFish()
    {
        int nbOfFishesPrefabs = fishesPrefabs.Length;
        GameObject fish = fishesPrefabs[Random.Range(0, nbOfFishesPrefabs)];

        Vector3 randPos = (spawnSphereMeshVertices[Random.Range(0, spawnSphereMeshVertices.Length - 1)] + Vector3.one) * spawnRadius;
        if (randPos.y < minimumSpawnHeight) randPos.y = Random.Range(minimumSpawnHeight, transform.position.y + spawnRadius);

        fishesList.Add(Instantiate(fish, transform.position + randPos - Vector3.one * spawnRadius, Quaternion.identity));
    }

    void SpawnStartFishes(int nbMaxOfFishes)
    {
        for (int i = 0; i < nbMaxOfFishes; i++)
        {
            int nbOfFishesPrefabs = fishesPrefabs.Length;
            GameObject fish = fishesPrefabs[Random.Range(0, nbOfFishesPrefabs)];

            float randSize = Random.Range(0.01f, 0.025f);
            fish.transform.localScale = Vector3.one * randSize;

            Vector3 randPos = transform.position + Random.insideUnitSphere * spawnRadius;
            if (randPos.y < minimumSpawnHeight) randPos.y = Random.Range(minimumSpawnHeight, transform.position.y + spawnRadius);

            fishesList.Add(Instantiate(fish, randPos, Quaternion.identity));
        }
    }
}

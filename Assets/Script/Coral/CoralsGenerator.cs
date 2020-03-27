using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoralsGenerator : MonoBehaviour
{
    public int m_nbMaxOfCoral, m_distanceThreshold, m_maxSpawnHeight = 9;
    public GameObject[] coralPrefabs;

    public static List<GameObject> coralList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {

        SpawnStartCoral(m_nbMaxOfCoral);

        InvokeRepeating("CheckCoralDistance", 2f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnStartCoral(int nbMaxOfCoral)
    {
        for (int i = 0; i < nbMaxOfCoral; i++)
        {
            int nbOfCoralPrefabs = coralPrefabs.Length;
            GameObject coral = coralPrefabs[Random.Range(0, nbOfCoralPrefabs)];

            Vector3 randPos = new Vector3(Random.Range(transform.position.x - m_distanceThreshold, transform.position.x + m_distanceThreshold), Random.Range(0, m_maxSpawnHeight), Random.Range(transform.position.z - m_distanceThreshold, transform.position.z + m_distanceThreshold));

            coralList.Add(Instantiate(coral, randPos, Quaternion.identity));
        }
    }

    void CheckCoralDistance()
    {
        foreach (GameObject coral in GameObject.FindGameObjectsWithTag("Coral"))
        {
            if (Mathf.Abs(coral.transform.position.x - transform.position.x) >= m_distanceThreshold && Mathf.Abs(coral.transform.position.z - transform.position.z) >= m_distanceThreshold)
            {
                Destroy(coral);
                if (GameObject.FindGameObjectsWithTag("Coral").Length < m_nbMaxOfCoral) SpawnRandomCoral();
            }
        }
    }

    void SpawnRandomCoral()
    {
        int nbOfCoralPrefabs = coralPrefabs.Length;
        GameObject coral = coralPrefabs[Random.Range(0, nbOfCoralPrefabs)];

        Vector3 randPos = new Vector3(Random.Range(transform.position.x - m_distanceThreshold, transform.position.x + m_distanceThreshold), Random.Range(0, m_maxSpawnHeight), Random.Range(transform.position.z - m_distanceThreshold, transform.position.z + m_distanceThreshold));

        coralList.Add(Instantiate(coral, randPos, Quaternion.identity));
    }
}

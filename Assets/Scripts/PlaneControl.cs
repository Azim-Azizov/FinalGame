using UnityEngine;

public class PlaneControl : MonoBehaviour
{
    [SerializeField]
    GameObject obstaclePrefab;

    // Start is called before the first frame update
    void Start()
    {
        SpawnObstacles();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnObstacles()
    {
        float z = transform.position.z - 90f;
        while (z <= transform.position.z + 90f)
        {
            int spawned = 0;
            for (int x = -2; x <= 2; x += 2)
            {
                if (spawned == 2) { break; }
                if (Random.value > 0.5f)
                {
                    spawned++;
                    Vector3 pos = new Vector3(x, 1, z);
                    Instantiate(obstaclePrefab, pos, Quaternion.identity, gameObject.transform);
                }
            }
            z += 10f;
        }
    }
}

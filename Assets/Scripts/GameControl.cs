using UnityEngine;

public class GameControl : MonoBehaviour
{
    public GameObject chunkPrefab;
    public Transform player;

    [SerializeField]
    private GameObject currentChunk;
    private GameObject nextChunk;

    [SerializeField]
    private float speed = 10f;

    void Start()
    {
        currentChunk = Instantiate(chunkPrefab, new Vector3(0, 0, 95), Quaternion.identity);
        nextChunk = Instantiate(chunkPrefab, new Vector3(0, 0, currentChunk.transform.position.z + 200), Quaternion.identity);
    }

    void Update()
    {
    }

    void FixedUpdate()
    {
        currentChunk.transform.Translate(Vector3.back * speed * Time.fixedDeltaTime);
        nextChunk.transform.Translate(Vector3.back * speed * Time.fixedDeltaTime);

        if (player.position.z > currentChunk.transform.position.z + 110f)
        {
            Destroy(currentChunk);
            currentChunk = nextChunk;

            Vector3 nextChunkPosition = new Vector3(0, 0, currentChunk.transform.position.z + 200);
            nextChunk = Instantiate(chunkPrefab, nextChunkPosition, Quaternion.identity);
        }
    }
}

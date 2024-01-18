using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    Vector3 targetPosition;
    bool isMoving = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (!isMoving)
        {
            float horizontalInput = Input.GetAxisRaw("Horizontal") * 2;
            if (horizontalInput != 0)
            {
                Vector3 cp = transform.position;
                if (horizontalInput != cp.x)
                {
                    cp.x += horizontalInput;
                    targetPosition = cp;
                    isMoving = true;

                }
            }
        }
    }

    void FixedUpdate()
    {
        if (isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, 10f * Time.fixedDeltaTime);

            if (Mathf.Abs(transform.position.x - targetPosition.x) < 0.001f)
            {
                transform.position = new Vector3(targetPosition.x, transform.position.y, transform.position.z);
                isMoving = false;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            GameOver();
        }
    }

    void GameOver()
    {
        Debug.Log("Game over!!!");
        StartCoroutine(RestartScene());
    }

    IEnumerator RestartScene()
    {
        yield return new WaitForSeconds(3);
        // Get the current scene's name
        string currentSceneName = SceneManager.GetActiveScene().name;

        // Load the current scene
        SceneManager.LoadScene(currentSceneName);
    }
}

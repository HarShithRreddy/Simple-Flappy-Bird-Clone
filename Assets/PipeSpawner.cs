using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipe;
    public float spawnRate;
    public float heightOffset;

    private float timer = 0;
    public LogicScript logic;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.Find("LogicManager").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
         if (logic != null && logic.isGameOver) return;

         if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            spawnPipe();
            timer = 0;
        }
    }
    void spawnPipe()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

        float randomY = Random.Range(lowestPoint, highestPoint);
        Instantiate(pipe, new Vector3(transform.position.x, randomY, 0), transform.rotation);
        if (transform.position.x < -25)
        {
            Destroy(gameObject);
        }
    }
}

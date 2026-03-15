using UnityEngine;
public class pipeMoveScript : MonoBehaviour
{
    public float moveSpeed;
    public float deadZone = -45f;
    public LogicScript logic;

    void Start()
    {
        logic = GameObject.Find("LogicManager").GetComponent<LogicScript>();
    }

    void Update()
    {
        if (logic != null && logic.isGameOver) return;

        transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        if (transform.position.x < deadZone)
        {
            Destroy(gameObject);
        }
    }
}
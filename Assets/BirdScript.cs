using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public LogicScript logic;
    public bool birdIsAlive = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.Find("LogicManager").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)==true && birdIsAlive)
        {
            myRigidbody.linearVelocity=  Vector2.up * flapStrength;
        }

        if ((transform.position.y > 17 || transform.position.y < -17) && birdIsAlive) 
        {
            logic.gameOver();
            birdIsAlive = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision detected with: " + collision.gameObject.name);
        if (logic != null)
        {
            logic.gameOver();
        }
        else
        {
            Debug.LogError("Logic object is null! Cannot call gameOver.");
        }
        birdIsAlive = false;
    }
}

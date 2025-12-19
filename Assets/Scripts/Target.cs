using UnityEngine;
using UnityEngine.Rendering;

public class Target : MonoBehaviour
{
    private Rigidbody body;
    public float minInitialInpulse = 12f;
    public float maxInitialInpulse = 16f;
    public float maxInitialTorque = 5f;
    public float initialXRange;
    public float initialY;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        body = GetComponent<Rigidbody>();
        body.AddForce (RandomUpwardForce(), ForceMode.Impulse);
        body.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse); 
        transform.position = new Vector2(RandomInitialX(), initialY);
    }

    Vector2 RandomUpwardForce()
    {
        return Vector2.up * Random.Range (minInitialInpulse, maxInitialInpulse);
    }
    float RandomInitialX()
    {
        return Random.Range(-initialXRange, initialXRange);
    }

    float RandomTorque()
    {
        return Random.Range(-maxInitialTorque, maxInitialTorque);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}

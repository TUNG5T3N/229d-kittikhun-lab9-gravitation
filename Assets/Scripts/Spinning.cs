using UnityEngine;

public class Spinning : MonoBehaviour
{
    [SerializeField] private float tourque = 5;
    Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddTorque(new Vector3(0, -tourque, 0));
    }
}

using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float force = 5;
    Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(new Vector3(0, 0, force));
    }

    private void OnCollisionEnter(Collision other) 
    {
        other.gameObject.GetComponent<Rigidbody>().AddTorque(100,0,0);
    }
}

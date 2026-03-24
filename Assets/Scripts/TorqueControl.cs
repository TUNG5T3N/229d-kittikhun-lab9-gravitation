using UnityEngine;
using UnityEngine.InputSystem;

public class TorqueControl : MonoBehaviour
{
    public float torquePower = 2f;
    private Rigidbody _rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Keyboard.current.dKey.isPressed)
        {
            _rb.AddTorque(0, torquePower, 0);
        }
    }
}

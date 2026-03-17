using UnityEngine;
using UnityEngine.InputSystem;

public class Airplane : MonoBehaviour
{
    [Header("Power")]
    public float enginePower = 20f;
    public float liftBooster = 0.5f;
    public float drag = 0.01f;
    public float angularDrag = 0.01f;

    [Header("Smoothing")]
    public float yawPower = 50f;
    public float pitchPower = 50f;
    public float rollPower = 30f;

    

    private Rigidbody rb;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Thrust
        if (Keyboard.current.spaceKey.isPressed)
        {
            rb.AddForce(transform.forward * enginePower);
        }

        // Lift
        Vector3 lift = Vector3.Project(rb.linearVelocity, transform.forward);
        rb.AddForce(transform.up * lift.magnitude);

        // Drag
        rb.linearDamping = rb.linearVelocity.magnitude * drag;
        rb.angularDamping = rb.angularVelocity.magnitude * angularDrag;

        // Controls
        float yaw = (Keyboard.current.eKey.isPressed ? 1f : 0f) - (Keyboard.current.qKey.isPressed ? 1f : 0f);
        yaw *= yawPower;

        float pitch = (Keyboard.current.wKey.isPressed ? 1f : 0f) - (Keyboard.current.sKey.isPressed ? 1f : 0f);
        pitch *= pitchPower;

        float roll = (Keyboard.current.aKey.isPressed ? 1f : 0f) - (Keyboard.current.dKey.isPressed ? 1f : 0f);
        roll *= rollPower;

        rb.AddTorque(transform.up * yaw);
        rb.AddTorque(transform.right * pitch);
        rb.AddTorque(transform.forward * roll);
    }
}

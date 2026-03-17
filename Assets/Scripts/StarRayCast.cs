using UnityEngine;
using UnityEngine.InputSystem;

public class StarRayCast : MonoBehaviour
{
    [SerializeField] private Transform shootPos;
    [SerializeField] private float rayLength = 5.0f;

    [SerializeField] private GameObject obstacle;


    // Update is called once per frame
    void Update()
    {
        ShootRay();
    }

    void ShootRay()
    {
        // เก็บค่า เมื่อ Ray กระทบวัตถุ
        RaycastHit hit;

        // Ray Visual
        Debug.DrawRay(shootPos.position, transform.forward * rayLength, Color.green);

        // ยิง Ray ล่องหน เพื่อเช็คว่ากระทบวัตถุไหม และ return ข้อมูล hit
        if (Physics.Raycast(shootPos.position, transform.forward, out hit, rayLength))
        {
            // ยิง Ray Visual เป็นสีแดงมีความยาวถึงแค่จุดที่ Ray กระทบวัตถุ
            Debug.DrawRay(shootPos.position, transform.forward * rayLength, Color.red);
            Renderer renderer = hit.collider.GetComponent<Renderer>();
            if (hit.collider.CompareTag("Obstacle"))
                {
                    var obs = hit.collider.GetComponent<Renderer>();
                    if (obs != null)
                    {
                        renderer.material.color = Color.turquoise;
                        GetComponent<Renderer>().material.color = Color.turquoise;
                        Rigidbody rb = hit.collider.GetComponent<Rigidbody>();
                        if(rb != null)
                        {
                            rb.useGravity = true;
                        }
                    }
                }

            // รายงานชื่อของวัตถุที่มี collider เมื่อ Ray ยิงโดน
            Debug.Log($"Ray hits: {hit.collider.name}");

            if (Mouse.current.rightButton.wasPressedThisFrame)
            {
                if (hit.collider.CompareTag("Obstacle"))
                {
                    var rb = hit.collider.GetComponent<Renderer>();
                    if (rb != null)
                    {
                        GetComponent<Renderer>().material.color = Color.turquoise;
                    }
                }

            }
        }
    }
}

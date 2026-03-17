using UnityEngine;
using UnityEngine.InputSystem;

public class RayShooter : MonoBehaviour
{
    [SerializeField] private Transform shootPos;
    [SerializeField] private float rayLength = 5.0f;

    [SerializeField] private GameObject shootVFX;
    [SerializeField] private GameObject hitVFX;
    [SerializeField] private int damage = 25;


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

            // รายงานชื่อของวัตถุที่มี collider เมื่อ Ray ยิงโดน
            Debug.Log($"Ray hits: {hit.collider.name}");

            if(Mouse.current.rightButton.wasPressedThisFrame)
            {
                // เสก VFX
                var shootVFx = Instantiate(shootVFX, shootPos.position, Quaternion.identity);
                // เสก VFX เมื่อโดนวัตถุ
                var hitVFx = Instantiate(hitVFX, hit.point, Quaternion.identity);

                Destroy(shootVFx, 1.0f);
                Destroy(hitVFx, 1.0f);

                if(hit.collider.CompareTag("Enemy"))
                {
                    Enemy enemy = hit.collider.GetComponent<Enemy>();
                    if(enemy != null)
                    {
                        enemy.TakeDamage(damage);
                    }
                }

                if (hit.collider.CompareTag("Obstacle"))
                {
                    var rb = hit.collider.GetComponent<Rigidbody>();
                    if(rb != null)
                    {
                        rb.AddTorque(0,100,0);
                    }
                }

            }
        }
    }
}

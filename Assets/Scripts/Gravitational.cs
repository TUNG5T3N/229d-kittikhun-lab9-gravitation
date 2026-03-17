using UnityEngine;
using System.Collections.Generic;

public class Gravitational : MonoBehaviour
{
    public static List<Gravitational> otherGameObject;
    private Rigidbody rb;
    const float G = 0.006674f; //6.674

    [SerializeField] bool planet = false;
    [SerializeField] int orbitSpeed = 1000;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        if (otherGameObject == null) { otherGameObject = new List<Gravitational>(); } // สร้างรายชื่อเพื่อ obj อื่นๆ
        otherGameObject.Add(this); // เพิ่ม Class Gravitational ใน obj อื่นใส่รายชื่อ

        if (!planet)
        {
            rb.AddForce(Vector3.left * orbitSpeed);
        }
    }

    void FixedUpdate()
    {
        foreach (Gravitational obj in otherGameObject)
        {
            if (obj != this) { AttractionForce(obj); } // ป้องกันไม่ให้มีแรงดึงดูดตัวเอง
        }
    }

    void AttractionForce(Gravitational other)
    {
        Rigidbody otherRb = other.rb;
        Vector3 dir = rb.position - otherRb.position; // หาทิศทางว่าวัตถุจะโดนดึงไปทางไหน
        float dist = dir.magnitude; // หาระยะทาง ระหว่างวัตถุ
        if (dist == 0f) { return; } // ป้องกันวัตถุเคลื่อนมาตำแหน่งเดียวกัน
        // สูตรคำนวนแรงดึงดูดหรือแรงโน้มถ่วงระหว่างวัตถุ F = G * ((m1 * m2) / r*2)
        float forceMagnitude = G * ((rb.mass * otherRb.mass) / Mathf.Pow(dist, 2));
        Vector3 gravitationalForce = forceMagnitude * dir.normalized; // นำแรงและทิศทางมาใส่ตัวแปร
        otherRb.AddForce(gravitationalForce); // เพิ่มแรงและทิศทางที่ใช้ใส่วัตถุ
    }
}

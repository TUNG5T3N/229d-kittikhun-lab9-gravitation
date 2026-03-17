using UnityEngine;

public class ChangeObjectColor : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        GetComponent<Renderer>().material.color = Color.yellowNice;



        other.gameObject.GetComponent<Renderer>().material.color = Color.hotPink;
    }

    private void OnTriggerEnter(Collider other)
    {
        GetComponent<Renderer>().material.color = Color.turquoise;

        other.gameObject.GetComponent<Renderer>().material.color = Color.purple;
    }
}

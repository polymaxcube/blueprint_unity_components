using UnityEngine;

public class ConveyorPhysic : MonoBehaviour
{
    public float speed;
    private Rigidbody conv;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        conv = GetComponent<Rigidbody>();
        // conv.isKinematic = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 originalPos = conv.position;
        conv.position += Vector3.back * speed * Time.fixedDeltaTime;
        conv.MovePosition(originalPos);
    }
}

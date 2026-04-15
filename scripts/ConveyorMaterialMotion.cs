using UnityEngine;

public class ConveyorMaterialMotion : MonoBehaviour
{
    public float speed = 1.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float Transition = Time.time * speed;
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0f, Transition);
    }
}

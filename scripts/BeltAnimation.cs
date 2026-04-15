using UnityEngine;

public class BeltAnimation : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // public float speed = 1.0f;
    public ConveyorSpeedControl spc;
    public StartButton script;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(script.start)
        {
            float Transition = Time.time * spc.BeltSpeed;
            GetComponent<Renderer>().material.mainTextureOffset = new Vector2(Transition * -1.0f, 0.0f);     
        }

    }
}

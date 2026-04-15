using UnityEngine;

public class ConveryorPulleys : MonoBehaviour
{
    // public float speed = 50.0f;
    public GameObject FrontPulley;
    public GameObject BackPulley;
    public StartButton script;
    public ConveyorSpeedControl spc;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(script.start)
        {
            FrontPulley.transform.Rotate(Vector3.up, spc.PulleySpeed * Time.deltaTime);
            BackPulley.transform.Rotate(Vector3.up, spc.PulleySpeed * Time.deltaTime);
        }
    }
}

using UnityEngine;

public class TrayPhysics : MonoBehaviour
{
    public AxisSlide AxisSlide;
    private Rigidbody Tray;
    private Vector3 pos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Tray = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(AxisSlide.Fw)
        {
            float translation = AxisSlide.speed * Time.fixedDeltaTime;
            pos = Tray.position + Vector3.forward * translation;
            Tray.MovePosition(pos);
        }
        else if(AxisSlide.Bw)
        {
            float translation = AxisSlide.speed * Time.fixedDeltaTime;
            pos = Tray.position + Vector3.back * translation;
            Tray.MovePosition(pos);
        }
    }
}

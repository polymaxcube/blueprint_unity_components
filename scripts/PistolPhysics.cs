using UnityEngine;

public class PistolPhysics : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Rigidbody PistolRd;
    public Vector3 originalPos;
    public Vector3 targetPos;
    public Transform targetObject;
    private bool movingTwTarget = true;
    public bool start = false;
    private Vector3 pos;
    public float speed = 8.0f;

    void Start()
    {
        PistolRd = GetComponent<Rigidbody>();
        originalPos = PistolRd.position;
        targetPos = targetObject.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(start)
        {
            if(movingTwTarget)
            {
                pos = Vector3.MoveTowards(PistolRd.position, targetPos, speed * Time.deltaTime);
                PistolRd.MovePosition(pos);
                if(Vector3.Distance(PistolRd.position, targetPos) < 1.6f)
                {
                    movingTwTarget = false;
                }
            }
             else if(movingTwTarget == false )
            {
                pos = Vector3.MoveTowards(PistolRd.position, originalPos, speed * Time.deltaTime);
                PistolRd.MovePosition(pos);

                if(Vector3.Distance(PistolRd.position, originalPos) < 1.6f)
                {

                    movingTwTarget = true;
                    start = true;

                }
            }

        }
    
    }
}

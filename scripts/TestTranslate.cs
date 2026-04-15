using UnityEngine;

public class TestTranslate : MonoBehaviour
{
    public float speed = 1.0f;
    private bool reverse = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!reverse)
        {
            float translation = speed * Time.deltaTime;
            transform.Translate(Vector3.back * translation);
        }else
        {
            float translation = speed * Time.deltaTime;
            transform.Translate(Vector3.back * translation * -1);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Sensor"))
        {
            reverse = true;
            Debug.Log("Touch!");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Sensor"))
        {
            Debug.Log("No Touch!");
        }
    }
}

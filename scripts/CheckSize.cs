using UnityEngine;

public class CheckSize : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // ดึงค่า Bounding Box จาก MeshRenderer
        Vector3 size = GetComponent<Renderer>().bounds.size;
        Debug.Log("ขนาดจริงในหน่วย Unity: " +
                  " กว้าง(X): " + size.x + 
                  " สูง(Y): " + size.y + 
                  " ลึก(Z): " + size.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

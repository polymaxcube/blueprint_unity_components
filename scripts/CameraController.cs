using UnityEngine;
using UnityEngine.InputSystem; // ต้องเพิ่มบรรทัดนี้

public class CameraController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5.0f;

    [Header("Look Settings")]
    public float mouseSensitivity = 10.0f; // ความไวเมาส์
    public float topClamp = -90.0f;        // องศาจำกัดการเงย
    public float bottomClamp = 90.0f;      // องศาจำกัดการก้ม
    
    private float xRotation = 0.0f;
    private float yRotation = 0.0f;

    void Start()
    {
        // ล็อกเมาส์ให้อยู่กลางจอและซ่อนเคอร์เซอร์
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
        // ตั้งค่าเริ่มต้นมุมกล้อง
        Vector3 rot = transform.localRotation.eulerAngles;
        yRotation = rot.y;
        xRotation = rot.x;
    }

    void Update()
    {
        // 1. ตรวจสอบว่ามีเมาส์เชื่อมต่ออยู่หรือไม่
        if (Mouse.current != null)
        {
            // อ่านค่า Delta ของเมาส์ (การขยับ)
            Vector2 mouseDelta = Mouse.current.delta.ReadValue();
            
            float mouseX = mouseDelta.x * mouseSensitivity * Time.deltaTime;
            float mouseY = mouseDelta.y * mouseSensitivity * Time.deltaTime;

            // คำนวณการหมุน (แกน Y คือหันซ้ายขวา, แกน X คือก้มเงย)
            yRotation += mouseX;
            xRotation -= mouseY;

            // จำกัดมุมก้มเงยไม่ให้กล้องพลิกกลับหัว
            xRotation = Mathf.Clamp(xRotation, topClamp, bottomClamp);

            // สั่งหมุนกล้อง
            transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0.0f);
        }

        // 2. การเคลื่อนที่ (Movement) แบบ New Input System
        if (Keyboard.current != null)
        {
            Vector3 direction = Vector3.zero;
            if (Keyboard.current.wKey.isPressed) direction += transform.forward;
            if (Keyboard.current.sKey.isPressed) direction -= transform.forward;
            if (Keyboard.current.aKey.isPressed) direction -= transform.right;
            if (Keyboard.current.dKey.isPressed) direction += transform.right;

            // เคลื่อนที่ตามทิศทางที่กล้องหันอยู่
            // (ใช้ direction.normalized เพื่อให้เฉียงแล้วไม่เดินเร็วขึ้น)
            transform.position += direction.normalized * moveSpeed * Time.deltaTime;
        }
    }
}
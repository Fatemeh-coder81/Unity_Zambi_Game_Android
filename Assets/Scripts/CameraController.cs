using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float speed;
    public DynamicJoystick variableJoystick;

    // تعریف محدوده‌های مجاز برای حرکت دوربین
    public float minX, maxX;
    public float minZ, maxZ;

    void FixedUpdate()
    {
        // محاسبه موقعیت جدید دوربین
        float newX = transform.position.x + (variableJoystick.Horizontal * speed * Time.deltaTime);
        float newZ = transform.position.z + (variableJoystick.Vertical * speed * Time.deltaTime);

        // اطمینان حاصل کردن از اینکه موقعیت جدید دوربین در محدوده مجاز قرار دارد
        newX = Mathf.Clamp(newX, minX, maxX);
        newZ = Mathf.Clamp(newZ, minZ, maxZ);

        // اعمال موقعیت جدید به دوربین
        transform.position = new Vector3(newX, transform.position.y, newZ);
    }
}

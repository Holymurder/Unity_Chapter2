using UnityEngine;

public class CubeRotation : MonoBehaviour
{
    public int RotationsPerMinute = 60;
    public bool IsQuaternion = true;

    private float _rotationSpeed;

    void Update()
    {
        _rotationSpeed = RotationsPerMinute * 360f / 60f;

        if (IsQuaternion)
        {
            //transform.rotation *= Quaternion.AngleAxis(_rotationSpeed * Time.deltaTime, new Vector3(90, 0, 0));
            transform.rotation *= Quaternion.AngleAxis(_rotationSpeed * Time.deltaTime, Vector3.up);
        }
        else
        {
            //transform.eulerAngles += new Vector3(90, 0, 0) * Time.deltaTime * _rotationSpeed;
            transform.eulerAngles += Vector3.up * _rotationSpeed * Time.deltaTime;
        }
    }
}

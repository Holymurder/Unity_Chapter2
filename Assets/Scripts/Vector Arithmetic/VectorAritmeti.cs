using UnityEngine;

public class SimpleMove : MonoBehaviour
{
    public float Speed = 5f;
    public float RotationSpeed = 720f;

    private Vector3 _currentDirection = Vector3.forward;

    private void Update()
    {
        Vector3 inputDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        if (inputDirection.sqrMagnitude > 0.01f)
        {
            Vector3 targetDirection = inputDirection.normalized;

            float alignment = Vector3.Dot(_currentDirection, targetDirection);
            Vector3 cross = Vector3.Cross(_currentDirection, targetDirection);
            float turnDirection = Mathf.Sign(cross.y);

            float angleStep = RotationSpeed * Time.deltaTime;
            float angleBetween = Mathf.Acos(Mathf.Clamp(alignment, -1f, 1f)) * Mathf.Rad2Deg;
            float turnAngle = Mathf.Min(angleStep, angleBetween);

            _currentDirection = Quaternion.AngleAxis(turnAngle * turnDirection, Vector3.up) * _currentDirection;
            transform.position += _currentDirection * Speed * Time.deltaTime;

            if (_currentDirection != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(_currentDirection);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, RotationSpeed * Time.deltaTime);
            }
        }
    }
}

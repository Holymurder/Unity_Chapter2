using UnityEngine;

public class WeaponRayVsSphereCast : MonoBehaviour
{
    public float MaxDistance = 100f;
    public float PushForce = 10f;
    public float SphereRadius = 0.5f;

    [Header("Розпорошення (spray) для SphereCast")]
    [Range(0f, 10f)]
    public float SpreadAngleInDegrees = 3f;

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            Debug.DrawRay(ray.origin, ray.direction * MaxDistance, Color.red, 2f);

            if (Physics.Raycast(ray, out RaycastHit hitInfo, MaxDistance))
            {
                Debug.Log("Raycast (Sniper) влучив в: " + hitInfo.collider.name);

                ApplyRandomColor(hitInfo.collider);
                ApplyForce(hitInfo.collider, ray.direction);
            }
            else
            {
                Debug.Log("Raycast (Sniper) промінь ні в що не влучив.");
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            Vector3 spreadDirection = GetSpreadDirection(ray.direction, SpreadAngleInDegrees);
            Ray spreadRay = new Ray(ray.origin, spreadDirection);

            if (Physics.SphereCast(spreadRay, SphereRadius, out RaycastHit hitInfo, MaxDistance))
            {
                Debug.Log("SphereCast (Assault Rifle) влучив в: " + hitInfo.collider.name);

                Debug.DrawLine(spreadRay.origin, hitInfo.point, Color.cyan, 2f);
                DrawSphereHitVisualization(hitInfo.point, SphereRadius, Color.cyan);

                ApplyRandomColor(hitInfo.collider);
                ApplyForce(hitInfo.collider, spreadDirection);
            }
            else
            {
                Debug.DrawRay(spreadRay.origin, spreadRay.direction * MaxDistance, Color.blue, 2f);
                Debug.Log("SphereCast (Assault Rifle) нічого не знайшов.");
            }
        }
    }

    private Vector3 GetSpreadDirection(Vector3 forward, float angle)
    {
        Quaternion randomRotation = Quaternion.Euler(
            Random.Range(-angle, angle),
            Random.Range(-angle, angle),
            0f
        );
        return randomRotation * forward;
    }

    private void ApplyRandomColor(Collider collider)
    {
        Renderer renderer = collider.GetComponent<Renderer>();
        if (renderer != null)
        {
            Color randomColor = new Color(
                Random.Range(0.2f, 1f),
                Random.Range(0.2f, 1f),
                Random.Range(0.2f, 1f)
            );
            renderer.material.color = randomColor;
        }
    }

    private void ApplyForce(Collider collider, Vector3 direction)
    {
        Rigidbody rb = collider.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(direction * PushForce, ForceMode.Impulse);
        }
    }

    private void DrawSphereHitVisualization(Vector3 position, float radius, Color color)
    {
        Debug.DrawLine(position + Vector3.up * radius, position - Vector3.up * radius, color, 2f);
        Debug.DrawLine(position + Vector3.right * radius, position - Vector3.right * radius, color, 2f);
        Debug.DrawLine(position + Vector3.forward * radius, position - Vector3.forward * radius, color, 2f);
    }
}

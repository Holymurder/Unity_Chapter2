using UnityEngine;
using TMPro;

public class BouncyBall : MonoBehaviour
{
    private int _bounceCount = 0;
    private int _passThroughCount = 0;

    public TMP_Text BounceText;
    public TMP_Text PassText;
    public TMP_Text DistanceText;
    public Transform Floor;

    public GameObject MiddleSensorObject;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Default"))
        {
            _bounceCount++;
            UpdateUI();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (MiddleSensorObject != null && other.gameObject == MiddleSensorObject)
        {
            _passThroughCount++;
            UpdateUI();
        }
    }

    private void Update()
    {
        float distance = transform.position.y - Floor.position.y;
        DistanceText.text = $"³������ �� ������: {distance:F2} �";
    }

    private void UpdateUI()
    {
        BounceText.text = $"³������: {_bounceCount}";
        PassText.text = $"������� ����� �����: {_passThroughCount}";
    }
}

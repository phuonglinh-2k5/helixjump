using UnityEngine;

public class GlowEffect : MonoBehaviour
{
    public float rotateSpeed = 30f;
    public float pulseSpeed = 2f;
    public float scaleAmount = 0.1f;

    private Vector3 baseScale;

    void Start()
    {
        baseScale = transform.localScale;
    }

    void Update()
    {
        // Xoay
        transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);

        // Phóng to thu nhỏ
        float scale = 1 + Mathf.Sin(Time.time * pulseSpeed) * scaleAmount;
        transform.localScale = baseScale * scale;
    }
}
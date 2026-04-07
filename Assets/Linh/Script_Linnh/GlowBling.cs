using UnityEngine;
using UnityEngine.UI;

public class GlowBling : MonoBehaviour
{
    public float pulseSpeed = 2f;
    public float pulseScale = 0.05f;

    public float blinkSpeed = 3f;
    public float minAlpha = 0.5f;
    public float maxAlpha = 1f;

    private RectTransform rect;
    private CanvasGroup cg;

    void Start()
    {
        rect = GetComponent<RectTransform>();

        cg = GetComponent<CanvasGroup>();
        if (cg == null)
            cg = gameObject.AddComponent<CanvasGroup>();
    }

    void Update()
    {
        // 👉 Pulse (phồng nhẹ)
        float scale = 1 + Mathf.Sin(Time.time * pulseSpeed) * pulseScale;
        rect.localScale = new Vector3(scale, scale, 1);

        // 👉 Blink (nhấp nháy)
        float alpha = Mathf.Lerp(minAlpha, maxAlpha,
            (Mathf.Sin(Time.time * blinkSpeed) + 1f) / 2f);

        cg.alpha = alpha;
    }
}
using UnityEngine;

public class RankSystem : MonoBehaviour
{
    [System.Serializable]
    public class RankData
    {
        public RectTransform root;
        public GameObject glowCup;
        public GameObject glowChest;
    }

    public RankData bronze;
    public RankData silver;
    public RankData gold;
    public RankData ruby;
    public RankData emerald;
    public RankData diamond;

    public int score;
    public int rank;

    [Header("UI Effect")]
    public float scaleNormal = 1f;
    public float scaleHighlight = 1.2f;

    public float fadeNormal = 0.5f;
    public float fadeHighlight = 1f;

    [Header("Arrow")]
    public RectTransform arrowLeft;
    public RectTransform arrowRight;

    public float arrowSpeed = 8f;

    void Start()
    {
        UpdateAll();
    }

    void Update()
    {
        UpdateAll();
    }

    public void AddScore(int amount)
    {
        score += amount;
    }

    void UpdateAll()
    {
        UpdateRank();

        UpdateUI(bronze, 0);
        UpdateUI(silver, 1);
        UpdateUI(gold, 2);
        UpdateUI(ruby, 3);
        UpdateUI(emerald, 4);
        UpdateUI(diamond, 5);
    }

    void UpdateRank()
    {
        if (score >= 1000) rank = 5;
        else if (score >= 800) rank = 4;
        else if (score >= 600) rank = 3;
        else if (score >= 400) rank = 2;
        else if (score >= 200) rank = 1;
        else rank = 0;
    }

    void UpdateUI(RankData data, int index)
    {
        if (data.root == null) return;

        CanvasGroup cg = data.root.GetComponent<CanvasGroup>();
        if (cg == null) cg = data.root.gameObject.AddComponent<CanvasGroup>();

        if (rank == index)
        {
            // SCALE
            data.root.localScale = Vector3.Lerp(
                data.root.localScale,
                Vector3.one * scaleHighlight,
                Time.deltaTime * 8f
            );

            // FADE
            cg.alpha = Mathf.Lerp(
                cg.alpha,
                fadeHighlight,
                Time.deltaTime * 8f
            );

            // GLOW
            if (data.glowCup) data.glowCup.SetActive(true);
            if (data.glowChest) data.glowChest.SetActive(true);

            // 👉 MOVE ARROW (FIX CHUẨN)
            MoveArrow(data.root);
        }
        else
        {
            data.root.localScale = Vector3.Lerp(
                data.root.localScale,
                Vector3.one * scaleNormal,
                Time.deltaTime * 8f
            );

            cg.alpha = Mathf.Lerp(
                cg.alpha,
                fadeNormal,
                Time.deltaTime * 8f
            );

            if (data.glowCup) data.glowCup.SetActive(false);
            if (data.glowChest) data.glowChest.SetActive(false);
        }
    }

    void MoveArrow(RectTransform target)
    {
        if (arrowLeft == null || arrowRight == null) return;

        // 👉 LẤY VỊ TRÍ Y THẬT (WORLD)
        float targetY = target.position.y;

        // 👉 LEFT
        Vector3 leftPos = arrowLeft.position;
        leftPos.y = targetY;

        arrowLeft.position = Vector3.Lerp(
            arrowLeft.position,
            leftPos,
            Time.deltaTime * arrowSpeed
        );

        // 👉 RIGHT
        Vector3 rightPos = arrowRight.position;
        rightPos.y = targetY;

        arrowRight.position = Vector3.Lerp(
            arrowRight.position,
            rightPos,
            Time.deltaTime * arrowSpeed
        );
    }
}
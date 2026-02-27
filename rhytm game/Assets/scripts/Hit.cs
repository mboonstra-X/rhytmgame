using System.Collections;
using UnityEngine;

public class Hit : MonoBehaviour
{
    public SpriteRenderer beatBorder;
    public SpriteRenderer fill;
    public Color OriginalColor;
    public Color FadedColor;

    public Color fillColor;
    public Color fillFade;

    public Vector3 startScale;
    public Vector3 endScale;

    private float bias;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(AlphaLerp());
        startScale = new Vector3(2f, 2f, 1f);
        endScale = new Vector3(1.15f, 1.15f, 1f);

        bias = Vector3.Distance(startScale.normalized, endScale.normalized);

        //Start at larger scale.
        beatBorder.transform.localScale = startScale;
    }

    public IEnumerator AlphaLerp()
    {
        for (float i = 0; i < 1.5f; i += Time.deltaTime)
        {
            beatBorder.transform.localScale = Vector3.Lerp(startScale, endScale, i / 1.5f);
            beatBorder.color = Color.Lerp(OriginalColor, FadedColor, i / 1.5f);
            fill.color = Color.Lerp(fillColor, fillFade, i / 1.5f);
            yield return null;
        }
    }

    public void OnMouseDown()
    {
        float score;
        //0 to 100. early is 0, on time is 100.

        //0.15 => 0 
        score = bias - (Vector3.Distance(beatBorder.transform.localScale.normalized, endScale.normalized));
        score *= 100 / bias;
        Debug.Log("Hit! Score: " + score);
        Destroy(gameObject);
    }
}

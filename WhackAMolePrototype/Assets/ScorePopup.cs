using UnityEngine;
using TMPro;
public class ScorePopup : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public string stringText;
    public Transform target;
    private Vector3 endPosition;
    private Vector3 startPosition;

    public float desiredDuration = 3f;
    private float elapsedTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        startPosition = transform.position;
        endPosition = transform.position + Vector3.up;
        SetStringText(stringText);
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        float percentageComplete = elapsedTime / desiredDuration;
        ////rotate to face the center
        transform.position = Vector3.Lerp(startPosition, endPosition, percentageComplete);

        //transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        transform.up = target.position - transform.position;
        if (percentageComplete > 99)
        {
            Destroy(this);
        }
    }

    public void SetStringText(string text)
    {
        scoreText.text += $"+{text}";
    }
}

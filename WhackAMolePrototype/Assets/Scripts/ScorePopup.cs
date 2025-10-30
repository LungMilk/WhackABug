using UnityEngine;
using TMPro;
public class ScorePopup : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public string stringText;
    //public Transform target;
    private Vector3 endPosition;
    private Vector3 startPosition;

    public float desiredDuration = 3f;
    public float elapsedTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetStringText(stringText);
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject,desiredDuration);
    }

    public void SetStringText(string text)
    {
        scoreText.text = $"+{text}";
    }
}

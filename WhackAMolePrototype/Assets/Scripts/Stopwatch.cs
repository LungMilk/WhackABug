using UnityEngine;
using TMPro;
public class Stopwatch : MonoBehaviour
{
    public float currentTime;
    public TextMeshProUGUI timerText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentTime = 0;
        timerText.text = currentTime.ToString("D2");
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        timerText.text = currentTime.ToString("D2");
    }
}

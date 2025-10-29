using UnityEngine;

public class LerpMovement : MonoBehaviour
{
    public Transform target;
    private Vector3 endPosition = new Vector3(0, 0, -10);
    private Vector3 startPosition;
    public float desiredDuration = 3f;
    private float elapsedTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPosition = transform.position;
        endPosition = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        float percentageComplete = elapsedTime / desiredDuration;
        //rotate to face the center
        transform.position = Vector3.Lerp(startPosition, endPosition, percentageComplete);
    }
}

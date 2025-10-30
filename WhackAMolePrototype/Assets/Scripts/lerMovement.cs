using Unity.Mathematics;
using UnityEngine;

public class LerpMovement : MonoBehaviour
{
    public Transform target;
    private Vector3 endPosition = new Vector3(0, 0, -10);
    private Vector3 startPosition;

    public float desiredDuration = 3f;
    private float elapsedTime;

    public float offset = -90f;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPosition = transform.position;
        endPosition = target.position;

        
    }

    // Update is called once per frame
    void Update()
    {
        

        elapsedTime += Time.deltaTime;
        float percentageComplete = elapsedTime / desiredDuration;
        //rotate to face the center
        transform.position = Vector3.Lerp(startPosition, endPosition, percentageComplete);

        if (transform.position == target.position)
        {
            //LossManager.instance.End();
        }

        float xDiff = target.transform.position.x - transform.position.x;
        float yDiff = target.transform.position.y - transform.position.y;

        float radians = Mathf.Atan2(yDiff, xDiff);
        float degrees = radians * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, degrees + offset);

    }
}

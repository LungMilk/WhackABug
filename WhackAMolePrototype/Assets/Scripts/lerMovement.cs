using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class LerpMovement : MonoBehaviour
{
    //I need to make these enemies scan out and find a nearby goal object
    //then we get our direction to said object
    //then we will move ourselves in that direction overtime at a constant speed
    //then we will arrive;

    public Transform target;
    private Vector3 endPosition = new Vector3(0, 0, -10);
    private Vector3 startPosition;

    //public float desiredDuration = 3f;
    private float elapsedTime;
    public float speed = 5f;
    //public float offset = -90f;
    public float scanRadius = 10f;
    public string targetTag = "Goal";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPosition = transform.position;
        endPosition = target.position;
    }

    // Update is called once per frame
    void Update()
    {
        ScanForObjects();
        //elapsedTime += Time.deltaTime;
        //float percentageComplete = elapsedTime / desiredDuration;
        ////rotate to face the center
        //transform.position = Vector3.Lerp(startPosition, endPosition, percentageComplete);

        if (transform.position == target.position)
        {
            //LossManager.instance.End();
        }

        float xDiff = target.transform.position.x - transform.position.x;
        float yDiff = target.transform.position.y - transform.position.y;

        float radians = Mathf.Atan2(yDiff, xDiff);
        float degrees = radians * Mathf.Rad2Deg;

        //transform.rotation = Quaternion.Euler(0, 0, degrees + offset);
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        transform.up = target.position - transform.position;
    }
    void ScanForObjects()
    {
        // Get all colliders within the scanRadius around this object's position
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, scanRadius);

        foreach (var hitCollider in hitColliders)
        {
            // Check if the object has the target tag
            if (hitCollider.CompareTag(targetTag) && target.transform ==null)
            {
                target = hitCollider.gameObject.transform;
                // Perform actions on the found object
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, scanRadius);
    }
}

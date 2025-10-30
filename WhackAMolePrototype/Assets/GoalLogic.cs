using UnityEngine;

public class GoalLogic : MonoBehaviour
{
    //we need to have the goal check for other colliders and if they have the same tag kill itself
    public string detectedTag;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //print("There is bugs in my skin");
        if (collision.gameObject.tag == detectedTag)
        {
            print("AAAAAAAAA");
            Destroy(this.gameObject);
        }
    }
}

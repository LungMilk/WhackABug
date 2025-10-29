using UnityEngine;

public class LossManager : MonoBehaviour
{
    public LayerMask mask;
    public string tag;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
      
       if(collision.gameObject.tag == tag.ToString())
        {
            Debug.Log("Hit");

        }

        
    }
}

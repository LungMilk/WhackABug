using UnityEngine;

public class Bug : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Color bugColor;
    public float scoreWorth;
    public GameObject scoreEffect;
    private void Awake()
    {
        //spriteRenderer.color = bugColor;   
    }

    public void Squashed()
    {
        if (scoreEffect != null) { Instantiate(scoreEffect, gameObject.transform.position, Quaternion.identity); }
        Destroy(gameObject);
    }
}

using UnityEngine;

public class Bug : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Color bugColor;
    public float scoreWorth;
    private void Awake()
    {
        //spriteRenderer.color = bugColor;   
    }

    public void Squashed()
    {
        Destroy(gameObject);
    }
}

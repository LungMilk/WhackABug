using UnityEngine;

public class Bug : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Color bugColor;
    private void Awake()
    {
        spriteRenderer.color = bugColor;   
    }

    public void Squashed()
    {
        Destroy(gameObject);
    }
}

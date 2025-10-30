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
        if (scoreEffect != null) 
        {
            GameObject newScoreEffect = Instantiate(scoreEffect, gameObject.transform.position, Quaternion.identity); 
            newScoreEffect.GetComponent<ScorePopup>().SetStringText(scoreWorth.ToString());
        }
        Destroy(gameObject);
    }
}

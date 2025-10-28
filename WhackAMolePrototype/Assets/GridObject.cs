using UnityEngine;
using TMPro;
public class GridObject : MonoBehaviour
{
    public int position;
    public string name;
    public TextMeshProUGUI label;
    public Transform spawnPosition;
    private SpriteRenderer spr;
    public bool occupied;
    public Bug bug;

    public Color defaultColor = Color.white;
    public Color occupiedColor = Color.red;

    private void Awake()
    {
        label = GetComponentInChildren<TextMeshProUGUI>();
        spr = GetComponentInChildren<SpriteRenderer>();
        label.text = name;
    }

    public void SetObjectStatus(bool Occupied)
    {
        occupied = Occupied;
        if (Occupied) 
        {
            spr.color = occupiedColor;
        }else
        {
            spr.color=defaultColor;
        }

    }

    private void OnMouseDown()
    {
        SetObjectStatus(false);
    }
}

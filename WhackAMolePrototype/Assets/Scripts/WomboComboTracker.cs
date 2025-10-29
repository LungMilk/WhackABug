using UnityEngine;
using TMPro;
using UnityEngine.Events;
public class WomboComboTracker : MonoBehaviour
{
    public TextMeshProUGUI comboTracker;
    private float comboValue;
    public float comboMax;
    public float comboMin;

    private void Awake()
    {
        gridManager.comboAction += ChangeComboTracker;
    }
    private void Update()
    {
        comboTracker.text = comboValue.ToString();
    }

    public void ChangeComboTracker(bool status)
    {
        if (status) { IncreaseComboTracker(); }
        else { ResetComboTracker(); }
    }

    public void ResetComboTracker()
    {
        //print("reset Combo tracker");
        comboValue = comboMin;
        ScoreManager.Instance.currentMultiplier = comboMin;
    }
    public void IncreaseComboTracker()
    {
        //print("Increase Combo tracker");
        comboValue++;
        if (comboValue > comboMax)
        {
            comboValue = comboMax;
        }
        ScoreManager.Instance.currentMultiplier = comboValue;
    }
}

using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Stat current;
    [SerializeField] Stat max;
    [SerializeField] Image bar;

    // Update is called once per frame
    void Update()
    {
        bar.fillAmount = (float)current.amount / (float)max.amount;
    }
}

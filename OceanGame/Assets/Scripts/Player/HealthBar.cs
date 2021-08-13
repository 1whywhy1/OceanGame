using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private HealthSystem healthSystem;

    [SerializeField] private RectTransform barContainerTransform;

    private void OnEnable()
    {
        barContainerTransform = transform.Find("Bar").GetComponent<RectTransform>();
    }
    public void Setup(HealthSystem healthSystem)
    {
        this.healthSystem = healthSystem;
        healthSystem.OnHealthChanged += HealthSystem_OnHealthChanged;
    }

    private void HealthSystem_OnHealthChanged(object sender, System.EventArgs e)
    {
        Debug.Log("Bar Change");
        barContainerTransform.localScale = new Vector3(healthSystem.GetHealthPercent(), 1.0f);
    }

    //public void SetValue(float value)
    //{
    //    barContainerTransform.localScale = new Vector3(value, 1.0f, 1.0f); 
    //}
}

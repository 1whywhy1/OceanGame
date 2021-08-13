using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Variables

    // Health System
    private HealthSystem healthSystem;
    [Tooltip("Max Health value between 0 and 10.")]
    [SerializeField] private int maxHealth = 10;

    // Heath bar
    [SerializeField] private HealthBar healthBar;
    
    // Breathing System
    [Tooltip("Breath value between 0 and 20.")]
    [SerializeField] private float _breath = 20;

    // Breathing change
    [Tooltip("Breath decay rate")]
    [SerializeField] private float _breathReplenishRate= 1.0f;
    [Tooltip("Breath decay rate")]
    [SerializeField] private float _breathDecayRate = 1.0f;
    [Tooltip("Decay tick")]
    [SerializeField] private float _breathTick = 1.0f;

    // Breathing in
    public Transform surfaceCheck;
    public LayerMask surfaceLayer;
    #endregion

    #region OnEnable
    void OnEnable()
    {
        healthSystem = new HealthSystem(maxHealth);
       // healthBar = transform.Find("Bar").GetComponent<HealthBar>();
        healthBar.Setup(healthSystem);
    }
    #endregion

    #region DealDamage
    public void DealDamage(int damage)
    {
        healthSystem.Damage(damage);
    }
    #endregion

    #region Update
    private void Update()
    {
        _breath -= Time.deltaTime * _breathDecayRate;

        if (IsSurfaced())
        {
            InvokeRepeating("BreatheIn", 0.0f, 1.0f);
        }
    }

    #endregion

    #region IsSurfaced
    private bool IsSurfaced()
    {
        return Physics2D.OverlapCircle(surfaceCheck.position, 0.2f, surfaceLayer);

    }
    #endregion

    #region Breathe
    private void BreatheIn()
    {
        _breath += _breathReplenishRate;
    }

    #endregion
}

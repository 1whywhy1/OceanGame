using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private float movement = 1.0f;
    [SerializeField] private int damage = 1;

    #region OnEnable
    void OnEnable()
    {
        
    }
    #endregion


    #region Update
    void Update()
    {
        // Apply constant movement to the left on X axis.
        transform.Translate(-Vector3.right * Time.deltaTime * movement, Space.World);
    }
    #endregion

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.transform.GetComponent<Player>().DealDamage(damage);
    }
}

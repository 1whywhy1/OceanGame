using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    #region Variables
    [SerializeField] float _range = 3.0f;
    [SerializeField] float _frequency = 2.0f;
    [SerializeField] GameObject _objectToSpawn;

    private Vector3 pos;

    //private float nextActionTime = 0.0f;

    #endregion

    #region OnEnable
    void OnEnable()
    {
        pos = transform.position;

        InvokeRepeating("Spawn", 0.0f, _frequency);

    }
    #endregion

    #region Update
    void Update()
    {
        //if (Time.time > nextActionTime)
        //{
        //    nextActionTime += _frequency;
        //    // execute block of code here
        //}

      
    }
    #endregion

    #region Spawn
    private void Spawn()
    {
        float y = Random.Range(pos.y - _range, pos.y + _range);
        Vector3 vec = new Vector3(transform.position.x, y, transform.position.z);
        Instantiate(_objectToSpawn, vec, Quaternion.identity);
    }
    #endregion

    #region CoSpawn
    IEnumerator CoSpawn()
    {
        yield return new WaitForSeconds(_frequency);
        float y = Random.Range(pos.y - _range, pos.y + _range) ;
        Vector3 vec = new Vector3(transform.position.x, y, transform.position.z);
        Instantiate(_objectToSpawn, vec, Quaternion.identity);
    }
    #endregion
}

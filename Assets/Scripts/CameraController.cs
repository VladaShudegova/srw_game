using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject _target; //цель камеры
    [SerializeField] private float _smoothing;
    [SerializeField] private Vector3 _offset;

    //Vector3 offset; //смещение относительно цели
    // Start is called before the first frame update
    void Start()
    {
        //offset = transform.position - _target.transform.position; //вычисляем смещение
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //transform.position = _target.transform.position + offset; //двигаем камеру за целью

        transform.position = _offset + Vector3.Lerp(transform.position, _target.transform.position, Time.deltaTime * _smoothing);
    }
}

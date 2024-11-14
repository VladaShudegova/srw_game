using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject _target; //���� ������
    [SerializeField] private float _smoothing;
    [SerializeField] private Vector3 _offset;

    //Vector3 offset; //�������� ������������ ����
    // Start is called before the first frame update
    void Start()
    {
        //offset = transform.position - _target.transform.position; //��������� ��������
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //transform.position = _target.transform.position + offset; //������� ������ �� �����

        transform.position = _offset + Vector3.Lerp(transform.position, _target.transform.position, Time.deltaTime * _smoothing);
    }
}

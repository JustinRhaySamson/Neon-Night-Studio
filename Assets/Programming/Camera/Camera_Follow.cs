using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour
{


    private Vector3 _offset;
    [SerializeField] private Transform player;
    [SerializeField] private float smoothTime;
    private Vector3 _currentVelocity = Vector3.zero;
    float previous_smooth;

    private void Awake()
    {
        _offset = transform.position - player.position;
    }

    private void LateUpdate()
    {
        Vector3 targetPosition = player.position + _offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _currentVelocity, smoothTime);
    }

    public void Smooth_To_0()
    {
        previous_smooth = smoothTime;
        smoothTime = 0;
    }

    public void Revert_Smooth()
    {
        smoothTime = .25f;
    }


}

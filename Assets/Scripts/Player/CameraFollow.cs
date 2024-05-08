using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private CinemachineVirtualCamera _camera;
    void Start()
    {
        _camera = GetComponent<CinemachineVirtualCamera>();
        _camera.Follow = MovPlayer.Instance.gameObject.transform;
        this.enabled = false;
    }

}

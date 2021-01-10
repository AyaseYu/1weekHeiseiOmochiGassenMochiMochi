using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// namespaceで囲むとフォルダわけを行うことができる。
namespace World
{
    public class CameraManager : MonoBehaviour
    {
        [SerializeField] Camera subCamera = default;
        [SerializeField] Transform subCameraTarget = default;


        private void LateUpdate()
        {
            Vector3 newPositon = subCameraTarget.transform.position;
            newPositon.z = subCamera.transform.position.z;
            subCamera.transform.position = newPositon;
        }
    }
}


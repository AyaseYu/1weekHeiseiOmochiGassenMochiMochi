using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// namespaceで囲むとフォルダわけを行うことができる。このクラスを使いたい場合は using World;を上につけるといい。
namespace World
{
    public class CameraManager : MonoBehaviour
    {
        [SerializeField] Camera subCamera = default;
        [SerializeField] Transform subCameraTarget = default;


        // ボールを追いかけるようにしている.
        private void LateUpdate()
        {
            Vector3 newPositon = subCameraTarget.transform.position;
            newPositon.z = subCamera.transform.position.z; // ただしz座標は今と同じ場所
            subCamera.transform.position = newPositon;
        }
    }
}


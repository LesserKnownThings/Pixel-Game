using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.CameraNamespace
{
    public class SmoothCameraFollow : MonoBehaviour
    {
        public float followSpeed = 2f;
        public Transform target;

        private void Update()
        {
            if (target == null)
                return;

            Vector3 newPosition = target.position;
            newPosition.z = -10;
            transform.position = Vector3.Slerp(transform.position, newPosition, followSpeed * Time.deltaTime);
        }
    }
}

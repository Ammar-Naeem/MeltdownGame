using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Meltdown
{
    public class RideController : MonoBehaviour
    {
        [SerializeField] private float speed = 5;

        // Update is called once per frame
        void Update()
        {
            transform.Rotate(Vector3.up * (speed * Time.deltaTime));
        }
    }
}

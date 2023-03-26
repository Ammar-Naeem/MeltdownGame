using System;
using System.Collections;
using System.Collections.Generic;
using MyNamespace;
using UnityEngine;

namespace Meltdown
{
    public class RideController : MonoBehaviour
    {
        [Header("References:")] [SerializeField]
        private RideCylinderReference rideCylinderReference;
        
        [Header("Data:")]
        [SerializeField] private float speed = 5;
        [SerializeField] private float maximumVelocity = 5;

        private Rigidbody _rigidbody;
        
        //Getters
        public RideCylinderReference GetRideCylinderReference() => rideCylinderReference;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            _rigidbody.inertiaTensorRotation = Quaternion.identity;
            // _rigidbody.position = Vector3.zero;
            _rigidbody.AddTorque(transform.up * speed, ForceMode.Force);
            // transform.Rotate(Vector3.up * (speed * Time.deltaTime));

            _rigidbody.maxAngularVelocity = maximumVelocity;
        }
    }
}

namespace VRTK.Examples
{
    using UnityEngine;
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class FllowController : MonoBehaviour
    {

        public GameObject leftController;
        public GameObject rightController;
        private GameObject target;
        public VRTK_ControllerPointerEvents_ListenerExample r;
        public float factor = 1.0f;

        Vector3 ControllerOldPos;
        Vector3 ControllerNewPos;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            ControllerNewPos = rightController.transform.position;
            if (r.fllow)
            {
                if (r.target != null)
                {
                    target = r.target;
                }
                if (ControllerOldPos != null)
                {
                    float x = target.transform.position.x;
                    float z = target.transform.position.z;
                    float y = target.transform.position.y;
                    target.transform.position = new Vector3(x, y + (ControllerNewPos.y-ControllerOldPos.y)*factor, z);
                    //target.transform.position += ControllerNewPos - ControllerOldPos;
                }
            }
            ControllerOldPos = rightController.transform.position;
        }
    }
}

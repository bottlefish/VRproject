namespace VRTK.Examples
{
    using UnityEngine;
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class FllowController : MonoBehaviour
    {

        public VRTK_ControllerPointerEvents_ListenerExample v;
        public GameObject rightController;
        public float factor = 1.0f;

        Vector3 ControllerOldPos;
        Vector3 ControllerNewPos;

        GameObject target;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update() {
            ControllerNewPos = rightController.transform.position;
            if (ControllerOldPos != null) {
                target = v.chosenTarget;
                if (target != null && target.tag =="Cube") {
                    float x = target.transform.position.x;
                    float z = target.transform.position.z;
                    float y = target.transform.position.y;
                    target.transform.position = new Vector3(x, y + (ControllerNewPos.y - ControllerOldPos.y) * factor, z);
                }
            }
            ControllerOldPos = rightController.transform.position;
        }

    }
}

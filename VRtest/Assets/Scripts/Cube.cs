using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{

    private MeshRenderer render;
    public Material highLightMat;
    public float factor = 1.5f;
    Vector3 ControllerOldPos;
    Vector3 ControllerNewPos;
    private Material originMat;
    public bool isTriggerMe = false;
    private GameObject rightController;

    void Awake()
    {
        rightController = GameObject.FindWithTag("RightController");
        render = GetComponent<MeshRenderer>();
        originMat = render.material;
    }


    void Update()
    {
        ControllerNewPos = rightController.transform.position;
        if (ControllerOldPos != null)
        {
            if (isTriggerMe)
            {
                float x = transform.position.x;
                float z = transform.position.z;
                float y = transform.position.y;
                transform.position = new Vector3(x, y + (ControllerNewPos.y - ControllerOldPos.y) * factor, z);
            }
        }
        ControllerOldPos = rightController.transform.position;
    }

    public void HighLightToNormal()
    {

        render.material = originMat;
    }

    public void NormalToHighLight()
    {

        render.material = highLightMat;
    }



}


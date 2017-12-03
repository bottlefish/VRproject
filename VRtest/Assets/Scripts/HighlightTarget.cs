using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightTarget : MonoBehaviour {

   
    Material InitailMaterial;
    public Material HighlightMaterial;

	void Start () {
		
	}
	
	void Update () {
        
    }

    public void SetHighlightMaterial(Transform target) {
            InitailMaterial = target.GetComponent<MeshRenderer>().material;
            target.GetComponent<MeshRenderer>().material = HighlightMaterial;
    }

    public void SetInitailMaterial(Transform target) {
            target.GetComponent<MeshRenderer>().material = InitailMaterial;
    }
}

namespace VRTK.Examples {

    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class HighlightTarget : MonoBehaviour {

        public VRTK_ControllerPointerEvents_ListenerExample v;

        Material InitailMaterial;
        public Material HighlightMaterial;

        public GameObject oldTarget;
        public GameObject target;

	    void Start () {
		
	    }
	
	    void Update () {
            
            
            target = v.highlightTarget;
            if(oldTarget != null ) {
                if (target == null || oldTarget != target ){
                    oldTarget.GetComponent<MeshRenderer>().material = InitailMaterial;
                }
            }
            if(target != null ) {
                if (oldTarget == null || target != oldTarget) {
                    InitailMaterial = target.GetComponent<MeshRenderer>().material;
                    if(target.tag == "Cube") {
                        target.GetComponent<MeshRenderer>().material = HighlightMaterial;
                    }
                }
            }
            oldTarget = target;
        }

        //void SetHighlightMaterial(GameObject target) {
        //    InitailMaterial = target.GetComponent<MeshRenderer>().material;
        //    target.GetComponent<MeshRenderer>().material = HighlightMaterial;
        //}

        //void SetInitailMaterial(GameObject target) {
        //    target.GetComponent<MeshRenderer>().material = InitailMaterial;
        //}

    }

}

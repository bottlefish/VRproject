namespace VRTK.Examples
{
    using UnityEngine;

    public class VRTK_ControllerPointerEvents_ListenerExample : MonoBehaviour
    {
        public HighlightTarget highlightTarget;
        public bool showHoverState = false;
        private bool triggerPressed = false;
        public bool fllow = false;
        public GameObject target;

        private void Start()
        {
            if (GetComponent<VRTK_DestinationMarker>() == null)
            {
                VRTK_Logger.Error(VRTK_Logger.GetCommonMessage(VRTK_Logger.CommonMessageKeys.REQUIRED_COMPONENT_MISSING_FROM_GAMEOBJECT, "VRTK_ControllerPointerEvents_ListenerExample", "VRTK_DestinationMarker", "the Controller Alias"));
                return;
            }
            GetComponent<VRTK_ControllerEvents>().TriggerPressed += new ControllerInteractionEventHandler(DoTriggerPressed);
            GetComponent<VRTK_ControllerEvents>().TriggerReleased += new ControllerInteractionEventHandler(TriggerReleased);
            //Setup controller event listeners
            GetComponent<VRTK_DestinationMarker>().DestinationMarkerEnter += new DestinationMarkerEventHandler(DoPointerIn);
            if (showHoverState)
            {
                GetComponent<VRTK_DestinationMarker>().DestinationMarkerHover += new DestinationMarkerEventHandler(DoPointerHover);
            }
            GetComponent<VRTK_DestinationMarker>().DestinationMarkerExit += new DestinationMarkerEventHandler(DoPointerOut);
            GetComponent<VRTK_DestinationMarker>().DestinationMarkerSet += new DestinationMarkerEventHandler(DoPointerDestinationSet);
        }
        private void DoTriggerPressed(object sender, ControllerInteractionEventArgs e)
        {
            triggerPressed = true;
            
        }
        private void TriggerReleased(object sender, ControllerInteractionEventArgs e)
        {
            triggerPressed = false;
           
        }
        private void DebugLogger(uint index, string action, Transform target, RaycastHit raycastHit, float distance, Vector3 tipPosition)
        {
            string targetName = (target ? target.name : "<NO VALID TARGET>");
            string colliderName = (raycastHit.collider ? raycastHit.collider.name : "<NO VALID COLLIDER>");
           // VRTK_Logger.Info("Controller on index '" + index + "' is " + action + " at a distance of " + distance + " on object named [" + targetName + "] on the collider named [" + colliderName + "] - the pointer tip position is/was: " + tipPosition);
        }

        private void DoPointerIn(object sender, DestinationMarkerEventArgs e)
        {
            target = e.target.gameObject;
            highlightTarget.SetHighlightMaterial(e.target);
            DebugLogger(VRTK_ControllerReference.GetRealIndex(e.controllerReference), "POINTER IN", e.target, e.raycastHit, e.distance, e.destinationPosition);
        }

        private void DoPointerOut(object sender, DestinationMarkerEventArgs e)
        {
            target = null;
            highlightTarget.SetInitailMaterial(e.target);
            DebugLogger(VRTK_ControllerReference.GetRealIndex(e.controllerReference), "POINTER OUT", e.target, e.raycastHit, e.distance, e.destinationPosition);
        }

        private void DoPointerHover(object sender, DestinationMarkerEventArgs e)
        {
            if(triggerPressed)
            {
                fllow = true;
                
            }
            if(!triggerPressed)
            {
                fllow = false;
                target = null;
            }
            DebugLogger(VRTK_ControllerReference.GetRealIndex(e.controllerReference), "POINTER HOVER", e.target, e.raycastHit, e.distance, e.destinationPosition);
        }

        private void DoPointerDestinationSet(object sender, DestinationMarkerEventArgs e)
        {
            DebugLogger(VRTK_ControllerReference.GetRealIndex(e.controllerReference), "POINTER DESTINATION", e.target, e.raycastHit, e.distance, e.destinationPosition);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.XR;

namespace Colossal.Patches {
    public class ControllerPatch : MonoBehaviour {
        public static bool isRightControllerGripping;
        public static bool isRightControllerTrigger;
        public static bool isRightControllerSecondary;
        public static bool isRightControllerPrimary;
        public static bool isLeftControllerGripping;
        public static bool isLeftControllerTrigger;
        public static bool isLeftControllerSecondary;
        public static bool isLeftControllerPrimary;
        public static bool isLeftControllerPrimaryAxisClick;
        public static Vector2 LeftControllerPrimaryAxis;
        private static InputDevice leftController;
        private static InputDevice rightController;

        public static bool isHoldingRightGrip;
        public static bool isHoldingLeftGrip;
        public static bool isHoldingRightTrigger;
        public static bool isHoldingLeftTrigger;
        public static bool isHoldingRightPrimary;
        public static bool isHoldingRightSecondary;
        public static bool isHoldingLeftPrimary;
        public static bool isHoldingLeftSecondary;

        public static void sharedUpdate() {
            if (!leftController.isValid) {
                leftController = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);
            }
            if (!rightController.isValid) {
                rightController = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
            }
            try {
                leftController.TryGetFeatureValue(CommonUsages.primary2DAxisClick,
                    out isLeftControllerPrimaryAxisClick);
                leftController.TryGetFeatureValue(CommonUsages.primary2DAxis, out LeftControllerPrimaryAxis);
                leftController.TryGetFeatureValue(CommonUsages.gripButton, out isLeftControllerGripping);
                leftController.TryGetFeatureValue(CommonUsages.triggerButton, out isLeftControllerTrigger);
                leftController.TryGetFeatureValue(CommonUsages.secondaryButton, out isLeftControllerSecondary);
                leftController.TryGetFeatureValue(CommonUsages.primaryButton, out isLeftControllerPrimary);
                isHoldingLeftGrip = isLeftControllerGripping;
                isHoldingLeftPrimary = isLeftControllerPrimary;
                isHoldingLeftSecondary = isLeftControllerSecondary;
                isHoldingLeftTrigger = isLeftControllerTrigger;
            } catch (Exception) {
            }
            try {
                rightController.TryGetFeatureValue(CommonUsages.gripButton, out isRightControllerGripping);
                rightController.TryGetFeatureValue(CommonUsages.triggerButton, out isRightControllerTrigger);
                rightController.TryGetFeatureValue(CommonUsages.secondaryButton, out isRightControllerSecondary);
                rightController.TryGetFeatureValue(CommonUsages.primaryButton, out isRightControllerPrimary);
                isHoldingRightGrip = isRightControllerGripping;
                isHoldingRightPrimary = isRightControllerPrimary;
                isHoldingRightSecondary = isRightControllerSecondary;
                isHoldingRightTrigger = isRightControllerTrigger;
            } catch (Exception) {
            }
        }
    }
}

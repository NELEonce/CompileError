using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace DontStop.Player.Editor
{
    [CustomEditor(typeof(FPCharacterController))]
    public sealed class FPCharacterControllerEditor : UnityEditor.Editor
    {
        private SerializedProperty slopeLimit;
        private SerializedProperty stepOffset;
        private SerializedProperty characterHeight;
        private SerializedProperty characterShoulderWidth;
        private SerializedProperty characterWeight;
        private SerializedProperty crouchingHeight;
        private SerializedProperty slidingHeight;
        private SerializedProperty crouchingSpeed;
        private SerializedProperty runMode;
        private SerializedProperty allowedCollider;
        private SerializedProperty airControlPercent;
        private SerializedProperty walkingForce;
        private SerializedProperty crouchForce;
        private SerializedProperty runMultiplier;
        private SerializedProperty autoSprint;
        private SerializedProperty jumpForce;
        private SerializedProperty gravityMultiplier;
        private SerializedProperty FPSCamera;

        #region CAMERA CONTROLLER

        private SerializedProperty cameraController;
        
        #endregion

        private SerializedProperty wallRunEnableSpeed;
        private SerializedProperty wallRunAngle;
        private SerializedProperty wallJumpMultiplier;
        private SerializedProperty cameraAnimator;
        private SerializedProperty climbingSpeed;
        private SerializedProperty slidingControlPercent;
        private SerializedProperty slidingEndLine;
        private SerializedProperty thrustMaxLimit;
        private SerializedProperty slidingDrag;
        private SerializedProperty slidingAngle;
        private SerializedProperty frictionAngle;
        private SerializedProperty thrustMultiplier;
        private SerializedProperty slidingRecastTime;

        private void OnEnable()
        {
            // SerializedPropertiesの設定
            slopeLimit = serializedObject.FindProperty("slopeLimit");
            stepOffset = serializedObject.FindProperty("stepOffset");
            characterHeight = serializedObject.FindProperty("characterHeight");
            characterShoulderWidth = serializedObject.FindProperty("characterShoulderWidth");
            characterWeight = serializedObject.FindProperty("characterWeight");
            crouchingHeight = serializedObject.FindProperty("crouchingHeight");
            slidingHeight = serializedObject.FindProperty("slidingHeight");
            crouchingSpeed = serializedObject.FindProperty("crouchingSpeed");
            runMode = serializedObject.FindProperty("runMode");
            allowedCollider = serializedObject.FindProperty("allowedCollider");
            airControlPercent = serializedObject.FindProperty("airControlPercent");
            walkingForce = serializedObject.FindProperty("walkingForce");
            crouchForce = serializedObject.FindProperty("crouchForce");
            runMultiplier = serializedObject.FindProperty("runMultiplier");
            autoSprint = serializedObject.FindProperty("autoSprint");
            jumpForce = serializedObject.FindProperty("jumpForce");
            gravityMultiplier = serializedObject.FindProperty("gravityMultiplier");
            FPSCamera = serializedObject.FindProperty("FPSCamera");

            //#region CAMERA CONTROLLER

            //private SerializedProperty cameraController;

            //#endregion

            wallRunEnableSpeed = serializedObject.FindProperty("wallRunEnableSpeed");
            wallRunAngle = serializedObject.FindProperty("wallRunAngle");
            wallJumpMultiplier = serializedObject.FindProperty("wallJumpMultiplier");
            cameraAnimator = serializedObject.FindProperty("cameraAnimator");
            climbingSpeed = serializedObject.FindProperty("climbingSpeed");
            slidingControlPercent = serializedObject.FindProperty("slidingControlPercent");
            slidingEndLine = serializedObject.FindProperty("slidingEndLine");
            thrustMaxLimit = serializedObject.FindProperty("thrustMaxLimit");
            slidingDrag = serializedObject.FindProperty("slidingDrag");
            slidingAngle = serializedObject.FindProperty("slidingAngle");
            frictionAngle = serializedObject.FindProperty("frictionAngle");
            thrustMultiplier = serializedObject.FindProperty("thrustMultiplier");
            slidingRecastTime = serializedObject.FindProperty("slidingRecastTime");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            
            //　デフォルトのインスペクタを表示
            DrawDefaultInspector();
            
            serializedObject.ApplyModifiedProperties();
        }
    }
}

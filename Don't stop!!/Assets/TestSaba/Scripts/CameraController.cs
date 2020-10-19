using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doozy.Engine.Attributes;

public class CameraController
{
    [SerializeField]
    [MinMaxRange(-90f, 90f)]
    [Tooltip("ｶﾒﾗの最大最小角度")]
    private Vector2 pitchLimit = new Vector2(-75f, 80);

    private Transform characterReference;
    private Transform cameraReference;

    private Quaternion characterTargetRot;
    private Quaternion cameraTargetRot;

    private float minPitch;
    private float maxPitch;

    /// <summary>
    /// ｷｬﾗｸﾀｰの初期rotationで初期化する
    /// </summary>
    /// <param name="character">操作ｷｬﾗのtransform</param>
    /// <param name="camera">ｶﾒﾗのtransform</param>
    public void Init(Transform character, Transform camera)
    {
        characterReference = character;
        cameraReference = camera;

        characterTargetRot = character.localRotation;
        cameraTargetRot = camera.localRotation;

        minPitch = pitchLimit.x;
        maxPitch = pitchLimit.y;
    }

    /// <summary>
    /// ｷｬﾗｸﾀｰを強制的に指定した位置に向かせる
    /// </summary>
    public void LookAt(Vector3 position)
    {
        Vector3 characterDirection = position - characterReference.position;
        characterDirection.y = 0;

        // Forces the character to look at the target position.
        characterTargetRot = Quaternion.Slerp(characterTargetRot, Quaternion.LookRotation(characterDirection), 10 * Time.deltaTime);
        characterReference.localRotation = Quaternion.Slerp(characterReference.localRotation, characterTargetRot, 10 * Time.deltaTime);
    }
}

using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : CinemachineExtension
{
    [Tooltip("Lock the camera's X position to this value")]
    [SerializeField] private float m_YPosition = 0;
    [SerializeField] private float min_XPosition = 0;
    [SerializeField] private float max_XPosition;

    protected override void PostPipelineStageCallback(
        CinemachineVirtualCameraBase vcam,
        CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        if (stage == CinemachineCore.Stage.Body)
        {
            var pos = state.RawPosition;
            pos.y = m_YPosition;
            state.RawPosition = pos;

            if (pos.x < 0)
                pos.x = min_XPosition;
            else if (pos.x >= max_XPosition)
                pos.x = max_XPosition;
            state.RawPosition = pos;
        }
    }
}

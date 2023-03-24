using UnityEngine;
using Cinemachine;

public class CameraMover : MonoBehaviour
{
    public static CameraMover Instance { get; private set; }

    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    [SerializeField] private CinemachineConfiner confiner;

    private void Awake()
    {
        Instance = this;
    }

    public void MoveCamera(Vector3 delta)
    {
        Vector3 newPos = virtualCamera.transform.position + delta;
        virtualCamera.transform.position = ClampPosition(newPos);
    }

    private Vector3 ClampPosition(Vector3 position)
    {
        if (confiner.m_BoundingShape2D == null) return position;

        Collider2D confinerCollider = confiner.m_BoundingShape2D as Collider2D;
        Bounds confinerBounds = confinerCollider.bounds;

        float halfOrthographicSize = virtualCamera.m_Lens.OrthographicSize * 0.5f;
        float aspectRatio = virtualCamera.m_Lens.Aspect;
        float halfWidth = halfOrthographicSize * aspectRatio;

        float minX = confinerBounds.min.x + halfWidth;
        float maxX = confinerBounds.max.x - halfWidth;
        float minY = confinerBounds.min.y + halfOrthographicSize;
        float maxY = confinerBounds.max.y - halfOrthographicSize;

        float clampedX = Mathf.Clamp(position.x, minX, maxX);
        float clampedY = Mathf.Clamp(position.y, minY, maxY);

        return new Vector3(clampedX, clampedY, position.z);
    }
}
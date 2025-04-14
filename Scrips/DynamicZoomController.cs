using UnityEngine;
using Cinemachine;
using System.Collections;

public class DynamicZoomController : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;  // Cinemachine 相机
    public float zoomOutSize = 17f;  // 中央的缩放大小 (远景)
    public float zoomInSize = 10f;   // 边缘的缩放大小 (近景)
    public float zoomSpeed = 2f;     // 缩放速度
    public float centralRegionWidth = 100f;  // 中央区域的宽度
    public PolygonCollider2D cameraBoundary; // 相机的边界 Collider
    private GameObject player;       // 玩家对象

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");  // 找到玩家对象
    }

    void Update()
    {
        // 获取玩家在 X 轴的位置
        float playerX = player.transform.position.x;

        // 计算相机的目标大小，基于玩家的位置
        float targetSize = CalculateTargetZoom(playerX);

        // 获取当前相机的 OrthographicSize
        float currentSize = virtualCamera.m_Lens.OrthographicSize;

        // 渐进式调整相机缩放
        virtualCamera.m_Lens.OrthographicSize = Mathf.Lerp(currentSize, targetSize, Time.deltaTime * zoomSpeed);
    }

    // 根据玩家在场景中的 X 轴位置动态调整相机的缩放大小
    float CalculateTargetZoom(float playerX)
    {

        float boundaryleft = cameraBoundary.bounds.min.x;
        float boundaryright = cameraBoundary.bounds.max.x;
        // 如果玩家在中央区域（场景中部），使用远景
        float sceneCenter = (boundaryleft + boundaryright) / 2;
        float centralLeft = sceneCenter - centralRegionWidth / 2;
        float centralRight = sceneCenter + centralRegionWidth / 2;

        if (playerX > centralLeft && playerX < centralRight)
        {
            // 玩家在中央区域，使用远景
            return zoomOutSize;
        }
        else
        {
            // 玩家在边缘区域，使用近景
            return zoomInSize;
        }
    }

    public float shakeDuration = 0.5f;
    public float shakeMagnitude = 0.1f;

    private Vector3 originalPosition;

    void OnEnable()
    {
        originalPosition = transform.localPosition;
    }


    
}

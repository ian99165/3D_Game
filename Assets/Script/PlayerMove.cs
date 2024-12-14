using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float runSpeed = 8f;
    private CharacterController controller;

    [Header("Camera Settings")]
    public Camera mainCamera;  // 主相機
    public float rotationSpeed = 200f;  // 角色旋轉速度
    private bool isRunning = false;

    // Gravity Settings
    private Vector3 velocity;  // 角色速度
    private float gravity = -9.81f;  // 重力加速度
    private bool isGrounded;  // 是否在地面

    // 相機跟隨的偏移
    public float cameraHeight = 2f;  // 相機的高度
    public float cameraDistance = 4f;  // 相機的距離

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Move();
        ApplyGravity();
    }

    private void Move()
    {
        // 使用WASD（垂直和水平方向）控制角色的移動
        float horizontal = Input.GetAxis("Horizontal"); // A/D 或 左/右箭頭
        float vertical = Input.GetAxis("Vertical");     // W/S 或 上/下箭頭

        // 根據角色的朝向來計算移動方向
        Vector3 moveDirection = transform.right * horizontal + transform.forward * vertical;

        if (moveDirection.magnitude > 0)
        {
            // 根據移動方向來旋轉角色
            Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

        // 計算移動速度，根據是否跑步來調整速度
        float currentSpeed = isRunning ? runSpeed : moveSpeed;

        // 執行角色的移動
        controller.Move(moveDirection * currentSpeed * Time.deltaTime);

        // 更新相機的位置以保持在角色的背後
        RotateCamera();
    }

    private void RotateCamera()
    {
        if (mainCamera != null)
        {
            // 計算角色的背後位置
            Vector3 behindPosition = transform.position - transform.forward * cameraDistance + Vector3.up * cameraHeight;

            // 更新相機位置，使其跟隨角色的背後
            mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, behindPosition, Time.deltaTime * 5f);

            // 讓相機始終看向角色
            mainCamera.transform.LookAt(transform.position);
        }
    }

    private void ApplyGravity()
    {
        isGrounded = controller.isGrounded;

        // 如果角色在地面且向下的速度小於0，則保持角色貼地
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // 計算重力加速度
        velocity.y += gravity * Time.deltaTime;

        // 應用重力
        controller.Move(velocity * Time.deltaTime);
    }

    // 按下 Shift 鍵時啟動跑步，放開時恢復走路速度
    private void LateUpdate()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }
    }
}

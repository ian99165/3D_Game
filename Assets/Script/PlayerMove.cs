using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    private CharacterController controller;

    [Header("Rotation Settings")]
    public float rotationSpeed = 200f; // 角色旋轉速度

    // Gravity Settings
    private Vector3 velocity;  // 角色速度
    private float gravity = -9.81f;  // 重力加速度
    private bool isGrounded;  // 是否在地面

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        MoveAndRotate();
        ApplyGravity();
    }

    private void MoveAndRotate()
    {
        // 使用WASD（垂直和水平方向）控制角色的移動
        float horizontal = Input.GetAxis("Horizontal"); // A/D 或 左/右箭頭
        float vertical = Input.GetAxis("Vertical");     // W/S 或 上/下箭頭

        // 根據輸入計算世界座標系的移動方向
        Vector3 moveDirection = new Vector3(horizontal, 0, vertical);

        // 如果有輸入，設定角色朝向移動方向
        if (moveDirection.magnitude > 0)
        {
            // 計算角色應該面向的方向
            Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

        // 執行角色的移動
        controller.Move(moveDirection * moveSpeed * Time.deltaTime);
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
}
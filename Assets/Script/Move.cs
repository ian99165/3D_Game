using UnityEngine;

public class Move : MonoBehaviour
{
    public float walkSpeed = 3f;  // 走路速度
    public float runSpeed = 6f;   // 跑步速度
    public float turnSpeed = 10f; // 旋轉速度

    private float currentSpeed;   // 當前速度
    private Vector3 moveDirection; // 移動方向
    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>(); // 取得角色控制器
    }

    void Update()
    {
        // 取得水平方向與垂直方向的輸入（WASD或箭頭鍵）
        float moveDirectionX = Input.GetAxis("Horizontal"); // A/D 或 左/右鍵
        float moveDirectionZ = Input.GetAxis("Vertical");   // W/S 或 上/下鍵

        // 計算移動方向
        moveDirection = new Vector3(moveDirectionX, 0, moveDirectionZ).normalized;

        // 根據是否按下 Shift 鍵來決定走路或跑步速度
        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = runSpeed; // 跑步
        }
        else
        {
            currentSpeed = walkSpeed; // 走路
        }

        // 移動角色
        controller.Move(moveDirection * currentSpeed * Time.deltaTime);

        // 角色轉向移動的方向
        if (moveDirection.magnitude > 0.1f)
        {
            float targetAngle = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSpeed, 0.1f);
            transform.rotation = Quaternion.Euler(0, angle, 0);
        }
    }
}
using UnityEngine;
using UnityEngine.InputSystem;

public class Shooter : MonoBehaviour
{
    public GameObject prefab;       //발사할 게임오브젝트 프리팹
    [Range(0.1f, 5f)]
    public float delay = 0.5f;      //발사 딜레이
    public float power = 500f;      //발사 파워

    private bool isPressed = false; //방아쇠 당기고 있는지 여부
    private float nextShootTime;    //다음 총알 발사 시간

    //Pick액션이 발동될 때 호출되는 콜백함수
    public void OnPick(InputValue value)
    {
        isPressed = value.isPressed;
    }

    private void Update()
    {
        //왼쪽 마우스 버튼이 눌러져 있으며, 다음 총알 발사할 수 있는 시간일 때,
        if (isPressed && nextShootTime < Time.time)
        {
            //다음 발사 시간을 갱신시키고
            nextShootTime = Time.time + delay;
            //총알 생성
            GameObject bullet = Instantiate<GameObject>(prefab, transform.position, transform.rotation);
            //총알에 물리력 적용
            bullet.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * power);
        }
    }

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}

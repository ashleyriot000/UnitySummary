using Unity.Cinemachine;
using UnityEngine;

public class CinemachineRotator : MonoBehaviour
{
    //회전 속도
    public float rotateSpeed = 1f;
    //카메라가 타겟을 중심으로 공전하게 만들어주는 컴포넌트
    private CinemachineOrbitalFollow follow;

    void Start()
    {
        follow = GetComponent<CinemachineOrbitalFollow>();
    }

    void Update()
    {
        //수평이동 값을 지속적으로 갱신시켜 회전하도록 한다.
        follow.HorizontalAxis.Value = follow.HorizontalAxis.Value + rotateSpeed * Time.deltaTime;
    }
}

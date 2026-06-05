using UnityEngine;
using UnityEngine.UI;

public class LifeUI : MonoBehaviour
{
    public Slider lifeSlider;       //슬라이더
    public Text lifeText;           //텍스트
    public Vector3 offset;          //위치 보정 

    public Transform target;        //따라다닐 게임오브젝트 위치정보
    public Transform camTransform;  //쳐다봐야할 카메라 위치정보


    private void Start()
    {
        //씬 안에 WorldCanvas라고 되어 있는 게임오브젝트를 찾는 함수.
        GameObject go = GameObject.Find("WorldCanvas");
        //게임오브젝트의 부모를 설정하는 함수
        transform.SetParent(go.transform);

        GameObject cam = GameObject.Find("Main Camera");
        camTransform = cam.transform;
    }


    private void LateUpdate()
    {
        if (camTransform == null)
            return;

        //타겟의 위치로 변경하고 카메라의 정면 방향으로 회전시킴.
        transform.SetPositionAndRotation(target.position + offset, camTransform.rotation);
    }

    //라이프수치가 변경될 때 호출해서 UI 반영
    public void ChangeValue(float value, int life)
    {
        lifeSlider.value = value;
        lifeText.text = life.ToString();
    }

}

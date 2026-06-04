using UnityEngine;
using UnityEngine.EventSystems;

public class MaterialChanger : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public MeshRenderer meshRenderer;       //게임오브젝트의 메쉬를 그리는 컴포넌트
    public Material material;               //바꾸고 싶은 메터리얼
    public Color enterColor;                //포인터로 가리키고 있을 때 바꾸고 싶은 색
    public float offsetSpeed = 1f;          //메터리얼의 offset 속도

    private Color defaultColor;             //처음 색
    private bool isSelected;                //선택되어 있는지 여부
    private float currentOffset;            //현재 offset

    //게임오브젝트가 활성화되는 처음에 한번만 호출.
    void Start()
    {
        //게임오브젝트 안에 있는 메쉬렌더러를 찾아서 변수에 넣어라.
        meshRenderer = GetComponent<MeshRenderer>();
        //렌더러 안의 메터리얼 변수를 찾아서 내가 원하는 매터리얼로 변경.
        meshRenderer.material = material;
        //처음부터 가지고 있는 색을 저장해놓기
        defaultColor = meshRenderer.material.color;
    }

    private void Update()
    {
        //초당 스피드에 맞게 Offset위치 계산.
        currentOffset = currentOffset + offsetSpeed * Time.deltaTime;
        //메터리얼의 Offset에 적용.
        meshRenderer.material.mainTextureOffset = new Vector2(currentOffset, 0f);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        isSelected = !isSelected;
        if(isSelected == true)
        {
            meshRenderer.material.EnableKeyword("_EMISSION");
        }
        else
        {
            meshRenderer.material.DisableKeyword("_EMISSION");
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //렌더러 안에 있는 매터리얼의 컬러변수를 바꾸면 그려지는 색이 변경됨.
        meshRenderer.material.color = enterColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        meshRenderer.material.color = defaultColor;
    }
}

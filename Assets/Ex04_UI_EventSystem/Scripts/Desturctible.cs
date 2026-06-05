using UnityEngine;
using UnityEngine.EventSystems;

public class Destructible : MonoBehaviour, IPointerClickHandler
{
    public int maxLife = 100;
    public int damage = 30;
    public LifeUI ui;

    private int currentLife;

    private void Awake()
    {
        currentLife = maxLife;
        ui.ChangeValue(1f, currentLife);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //Mathf.Clamp(계산 결과, 최소값,  최대값) => 계산 결과가 최소값과 최대값 사이의 숫자로만 반환함.
        currentLife = Mathf.Clamp(currentLife - damage, 0, maxLife);
        //변경된 라이프 값을 UI에 반영
        ui.ChangeValue((float)currentLife / maxLife, currentLife);

        //라이프가 0이 되면 스스로 파괴
        if (currentLife == 0)
        {
            Destroy(gameObject);
            Destroy(ui.gameObject);
        }
    }
}

using UnityEngine;

public class Counter : MonoBehaviour
{
    public int count = 0;       //영역에 들어온 오브젝트 갯수 
    public bool destructible;   //파괴할 수 있는지 여부

    private void OnTriggerEnter(Collider other)
    {
        //영역에 들어올 때마다 카운트 1씩 증가.
        count++;
    }

    private void OnTriggerExit(Collider other)
    {
        if(destructible)
        {
            //Destroy 함수 => 사라지게 하고 싶은 게임오브젝트 넣어주면 파괴됨.
            Destroy(other.gameObject);
        }
    }
}

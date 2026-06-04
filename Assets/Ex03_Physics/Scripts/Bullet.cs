using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifeTime = 10f;        //살아있는 시간
    private float deadTime;             //죽어야 되는 시간.

    void Start()
    {
        //태어나자마자 죽어야 되는 시간 계산해서 저장.
        deadTime = Time.time + lifeTime;
    }

    // Update is called once per frame
    void Update()
    {
        //죽어야 되는 시간이 지났는지 확인하고 지났으면 스스로 파괴.
        if (deadTime < Time.time)
            Destroy(gameObject);
    }
}

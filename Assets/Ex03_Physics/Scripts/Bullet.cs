using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject effect;           //충돌시 생성하고 싶은 파티클
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

    //충돌시 콜백되는 함수
    private void OnCollisionEnter(Collision collision)
    {
        Instantiate<GameObject>(effect, collision.contacts[0].point,
            Quaternion.LookRotation(collision.contacts[0].normal));

        Destroy(gameObject);
    }
}

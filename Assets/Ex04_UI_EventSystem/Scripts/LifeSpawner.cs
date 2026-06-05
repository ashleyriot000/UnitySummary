using UnityEngine;

public class LifeSpawner : MonoBehaviour
{
    public GameObject[] prefabs;

    public float spawnDelay = 4f;

    private float nextSpawnTime;


    void Update()
    {
        //다음 스폰 시간이 현재 시간보다 작으면
        if(nextSpawnTime < Time.time)
        {
            //다음 스폰 시간 갱신시키고
            nextSpawnTime = Time.time + spawnDelay;
            //프리팹 동적 생성
            GameObject go = Instantiate(prefabs[Random.Range(0, prefabs.Length)]);
            //위치 결정을 랜덤으로 뽑는다.
            float distance = Random.Range(3f, 9f);
            float height = Random.Range(1f, 5f);
            float angle = Random.Range(0f, 360f);
            //랜덤으로 뽑힌 위치를 적용.
            go.transform.
                SetPositionAndRotation(
                Quaternion.Euler(0f, angle, 0f) * Vector3.forward * distance + Vector3.up * height,
                Quaternion.identity);
        }
    }
}

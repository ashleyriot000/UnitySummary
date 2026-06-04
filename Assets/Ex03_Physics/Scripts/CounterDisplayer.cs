using UnityEngine;
using UnityEngine.UI;

public class CounterDisplayer : MonoBehaviour
{
    public Text text;                   //UI에서 텍스트 표시하는 변수
    public Counter spawnCounter;        //생성 갯수
    public Counter normalCounter;       //정상 갯수
    public Counter errorCount;          //불량 갯수

    void Update()
    {
        text.text = 
            $"생성수 : {spawnCounter.count}개, " +
            $"불량률({(float)errorCount.count / spawnCounter.count:P2})" +
            $"\r\n정상 : {normalCounter.count}개" +
            $"\r\n불량 : {errorCount.count}개";
    }
}

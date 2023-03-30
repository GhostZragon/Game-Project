using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    public List<GameObject> DropList;
    //public GameObject coin;
    [SerializeField] Transform spawnPos;
    //public GameObject apple;
    //int monsterKilled = 0;
    [SerializeField] float disappearTime = 2f;
    //2.86 to 6.8
    //-1.6 to -0.1
    private void Awake()
    {
        spawnPos = GameObject.Find("EnemySpawnPos").GetComponent<Transform>();
        
    }

    public void Drop(int cointCount)
    {
        DropCoin(cointCount);
        DropApple();
        DropStone();
    }

    void DropCoin(int coinCount)
    {
        for (int i = 0; i < coinCount; i++)
        {
            // set up postision
            float a = Random.Range(1.67f, 7.8f);
            float b = Random.Range(-1.6f, 0.3f);
            //
            var go = Instantiate(DropList[0], spawnPos.position, Quaternion.identity,transform);

            go.transform.position = new Vector3(a, b, 0);
            go.SetActive(true);

            Destroy(go, disappearTime);
        }
    }


    void DropApple()
    {
        var go = Instantiate(DropList[1], spawnPos.position,Quaternion.identity, transform);
        go.SetActive(true);
        Destroy(go, disappearTime);
    }

    void DropStone()
    {
        float a = Random.Range(1.67f, 7.8f);
        var go = Instantiate(DropList[2], spawnPos.position, Quaternion.identity, transform);
        go.transform.position = new Vector3(a, go.transform.position.y, go.transform.position.z);
        go.SetActive(true);
        Destroy(go, disappearTime);
    }

}

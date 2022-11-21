using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreater : MonoBehaviour
{
    GameManager gm;
    public GameObject Enemy;
    public int createPoint;

    public Vector3 bgpos;
    public Vector3 createpos;   

    public IEnumerator EnemyCreate()
    {
        while (true)
        {
            Debug.Log("EnemyCreate");
            createPoint = Random.Range(0, 9);

            while (createPoint == 4)
            {
                createPoint = Random.Range(0, 9);
            }

            bgpos = gm.bg.BgObjList[createPoint].transform.position - new Vector3(7.5f, 7.5f, 0);
            createpos = new Vector3(Random.Range(bgpos.x, bgpos.x + 15f), Random.Range(bgpos.y, bgpos.y + 15f), 0);

            GameObject e = Instantiate(Enemy);
            e.transform.position = createpos;

            yield return new WaitForSeconds(0.5f);
        }
    }


    void Start()
    {
        gm = GameManager.GetInstance();
        gm.ec = this;
        Enemy = Resources.Load<GameObject>("Prefabs/Enemy/Enemy1");
        StartCoroutine(EnemyCreate());
    }

    void Update()
    {
        
    }
}

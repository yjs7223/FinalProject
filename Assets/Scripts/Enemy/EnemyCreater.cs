using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreater : MonoBehaviour
{
    GameManager gm;
    public GameObject Enemy;
    public List<GameObject> enemyList;
    public int createPoint;
    public bool isFullEnemy;

    public Vector3 bgpos;
    public Vector3 createpos;   

    public IEnumerator EnemyCreate()
    {
        while (true)
        {
            if(isFullEnemy)
            {
                yield return new WaitUntil(() => enemyList.Count < 30);
            }

            Debug.Log("EnemyCreate");
            createPoint = Random.Range(0, 9);

            while (createPoint == 4)
            {
                createPoint = Random.Range(0, 9);
            }

            bgpos = gm.bg.BgObjList[createPoint].transform.position - new Vector3(7.5f, 7.5f, 0);
            createpos = new Vector3(Random.Range(bgpos.x, bgpos.x + 15f), Random.Range(bgpos.y, bgpos.y + 15f), 0);

            enemyList.Add(Instantiate(Enemy));
            enemyList[enemyList.Count - 1].GetComponent<Enemy>().enemynum = enemyList.Count - 1;
            enemyList[enemyList.Count - 1].transform.position = createpos;
            if(enemyList.Count > 40)
            {
                isFullEnemy = true;
            }
            yield return new WaitForSeconds(0.5f);
        }
    }


    void Start()
    {
        gm = GameManager.GetInstance();
        gm.ec = this;
        Enemy = Resources.Load<GameObject>("Prefabs/Enemy/Enemy1");
        isFullEnemy = false;
        StartCoroutine(EnemyCreate());
    }

    void Update()
    {
        
    }
}

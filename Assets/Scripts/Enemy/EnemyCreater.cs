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

    /// <summary>
    /// 적 생성기
    /// </summary>
    /// <returns></returns>
    public IEnumerator EnemyCreate()
    {
        while (true)
        {
            //isFullEnemy가 true가 되면 개체수가 30이 될때 까지 멈춤
            if (isFullEnemy)
            {
                yield return new WaitUntil(() => enemyList.Count < 30);
            }

            //생성위치 지정
            Debug.Log("EnemyCreate");
            createPoint = Random.Range(0, 9);

            //중앙에는 생성하지 않음
            while (createPoint == 4)
            {
                createPoint = Random.Range(0, 9);
            }

            //생성위치 시작값 설정
            bgpos = gm.bg.BgObjList[createPoint].transform.position - new Vector3(7.5f, 7.5f, 0);
            //생성위치 설정
            createpos = new Vector3(Random.Range(bgpos.x, bgpos.x + 15f), Random.Range(bgpos.y, bgpos.y + 15f), 0);

            //인스턴스 생성
            enemyList.Add(Instantiate(Enemy));
            //리스트 인덱스를 각 개체에 전달
            enemyList[enemyList.Count - 1].GetComponent<Enemy>().enemynum = enemyList.Count - 1;
            //생성위치로 이동
            enemyList[enemyList.Count - 1].transform.position = createpos;
            //40이상 생성되면 isFullEnemy를 true
            if (enemyList.Count > 40)
            {
                isFullEnemy = true;
            }
            yield return new WaitForSeconds(2f);
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

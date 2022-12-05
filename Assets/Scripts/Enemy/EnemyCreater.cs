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
    public float createDelay;

    public Vector3 bgpos;
    public Vector3 createpos;   

    /// <summary>
    /// �� ������
    /// </summary>
    /// <returns></returns>
    public IEnumerator EnemyCreate()
    {
        while (true)
        {
            //isFullEnemy�� true�� �Ǹ� ��ü���� 30�� �ɶ� ���� ����
            if (isFullEnemy)
            {
                yield return new WaitUntil(() => enemyList.Count < 30 + gm.player.level * 2);
            }

            //������ġ ����
            Debug.Log("EnemyCreate");
            createPoint = Random.Range(0, 9);

            //�߾ӿ��� �������� ����
            while (createPoint == 4)
            {
                createPoint = Random.Range(0, 9);
            }

            //������ġ ���۰� ����
            bgpos = gm.bg.BgObjList[createPoint].transform.position - new Vector3(7.5f, 7.5f, 0);
            //������ġ ����
            createpos = new Vector3(Random.Range(bgpos.x, bgpos.x + 15f), Random.Range(bgpos.y, bgpos.y + 15f), 0);

            //�ν��Ͻ� ����
            enemyList.Add(Instantiate(Enemy));
            //����Ʈ �ε����� �� ��ü�� ����
            enemyList[enemyList.Count - 1].GetComponent<Enemy>().enemynum = enemyList.Count - 1;
            //������ġ�� �̵�
            enemyList[enemyList.Count - 1].transform.position = createpos;
            //ü�¼���
            enemyList[enemyList.Count - 1].GetComponent<Enemy>().hp = 10 + gm.player.level * 5; 
            //40�̻� �����Ǹ� isFullEnemy�� true
            if (enemyList.Count > 40 + gm.player.level * 2)
            {
                isFullEnemy = true;
            }
            yield return new WaitForSeconds(createDelay);
        }
    }

    public void EnemyWave()
    {
        for(int i = 0; i < 15; i++)
        {
            createPoint = Random.Range(0, 9);

            //�߾ӿ��� �������� ����
            while (createPoint == 4)
            {
                createPoint = Random.Range(0, 9);
            }

            //������ġ ���۰� ����
            bgpos = gm.bg.BgObjList[createPoint].transform.position - new Vector3(7.5f, 7.5f, 0);
            //������ġ ����
            createpos = new Vector3(Random.Range(bgpos.x, bgpos.x + 15f), Random.Range(bgpos.y, bgpos.y + 15f), 0);

            //�ν��Ͻ� ����
            enemyList.Add(Instantiate(Enemy));
            //����Ʈ �ε����� �� ��ü�� ����
            enemyList[enemyList.Count - 1].GetComponent<Enemy>().enemynum = enemyList.Count - 1;
            //������ġ�� �̵�
            enemyList[enemyList.Count - 1].transform.position = createpos;
            //ü�¼���
            enemyList[enemyList.Count - 1].GetComponent<Enemy>().hp = 10 + gm.player.level * 5;
        }
    }


    void Start()
    {
        gm = GameManager.GetInstance();
        gm.ec = this;
        Enemy = Resources.Load<GameObject>("Prefabs/Enemy/Enemy1");
        isFullEnemy = false;
        createDelay = 3f;
        StartCoroutine(EnemyCreate());
    }

    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class FloorBullet : Bullet
{
    /// <summary>
    /// 장판 오브젝트
    /// </summary>
    public GameObject floor;

    public float fAtt;

    /// <summary>
    /// 베지어 곡선을 사용할 변수
    /// </summary>
    public float moveValue;
    /// <summary>
    /// 베지어 곡선을 사용할 점의 위치
    /// </summary>
    public Vector3 p1, p2, p3;

    public Easing.EasingFunction ef;

    public void SetPoint()
    {
        //시작위치(플레이어 위치)
        p1 = gm.player.transform.position;

        //2번째 점(플레이어 위치에서 좌우 위쪽 랜덤 지정)
        float randx = Random.Range(-2f, 2f);
        float randy = Random.Range(1f, 3f);
        p2 = new Vector3(p1.x + randx, p1.y + randy, 0);

        if (randx < 0)
        {
            randx = Random.Range(-0.1f, -2f);
        }
        else
        {
            randx = Random.Range(0.1f, 2f);
        }
        randy = Random.Range(0.2f, 4f);
        p3 = new Vector3(p2.x + randx, p2.y - randy, 0);
    }

    //베지어곡선으로 이동
    public override void BulletMove()
    {
        transform.position = BezierCurve(p1, p2, p3, moveValue);
        /*if(transform.position.sqrMagnitude >= p2.sqrMagnitude)
        {
            rb.MovePosition(transform.position + (p3 * speed * Time.deltaTime));
        }
        else
        {
            rb.MovePosition(transform.position + (p2 * speed * Time.deltaTime));
        }*/
        
        if (moveValue >= 1f)
        {
            GameObject f = Instantiate(floor);
            f.GetComponent<Floor>().floorAtt = fAtt;
            f.transform.position = transform.position;
            Destroy(gameObject);
        }

        if (ef == null)
        {
            ef = Easing.GetEasingFunction(Easing.EaseType.easeInOutSine);
        }
        else if(moveValue > 0.3f)
        {
            ef = Easing.GetEasingFunction(Easing.EaseType.easeInCubic);
        }
        moveValue += ef(0f, 1f, speed) * Time.deltaTime;
    }

    Vector3 BezierCurve(Vector3 p1, Vector3 p2, Vector3 p3, float value)
    {
        Vector3 v1 = Vector3.Lerp(p1, p2, value);
        Vector3 v2 = Vector3.Lerp(p2, p3, value);

        Vector3 v3 = Vector3.Lerp(v1, v2, value);

        return v3;
    }

    void Start()
    {
        gm = GameManager.GetInstance();
        btype = Weapon.WeaponType.Floor;


        if (rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
        }

        if(floor == null)
        {
            floor = Resources.Load<GameObject>("Prefabs/Bullet/Floor");
        }
        speed = 0.8f;
        moveValue = 0.01f;
        SetPoint();
    }

    void Update()
    {
        BulletMove();
    }
}

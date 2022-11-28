using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    GameManager gm;

    //경험치
    public float exp;
    //레벨
    public int level;

    public float hp;

    public float damageDelay;

    public List<Weapon> weapons = new List<Weapon>();

    //이동속도
    public float moveSpeed;
    //리지드바디
    private Rigidbody2D playerRigidbody;
    //Horizontal,Vertical 문자
    string horizontalAxisName = "Horizontal";
    string verticalAxisName = "Vertical";

    public void PlayerMove()
    {
        float hMove = Input.GetAxisRaw(horizontalAxisName);
        float vMove = Input.GetAxisRaw(verticalAxisName);

        Vector3 velosity = new Vector3(hMove, vMove, 0f).normalized * moveSpeed * Time.deltaTime;
        playerRigidbody.velocity = velosity;
    }

    public void PlayerAtt()
    {
        for(int i = 0; i < weapons.Count; i++)
        {
            weapons[i].Attack();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.GetInstance();
        playerRigidbody = GetComponent<Rigidbody2D>();
        moveSpeed = 400f;
        damageDelay = 1;
        exp = 0;
        level = 1;
        hp = 20;
        weapons.Add(Instantiate(Resources.Load<Weapon>("Prefabs/Weapon/FloorWeapon"),transform));
        weapons[0].transform.position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            damageDelay += Time.deltaTime;
            if (damageDelay > 1)
            {
                hp -= collision.GetComponent<Enemy>().att;
                damageDelay = 0;
                Debug.Log($"Damaged | Player HP : {hp}");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Exp")
        {
            Debug.Log("GetExp");
            exp += collision.GetComponent<ExpItem>().exp;
            if(exp >= 10)
            {
                Debug.Log("LevelUP");
                level++;
                exp = 0;
            }
            Destroy(collision.gameObject);
        }
    }
}

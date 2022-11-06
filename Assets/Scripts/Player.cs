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

    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.GetInstance();
        playerRigidbody = GetComponent<Rigidbody2D>();
        moveSpeed = 300f;
        exp = 0;
        level = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }
}

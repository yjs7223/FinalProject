using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //�̵��ӵ�
    public float moveSpeed;
    //������ٵ�
    private Rigidbody2D playerRigidbody;
    //Horizontal,Vertical ����
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
        playerRigidbody = GetComponent<Rigidbody2D>();
        moveSpeed = 300f;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }
}

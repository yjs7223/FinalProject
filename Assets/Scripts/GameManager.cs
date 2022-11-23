using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //�ܺο��� ����� ������ �Լ��� ���ӸŴ����� ���� ��� 
    public BackGround bg;
    public Player player;
    public EnemyCreater ec;
    public UIManager uim;
    //public Weapon weapon;
    //public Item item;

    /// <summary>
    /// ���� �ν��Ͻ��� ��������
    /// </summary>
    static GameManager instance;
    /// <summary>
    /// ���ӸŴ��� �ν��Ͻ��� �������� �Լ�
    /// </summary>
    /// <returns></returns>
    public static GameManager GetInstance() { Init(); return instance; }

    /// <summary>
    /// ���� �ν��Ͻ� �Ҵ�(������ ����x)
    /// </summary>
    static void Init()
    {
        if (instance == null)
        {
            GameObject go = GameObject.Find("GameManager");
            
            if (go == null)
            {
                go = new GameObject { name = "GameManager" };
            }
            if (go.GetComponent<GameManager>() == null)
            {
                go.AddComponent<GameManager>();
            }

            //instance �Ҵ�
            instance = go.GetComponent<GameManager>();
        }
    }

    private void Awake()
    {
        Init();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MainLoop();
    }

    void MainLoop()
    {
        bg.BackgroundMove();
        player.PlayerAtt();
    }
}

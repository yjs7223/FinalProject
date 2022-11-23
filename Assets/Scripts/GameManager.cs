using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //외부에서 사용할 변수나 함수를 게임매니저를 거쳐 사용 
    public BackGround bg;
    public Player player;
    public EnemyCreater ec;
    public UIManager uim;
    //public Weapon weapon;
    //public Item item;

    /// <summary>
    /// 본인 인스턴스를 가질변수
    /// </summary>
    static GameManager instance;
    /// <summary>
    /// 게임매니저 인스턴스를 가져오는 함수
    /// </summary>
    /// <returns></returns>
    public static GameManager GetInstance() { Init(); return instance; }

    /// <summary>
    /// 본인 인스턴스 할당(있으면 실행x)
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

            //instance 할당
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

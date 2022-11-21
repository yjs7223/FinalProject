using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public BackGround bg;
    public Player player;
    public Enemy enemy;
    public EnemyCreater ec;
    //public Weapon weapon;
    //public Item item;

    static GameManager instance;
    public static GameManager GetInstance() { Init(); return instance; }

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

            //instance วาด็
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

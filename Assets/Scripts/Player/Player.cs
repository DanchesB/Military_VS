using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour, IDamageble
{
    // public static Player Instance { get; private set; }
 
    #region Stats
    public Stat Hp { get; private set; }
    // public Stat Armour { get; private set; }
    // public Stat Movespeed { get; private set; }
    // public Stat Luck { get; private set; }
    // public Stat AttackSpeed { get; private set; }
    // public Stat AttackCD { get; private set; }
    // public Stat AttackDamage { get; private set; }
    // public Stat AttackAmount { get; private set; }
    #endregion
    // public Ally MainAlly { get; private set; }

    private PlayerView playerView;

    public float CurrHP { get; private set; }
    // int currLvl;
    // bool alive;
    // float currExp;
    // float requierExp;
    // bool immunable;
    // public int CurrWeaponCount { get { return allys.Count; } }
    // public int WeaponMaxCount { get; private set; }

    // List<GameObject> allys = new List<GameObject>();
    // [SerializeField] private GameObject _player;

    // public void Init(PlayerSO _so, int _wpMax)
    public void Awake()
    { 
        gameObject.AddComponent<PlayerInput>();
        gameObject.AddComponent<PlayerController>();
        
        playerView = new PlayerView(gameObject.GetComponent<Animator>());



        // var playerController = gameObject.AddComponent<PlayerController>();
        // playerController.Initialize();

        // var playerObject = gameObject;
        // playerObject.AddComponent<PlayerInput>();
        // var controllerPlayer = playerObject.AddComponent<PlayerController>();
        // controllerPlayer.Initialize();
        // if (Instance == null)
        //     Instance = this;
        // else if (Instance == this)
        //     Destroy(gameObject);
       
        // #region StatsInit
        // Hp = new(_so.Hp);
        // Armour = new(_so.Armour, true);
        // Movespeed = new(_so.Movespeed);
        // Luck = new(_so.Luck, true);
        // AttackSpeed = new(_so.AttackSpeed);
        // AttackCD = new(_so.AttackCD);
        // AttackDamage = new(_so.AttackDamage);
        // AttackAmount = new(_so.AttackAmount);
        // #endregion   


        // MainAlly = _so.MainAlly;
        // var ally = Instantiate(_so.MainAlly.gameObject, transform.position, transform.rotation);
        // ally.transform.parent = gameObject.transform;
        // ally.transform.Rotate(new Vector3(0,180,0));
        // ally.GetComponent<Ally>().Init();
        // allys.Add(ally);

        // alive = true;
        // CurrHP = Hp.Value;
        // WeaponMaxCount = _wpMax;
        // currExp = 0;
        // currLvl = 1;
        // requierExp = 10;

        // var Player = gameObject;
        // Player.AddComponent<PlayerInput>();
        // Player.AddComponent<PlayerController>();
        // playerController = GetComponent<PlayerController>();
        // playerController.Init();
        // playerController.SubsctibeToMove(ally.GetComponent<Ally>().SetCorrectAnimation);
    }
    private void Update()
    {
        // if (alive)
        // {
        //     // MainAlly.Gun.Shoot(playerController.GetMousePoint());
        // }
    }

    private void FixedUpdate()
    {
        playerView.AnimationMove(PlayerInput.Instance.Direction);
    }

    public void TakeDmg(float _dmg)
    {
        // if(!immunable)
        // {
        //     StartCoroutine(GetImmunable());
        //     if (_dmg < 0)
        //         _dmg = 0;
        //     _dmg -= Armour.Value;
        //     CurrHP -= _dmg;
        //     if (CurrHP < 0)
        //         Death();
        // }
    }
    public void Heal(float _heal)
    {
        // CurrHP += _heal;
        // if(CurrHP > Hp.Value)
        //     CurrHP = Hp.Value;
    }
   
    public void Death()
    {
        // alive = false;
    }

    IEnumerator GetImmunable()
    {
        // immunable = true;
        yield return new WaitForSeconds(0.5f);
        // immunable = false;
    }

    #region DiffCalsses
 
    public void GetNewAlly(Allys _wp)
    {
        // float rad = 1;
        // float angle = 0;
        // for (int i = 0; i < CurrWeaponCount + 1; i++)
        // {
        //     Vector3 pos = -(new Vector3(Mathf.Sin(angle), 0, Mathf.Cos(angle))) * rad;
        //     angle += Mathf.PI * 2f / (CurrWeaponCount + 1);
        //     if (i == CurrWeaponCount)
        //     {
        //         var ally = Instantiate(_wp.gameObject, pos, Quaternion.identity);
        //         ally.transform.parent = gameObject.transform;
        //         allys.Add(ally);
        //         // playerController.SubsctibeToMove(ally.GetComponent<Ally>().SetCorrectAnimation);
        //         ally.transform.localPosition = pos;
        //         break;
        //     }else
        //     allys[i].transform.localPosition = pos;
        // }
    }
    public void GetExp(float _exp)
    {
        // if(_exp < 0)
        //     _exp = 0;
        // currExp += _exp;

        // if(currExp >= requierExp)
        // {
        //     currExp -= requierExp;
        //     LvlUp();
        // }
    }
    private void LvlUp()
    {        
        // currLvl++;       
        // requierExp *= (float)currLvl / 1.5f;
    }
    #endregion
}
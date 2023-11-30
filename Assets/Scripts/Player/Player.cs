using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IObservableImpulse
{
    [Header("Datos")]
    //[SerializeField] string _playerName = "";
    public int life = 3;

    //[SerializeField] int _energy = 3;
    //private int _maxEnergy = 5;
    //[SerializeField] EnergyBar _energyBar;

    [Header("Movimiento")]
    [Tooltip("Poner el Stick del Joystick")]
    [SerializeField] Controller _controller;
    [SerializeField] Joystick _joystick;
    [SerializeField] float _gravity; 
    [SerializeField] float _speed;

    [Header("Salto")]
    [SerializeField]ForceMode2D _jumpForceMode;
    [SerializeField] float _jumpForce;
    [SerializeField] LayerMask _floor;
    [SerializeField] Transform _floorController;
    [SerializeField] Vector2 _boxDim;

    [Header("Animacion")]
    private Animator animator;

    [Header("CheckPoint")]
    public Vector2 lastCheckPoint;

    public Rigidbody2D _myRB = default;
    public bool _inFloor = default;
    public bool _push = default;

    private void Awake()
    {
        //if(PlayerPrefs.HasKey("Energy") && PlayerPrefs.HasKey("PlayerName"))
        //{
        //    _energy = PlayerPrefs.GetInt("Energy");
        //    _playerName = PlayerPrefs.GetString("PlayerName");
        //}
        //else
        //{
        //    PlayerPrefs.SetInt("Energy", _maxEnergy);
        //    PlayerPrefs.SetString("PlayerName", _playerName);
        //    PlayerPrefs.Save();
        //}

    }

    private void Start()
    {
        SetPlayerStats();

        animator = GetComponent<Animator>();
        _myRB = GetComponent<Rigidbody2D>();
        life = 3;
        //SavePlayerPrefs.instance.SaveVariables(_energy, _playerName);

        //if(_energyBar != null)
        //{
        //    _energyBar.ChangeMaxEnerfy(_maxEnergy);
        //    _energyBar.ChangeActualEnergy(_energy);
        //}

    }

    void Update()
    {

        Gravity();
        transform.position += _controller.GetMovementInput() * _speed * Time.deltaTime;

        if(animator != null)
            animator.SetFloat("Horizontal", Mathf.Abs( _joystick.MoveDirX()));

        _inFloor = Physics2D.OverlapBox(_floorController.position, _boxDim, 0f, _floor);
        if(animator != null)
            animator.SetBool("jumpy", _inFloor);

    }

    public void Damage()
    {
        life--;
        CallJson.instance.save.GetSaveData.lifeJSON = life;
        transform.position = lastCheckPoint;
        _myRB.AddForce(Vector2.up * 0);
        print("Daño");

        if (life <= 0)
        {
            life = 0;
            SubstracEnergy();
        }
    }

    #region Energy
    public void SubstracEnergy()
    {
        //_energy--;
        //_energyBar.ChangeActualEnergy(_energy);

        BeatEnergyBar();
        ChangedPlayerEnergy();

    }

    public void BeatEnergyBar()
    {
        //if (_energy <= 0) _energy = 0;
        //else if (_energy >= _maxEnergy) _energy = _maxEnergy;
    }
    #endregion

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)//si colisiona con el piso
        {
            //_inFloor = true;
            _push = false;
        }

        if (collision.gameObject.layer == 9 || collision.gameObject.layer == 10)
        {
            Damage();
        }
    }

    #region Jump
    public void Gravity()
    {
        _myRB.gravityScale = _gravity;
    }

    public void Jump(int force = 0)
    {
        if (_inFloor == true)
        {
            _myRB.AddForce(Vector2.up * _jumpForce, _jumpForceMode);
            Debug.Log("salto");
            _inFloor = false;
        }

        foreach(var item in _impulse) //Llamo a todos los impulso que tenga suscrito
        {
            item.Action(_myRB/*, _controller.GetMovementInput()*/);
            _push = true;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(_floorController.position, _boxDim);
    }

    #endregion

    public List<IObserverImpulse> _impulse = new List<IObserverImpulse>();

    public void Subscribe(IObserverImpulse obs)
    {
        if(!_impulse.Contains(obs))
            _impulse.Add(obs);
    }

    public void Unsubscribe(IObserverImpulse obs)
    {
        if(_impulse.Contains(obs))
            _impulse.Remove(obs);
    }

    public void SetPlayerStats()
    {
        if (!CallJson.instance.save) return;
        {
            //_energy = CallJson.instance.save.GetSaveData.energy;
            life = CallJson.instance.save.GetSaveData.lifeJSON;

        }
    }

    public void ChangedPlayerEnergy()
    {
        //CallJson.instance.save.GetSaveData.energy = _energy;
        life = 3;
        CallJson.instance.save.GetSaveData.lifeJSON = life;
    }

    #region App
    //private void OnApplicationQuit()
    //{
    //    PlayerPrefs.SetInt("Energy", _energy);
    //    PlayerPrefs.SetString("PlayerName", _playerName);
    //}

    //public void OnApplicationPause(bool pause)
    //{
    //    if (pause)
    //    {
    //        PlayerPrefs.Save();
    //    }

    //    else
    //        SavePlayerPrefs.instance.LoadVariables();
    //}
    #endregion
}

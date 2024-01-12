using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator), typeof(SpriteRenderer))]
public class Player : MonoBehaviour, IObservableImpulse
{
    [Header("Datos")]
    //[SerializeField] string _playerName = "";
    public int life = 3;

    Rigidbody2D _myRB = default;
    private TrailRenderer _tr;
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
    [SerializeField] float _jumpForce;
    [SerializeField] Transform _floorCheck;
    [SerializeField] LayerMask _floorLayer;
    [SerializeField, Range(0, 0.5f)] private float _coyoteTime = 0.2f;
    private float _coyoteTimeCounter;
    private bool _boostReady;
    private bool _boosting;

    [Header("Animacion")]
    private Animator animator;

    [Header("CheckPoint")]
    public Vector2 lastCheckPoint;


    private void Awake()
    {
        _myRB = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        _tr = GetComponent<TrailRenderer>();

    }

    private void Start()
    {
        _myRB.gravityScale = _gravity;
        life = 3;
        SetPlayerStats();

    }

    void Update()
    {
        transform.position += _controller.GetMovementInput() * _speed * Time.deltaTime;

        if (IsFloor())
        {
            _boosting = false;
            _coyoteTimeCounter = _coyoteTime;
        }
        else
            _coyoteTimeCounter -= Time.deltaTime;

        if (animator != null)
        {
            animator.SetFloat("Horizontal", Mathf.Abs( _joystick.MoveDirX()));
            animator.SetBool("jumpy", IsFloor());
        }

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
            //SubstracEnergy();
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

        if (collision.gameObject.layer == 9 || collision.gameObject.layer == 10)
        {
            Damage();
        }
    }

    #region Jump
    public void Jump()
    {

        if (_boostReady) Boost();

        else if (_coyoteTimeCounter > 0f)
        {
            _coyoteTimeCounter = 0;
            _myRB.velocity = new Vector2(_myRB.velocity.x, _jumpForce);
        }
    }

    public void Boost()
    {
        _boosting = true;
        foreach (var item in _impulse) //Llamo a todos los impulso que tenga suscrito
            item.Boost(_myRB, transform, _tr);
    }

    public bool IsFloor()
    {
        return Physics2D.OverlapCircle(_floorCheck.position, 0.13f, _floorLayer);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(_floorCheck.position, new Vector2(0.5f,0.3f));
    }
    #endregion

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<IObserverBoost>() != null)
            _boostReady = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<IObserverBoost>() != null)
            _boostReady = false;
    }



    public List<IObserverBoost> _impulse = new List<IObserverBoost>();

    public void Subscribe(IObserverBoost obs)
    {
        if(!_impulse.Contains(obs))
            _impulse.Add(obs);
    }

    public void Unsubscribe(IObserverBoost obs)
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

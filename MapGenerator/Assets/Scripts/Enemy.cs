using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType
{
    Eagle,
    Frog,
    Opossum
};

public class Enemy : MonoBehaviour
{
    private const string SPRITE_PATH = "Sprites/{0}/{0}_0";
    private const string ANIMATION_PATH = "Animations/{0}_idle";

    [SerializeField]
    private EnemyType _enemyType = EnemyType.Eagle;
    [SerializeField]
    private int _reverseTimer = 5;

    [SerializeField]
    public int health = 3;

    private SpriteRenderer _renderer;
    private Animator _animator;
    private Transform _transform;
    private Rigidbody2D _rb;
    private bool _direction = false;

    private int factor = -1;
    private int _counter = 0;
    private bool immunity;
    private bool _runningCorroutine = false;

    void Start()
    {
        Init();
    }

    void Update()
    {
        AIMovement();
    }

    private void FixedUpdate()
    {
        _counter += 1;
        if (_counter >= 100)
        {
            factor *= -1;
            _counter = 0;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Player player;
        if (collision.gameObject.TryGetComponent<Player>(out player))
        {
            Debug.Log("Direction: " + _direction);
            GameEvent.OnPlayerTakeDamage?.Invoke(Random.Range(4, 7), new Vector2(400 * (_direction ? 1 : -1), 400));
        }
    }

    public void TakeDamage(int damage, Vector2 pushForce)
    {
        if (immunity == false)
        {
            health -= damage;
            _rb.AddForce(pushForce);
            immunity = true;
            _renderer.color = Color.red;
            StartCoroutine(cancelImmunity());
        }
        if (health <= 0)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }

    private IEnumerator cancelImmunity()
    {
        yield return new WaitForSeconds(0.8f);
        immunity = false;
        _renderer.color = Color.white;
    }

    private void AIMovement()
    {
        switch (_enemyType)
        {
            case EnemyType.Eagle:
                AIMovementEagle();
                break;
            case EnemyType.Frog:
                AIMovementFrog();
                break;
            case EnemyType.Opossum:
                AIMovementOpossum();
                break;
        }
        _direction = _renderer.flipX;
    }
    private void AIMovementEagle()
    {
        _rb.gravityScale = 0;
        Transform transform = gameObject.transform;
        transform.Translate(Vector3.left * factor * Time.deltaTime);
        if (factor > 0)
            _renderer.flipX = false;
        else
            _renderer.flipX = true;
        _transform = transform;
        
    }

    private void AIMovementFrog()
    {
        // TODO
    }

    private void AIMovementOpossum()
    {
        _rb.gravityScale = 1;
        Transform transform = gameObject.transform;
        transform.Translate(Vector3.left * factor * Time.deltaTime);
        if (factor > 0)
            _renderer.flipX = false;
        else
            _renderer.flipX = true;
        _transform = transform;

    }

    public void Init()
    {
        _renderer = GetComponentInChildren<SpriteRenderer>();
        _animator = GetComponentInChildren<Animator>();
        _rb = GetComponent<Rigidbody2D>();

        _renderer.sprite = GetEnemySprite(_enemyType);
        _animator.runtimeAnimatorController = GetEnemyAnimation(_enemyType);
    }

    public static Sprite GetEnemySprite(EnemyType enemyType)
    {
        string path = string.Empty;
        path = string.Format(SPRITE_PATH, enemyType);
        return Resources.Load<Sprite>(path);
    }

    public static RuntimeAnimatorController GetEnemyAnimation(EnemyType enemyType)
    {
        string path = string.Empty;
        path = string.Format(ANIMATION_PATH, enemyType);
        return Resources.Load<RuntimeAnimatorController>(path);
    }
}

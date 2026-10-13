using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    private NavMeshAgent enemyAgent;
    [SerializeField] private GameManagerController _gameManagerController;
    public bool enemyFollow = true;
    [SerializeField] private GameObject player;

    public bool canAttack = true;
    public bool playerInRange = false;
    public float attackCooldown = 1f;
    private int damage = 1;
    public int enemyCurrentHealth;
    [SerializeField] private int enemyMaxHealth =0;
    public bool isDead = false;

    public bool isObjective = false;

    [SerializeField] private Animator _enemyAnim;
    [SerializeField] private string _enemyWalk;
    [SerializeField] private string _enemyAttack;
    [SerializeField] private string _enemyIdle;
    [SerializeField] private string _enemyDie;
    private bool isAttacking = false;


    void Start()
    {
        enemyAgent = GetComponent<NavMeshAgent>();
        enemyCurrentHealth = enemyMaxHealth;

    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            enemyAgent.isStopped = true;
            return;
        }

            

        if (playerInRange == true && canAttack == true)
        {
            enemyAgent.isStopped = true;
            StartCoroutine(EnemyAttack());

        }
        else if (playerInRange == false && canAttack == true)
        {
            enemyAgent.isStopped = false;
            FollowTarget();
        }
        else if (playerInRange && !isAttacking)
        {
            enemyAgent.isStopped = true;
            _enemyAnim.Play(_enemyIdle);
            
        }
    }

    private void LateUpdate()
    {
        FindPlayer();
        FindGameManager();
    }

    private void FollowTarget()
    {
        if (enemyFollow == true && player !=  null)
        {
            enemyAgent.SetDestination(player.transform.position);
            _enemyAnim.Play(_enemyWalk);

        }
       

    }

    private IEnumerator EnemyAttack()
    {
        Debug.Log("Enemy attacked u");
        DamageTarget();
        canAttack = false;
        isAttacking = true;
        _enemyAnim.Play(_enemyAttack);
        yield return new WaitForSeconds(attackCooldown);
        isAttacking = false;
        yield return new WaitForSeconds(0.1f);
        canAttack = true;

    }


    private void DamageTarget()
    {
        player.gameObject.GetComponent<PlayerController>().playerCurrentHealth = player.gameObject.GetComponent<PlayerController>().playerCurrentHealth - damage;
        Debug.Log("player HP:" + player.gameObject.GetComponent<PlayerController>().playerCurrentHealth);

        SoundManager.PlaySound(SoundType.PLAYERHIT);

        if (player.gameObject.GetComponent<PlayerController>().playerCurrentHealth <= 0)
        {
            Destroy(player.gameObject);
        }

    }

    public void takeDamage(int playerDamage)
    {
        Debug.Log("Enemy Hp:" + enemyCurrentHealth);
        enemyCurrentHealth = enemyCurrentHealth - playerDamage;


        if (enemyCurrentHealth <= 0)
        {
            isDead = true;
            CheckObjective();
            _enemyAnim.Play(_enemyDie);
            Destroy(this.gameObject,1.5f);
        }
    }

    private void FindPlayer()
    {
        if(player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }

    private void FindGameManager()
    {
        if(_gameManagerController == null)
        {
            _gameManagerController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManagerController>();
        }
    }
    
    private void CheckObjective()
    {
        if (isObjective)
        {
            _gameManagerController.hasKilledIntruder = true;
        }
    }
}

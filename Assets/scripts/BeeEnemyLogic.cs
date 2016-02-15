using UnityEngine;
using System.Collections;

public class BeeEnemyLogic : MonoBehaviour {

    public float AttackDistance;
    public float Speed;
    public float SecondsAtAttackPoint;

    private GameObject _player;
    private Vector3 _pointToAttack;
    private float _startedWaiting;
    
    private enum BeeState { ATTACKING, WAITING, ROAMING };

    private BeeState state;
	// Use this for initialization
	void Start () {
        _player = GameObject.FindGameObjectWithTag("Player");
        state = BeeState.ROAMING;
	}
	
	// Update is called once per frame
	void Update () {
        // if bee is roaming
        if (state == BeeState.ROAMING)
        {
            if (Vector2.Distance(this.transform.position, _player.transform.position) < AttackDistance)
            {
                _pointToAttack = _player.transform.position;
                state = BeeState.ATTACKING;
            }
            Debug.Log("roaming");
        }
        //if bee is attacking
        if (state == BeeState.ATTACKING)
        {
            transform.position = Vector3.MoveTowards(transform.position, _pointToAttack, Speed * Time.deltaTime);

            if (this.transform.position.Equals(_pointToAttack))
            {
                _startedWaiting = Time.time;
                state = BeeState.WAITING;

                
            }
            Debug.Log("attacking");
        }
        //if bee is waiting
        if (state == BeeState.WAITING)
        {
            if (Time.time > _startedWaiting + SecondsAtAttackPoint)
            {
                state = BeeState.ROAMING;
            }
            
        }

        
       
        
        


	}
}

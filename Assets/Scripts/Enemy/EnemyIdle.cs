using UnityEngine;
namespace Enemy
{
    public class EnemyIdle : StateMachineBehaviour
    {
        public float idleTime = 3f;
        [SerializeField]
        private EnemyController enemyController;

        private float remainingIdle;
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {

            idleTime -= Time.deltaTime;
            if (idleTime <= 0)
            {
                animator.SetBool("isIdling", false);
            }
        }

        public override void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
        }

        public override void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
        }
    }
}

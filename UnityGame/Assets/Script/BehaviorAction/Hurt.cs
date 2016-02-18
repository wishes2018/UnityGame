using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.Custom
{
	[TaskCategory("Basic/CusTom")]
	public class Hurt : Action
	{
		private AnimatorStateInfo stateinfo;
		private Animator animator;
		public override void OnStart(){
			GetComponent<Animator> ().Play ("hurt");
			animator = GetComponent<Animator> ();
		}

		public override TaskStatus OnUpdate(){
			stateinfo = animator.GetCurrentAnimatorStateInfo(0);
			if (stateinfo.IsName ("Base Layer.attack")) {
				Debug.Log ("play attack");
			}
			if (stateinfo.IsName ("Base Layer.hurt")) {
				Debug.Log ("play hurt");
				return TaskStatus.Running;
			} else {
				Debug.Log ("play hurt finish ");
				return TaskStatus.Running;
			}
		}
	}
}
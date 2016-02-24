using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.Custom
{
	[TaskCategory("Basic/CusTom")]
	public class Dead : Action
	{
		BehaviorTree tree;
		Animator animator;
		AnimatorStateInfo stateinfo;
		public override void OnStart(){
			animator = GetComponent<Animator> ();
			animator.Play ("dead");
		}

		public override TaskStatus OnUpdate(){
			stateinfo = animator.GetCurrentAnimatorStateInfo(0);
			if (stateinfo.IsName ("Base Layer.dead") && stateinfo.normalizedTime >= 0.99f) {
				gameObject.SetActive (false);
				return TaskStatus.Success;
			}
			return TaskStatus.Running;
		}
	}
}
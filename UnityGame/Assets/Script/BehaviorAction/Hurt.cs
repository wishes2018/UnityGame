using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.Custom
{
	[TaskCategory("Basic/CusTom")]
	public class Hurt : Action
	{
		private AnimatorStateInfo stateinfo;
		private Animator animator;
		private BehaviorTree tree;
		private SharedBool hurted;
		public override void OnStart(){
			GetComponent<Animator> ().Play ("hurt");
			animator = GetComponent<Animator> ();
			tree = GetComponent<BehaviorTree> ();
			hurted = (SharedBool)tree.GetVariable ("hurted");
		}

		public override TaskStatus OnUpdate(){
			stateinfo = animator.GetCurrentAnimatorStateInfo(0);
			if (stateinfo.IsName ("Base Layer.hurt") && stateinfo.normalizedTime >= 0.99f) {
				hurted.Value = false;
				return TaskStatus.Success;
			}
			return TaskStatus.Running;
		}
	}
}
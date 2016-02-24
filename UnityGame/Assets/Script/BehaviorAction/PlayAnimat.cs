using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.Custom
{
	[TaskCategory("Basic/CusTom")]
	public class PlayAnimat : Action
	{
		public string animName;
		Animator animator;
		AnimatorStateInfo stateinfo;
		public override void OnStart(){
			animator = GetComponent<Animator> ();
			animator.Play (animName);
		}

		public override TaskStatus OnUpdate(){
			stateinfo = animator.GetCurrentAnimatorStateInfo(0);
			if (stateinfo.IsName ("Base Layer."+animName) && stateinfo.normalizedTime >= 0.99f) {
				return TaskStatus.Success;
			}
			return TaskStatus.Running;
		}
	}
}
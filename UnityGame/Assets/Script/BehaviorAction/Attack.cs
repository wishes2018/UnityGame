using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.Custom
{
	[TaskCategory("Basic/CusTom")]
	public class Attack : Action
	{
		public override void OnStart(){
			GetComponent<Animator> ().Play ("attack");
		}

		public override TaskStatus OnUpdate(){
			return TaskStatus.Running;
		}
	}
}
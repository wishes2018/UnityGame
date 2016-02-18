using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.Custom
{
	[TaskCategory("Basic/CusTom")]
	public class Attack : Action
	{
		BehaviorTree tree;
		public override void OnStart(){
			GetComponent<Animator> ().Play ("attack");
			tree = GetComponent<BehaviorTree> ();
			SharedGameObject enemy = (SharedGameObject)tree.GetVariable ("enemy");
			transform.LookAt (enemy.Value.transform.position);
		}

		public override TaskStatus OnUpdate(){
			return TaskStatus.Running;
		}
	}
}
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.Custom
{
	[TaskCategory("Basic/CusTom")]
	public class MoveTo : Action
	{
		public float speed = 0;
		public SharedTransform target;

		public override TaskStatus OnUpdate(){
			if (Vector3.SqrMagnitude(transform.position - target.Value.position) < 0.0001f) {
				Debug.Log("MoveTo success");
				return TaskStatus.Success;
			}
			transform.LookAt (target.Value);
			transform.position = Vector3.MoveTowards(transform.position, target.Value.position, speed * Time.deltaTime);
			return TaskStatus.Running;
		}
	}
}
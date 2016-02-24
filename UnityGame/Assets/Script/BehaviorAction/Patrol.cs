using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.Custom
{
	[TaskCategory("Basic/CusTom")]
	public class Patrol : Action
	{
		public float speed = 3;
		private Vector3 originPos = new Vector3(0,0,0);
		private Vector3 curPoint;

		public override void OnStart(){
			Random.seed = System.DateTime.Now.Millisecond;
			curPoint = GeneratePoint();
			GetComponent<Animator> ().Play ("walk");
		}

		public override TaskStatus OnUpdate(){
			if (Vector3.SqrMagnitude(transform.position - curPoint) < 0.0001f) {
				curPoint = GeneratePoint();
			}
			transform.LookAt (curPoint);
			transform.position = Vector3.MoveTowards(transform.position, curPoint, speed * Time.deltaTime);
			return TaskStatus.Running;
		}

		private Vector3 GeneratePoint(){
			float x = Random.Range (1, 5);
			float z = Random.Range (1, 5);
			Vector3 vec = new Vector3 (x, originPos.y, z);
			return originPos + vec;
		}
	}
}
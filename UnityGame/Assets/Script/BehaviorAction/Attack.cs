﻿using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.Custom
{
	[TaskCategory("Basic/CusTom")]
	public class Attack : Action
	{
		BehaviorTree tree;
		Animator animator;
		AnimatorStateInfo stateinfo;
		public override void OnStart(){
			animator = GetComponent<Animator> ();
			animator.Play ("attack");
			tree = GetComponent<BehaviorTree> ();
			SharedGameObject enemy = (SharedGameObject)tree.GetVariable ("enemy");
			transform.LookAt (enemy.Value.transform.position);
		}

		public override TaskStatus OnUpdate(){
			stateinfo = animator.GetCurrentAnimatorStateInfo(0);
			if (stateinfo.IsName ("Base Layer.attack") && stateinfo.normalizedTime >= 0.99f) {
				return TaskStatus.Success;
			}
			return TaskStatus.Running;
		}
	}
}
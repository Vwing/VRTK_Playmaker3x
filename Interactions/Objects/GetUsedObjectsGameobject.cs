// Custom Action by DumbGameDev
// www.dumbgamedev.com

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("VRTK")]
	[Tooltip("Gets which gameobject (usually a controller) is using an interactable object.")]

	public class  GetUsedObjectsGameobject : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(VRTK.VRTK_InteractableObject))]    
		public FsmOwnerDefault gameObject;

		[Tooltip("Gets which gameobject is doing the using")]
		[ArrayEditor(VariableType.GameObject)]
		public FsmGameObject gameobjectBeingUsed;

		public FsmBool everyFrame;

		VRTK.VRTK_InteractableObject theScript;

		public override void Reset()
		{

			gameobjectBeingUsed = null;
			gameObject = null;
			everyFrame = false;
		}

		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);


			theScript = go.GetComponent<VRTK.VRTK_InteractableObject>();

			if (!everyFrame.Value)
			{
				MakeItSo();
				Finish();
			}

		}

		public override void OnUpdate()
		{
			if (everyFrame.Value)
			{
				MakeItSo();
			}
		}


		void MakeItSo()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);
			if (go == null)
			{
				return;
			}

			gameobjectBeingUsed.Value = theScript.GetUsingObject();

		}

	}
}
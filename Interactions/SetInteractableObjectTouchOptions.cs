// Custom Action by DumbGameDev
// www.dumbgamedev.com

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("VRTK")]
	[Tooltip("Sets interactable object touch settings.")]

	public class  SetInteractableObjectTouchOptions : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(VRTK.VRTK_InteractableObject))]    
		public FsmOwnerDefault gameObject;

		public FsmColor touchHighlightColor;

		[ObjectType(typeof(VRTK.VRTK_InteractableObject.AllowedController))]
		public FsmEnum allowedTouchedController;

		public FsmBool everyFrame;

		VRTK.VRTK_InteractableObject theScript;

		public override void Reset()
		{

			touchHighlightColor = null;
			allowedTouchedController = null;
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

			theScript.touchHighlightColor = touchHighlightColor.Value;
			theScript.allowedTouchControllers = (VRTK.VRTK_InteractableObject.AllowedController)allowedTouchedController.Value;

		}

	}
} 
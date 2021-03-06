// Custom Action by DumbGameDev
// www.dumbgamedev.com

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("VRTKController")]
	[Tooltip("Check whether the controller is currently visible.")]

	public class  getControllerVisible : FsmStateAction

	{
		[RequiredField]
		[CheckForComponent(typeof(VRTK.VRTK_ControllerActions))]    
		public FsmOwnerDefault gameObject;

		[Tooltip("Get controller visibility")]
		public FsmBool getControllerVisibility;

		public FsmBool everyFrame;

		VRTK.VRTK_ControllerActions theScript;

		public override void Reset()
		{

			getControllerVisibility = false;
			gameObject = null;
			everyFrame = false;
		}

		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<VRTK.VRTK_ControllerActions>();

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

			getControllerVisibility.Value = theScript.IsControllerVisible ();		
		}

	}
}
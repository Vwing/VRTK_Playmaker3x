// Custom Action by DumbGameDev
// www.dumbgamedev.com

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("VRTKController")]
	[Tooltip("Set controller opacity.")]

	public class  setControllerOpacity : FsmStateAction

	{
		[RequiredField]
		[CheckForComponent(typeof(VRTK.VRTK_ControllerActions))]    
		public FsmOwnerDefault gameObject;

		[Tooltip("Set controller opacity. Between 0 and 1 float")]
		public FsmFloat setControllerAlpha;

		public FsmBool everyFrame;

		VRTK.VRTK_ControllerActions theScript;

		public override void Reset()
		{

			setControllerAlpha = null;
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

			theScript.SetControllerOpacity (setControllerAlpha.Value);
		}

	}
}
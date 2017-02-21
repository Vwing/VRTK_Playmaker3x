// Custom Action by DumbGameDev

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("VRTK")]
	[Tooltip("Set Straight Pointer Renderer colors.")]

	public class  SetStraightPointerColor : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(VRTK.VRTK_StraightPointerRenderer))]    
		public FsmOwnerDefault gameObject;

		[Tooltip("Set pointer hit laser color.")]
		[TitleAttribute("Valid Collision Color")]
		public FsmColor hitcolorlazer;

		[Tooltip("Set pointer miss laser color.")]
		[TitleAttribute("Invalid Collision Color")]
		public FsmColor misscolorlazer;

		public FsmBool everyFrame;

		VRTK.VRTK_StraightPointerRenderer theScript;

		public override void Reset()
		{

			gameObject = null;
			hitcolorlazer = null;
			misscolorlazer = null;
			everyFrame = false;
		}

		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);


			theScript = go.GetComponent<VRTK.VRTK_StraightPointerRenderer>();

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

			theScript.validCollisionColor = hitcolorlazer.Value;
			theScript.invalidCollisionColor = misscolorlazer.Value;

		}

	}
}
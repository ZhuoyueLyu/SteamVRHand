using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

namespace Valve.VR.InteractionSystem.Sample {
    public class flyingHand : MonoBehaviour
    {
        public Hand hand;
        public Transform handModel;
        public SteamVR_Action_Vector2 moveAction = SteamVR_Input.GetAction<SteamVR_Action_Vector2>("platformer", "Move");

        private void OnEnable()
        {
            if (hand == null)
                hand = this.GetComponent<Hand>();
        }
        // Update is called once per frame
        void Update()
        {
            Vector2 move = SteamVR_Actions.MultiHand.flyingHand[hand.handType].axis;
            if (move.magnitude > 1f)
                move.Normalize();
            //move = transform.InverseTransformDirection(move);
            handModel.localPosition += new Vector3(move.x * 0.1f, 0, move.y*0.1f);
        }
    }
}

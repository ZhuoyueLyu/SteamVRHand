//======= Copyright (c) Valve Corporation, All rights reserved. ===============

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

namespace Valve.VR.InteractionSystem.Sample
{
    public class nyChange : MonoBehaviour
    {
        public SteamVR_Action_Boolean bigger;

        public SteamVR_Action_Boolean smaller;

        public Hand hand;

        public Transform handToResize;



        private void OnEnable()
        {
            if (hand == null)
                hand = this.GetComponent<Hand>();

            bigger.AddOnChangeListener(OnBiggerActionChange, hand.handType);
            smaller.AddOnChangeListener(OnSmallerActionChange, hand.handType);
        }

        private void OnDisable()
        {
            if (bigger != null)
                bigger.RemoveOnChangeListener(OnBiggerActionChange, hand.handType);
            if (smaller != null)
                smaller.RemoveOnChangeListener(OnSmallerActionChange, hand.handType);
        }

        private void OnBiggerActionChange(SteamVR_Action_Boolean actionIn, SteamVR_Input_Sources inputSource, bool newValue)
        {
            if (newValue)
            {
                handToResize.localScale += new Vector3(1, 1, 1);
            }
        }

        private void OnSmallerActionChange(SteamVR_Action_Boolean actionIn, SteamVR_Input_Sources inputSource, bool newValue)
        {
            if (newValue)
            {
                handToResize.localScale -= new Vector3(1, 1, 1);
            }
        }
















    }
}

     
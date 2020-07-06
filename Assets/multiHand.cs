using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

namespace Valve.VR.InteractionSystem.Sample
{
    public class multiHand : MonoBehaviour
    {

        public Hand hand;
        public GameObject renderModelPrefab;
        public GameObject[] newCloneHands;
        public Transform parent;
        private bool canChange = true;
        private bool canChangeMove = true;


        private void OnEnable()
        {
            if (hand == null)
                hand = this.GetComponent<Hand>();
        }

        private void Update()
        {
            //if (SteamVR_Input.GetState("grabGrip", hand.handType))
            if (SteamVR_Actions.MultiHand.newHand[hand.handType].state)
            {   if (canChange) {
                    Debug.Log("we are here");
                    Debug.Log(SteamVR_Input.GetState("grabGrip", hand.handType));
                    GameObject renderModelInstance = GameObject.Instantiate(renderModelPrefab);
                    //renderModelInstance.transform.parent = this.transform;
                    renderModelInstance.tag = "newCloneHand";
                    renderModelInstance.transform.position = this.transform.position;
                    renderModelInstance.transform.rotation = this.transform.rotation;
                    renderModelInstance.transform.localScale = renderModelPrefab.transform.localScale;
                    canChange = false;
                }
            }
            else {
                canChange = true;
            }

            if (SteamVR_Actions.MultiHand.moveHands[hand.handType].state)
            {   if (canChangeMove) {
                    newCloneHands = GameObject.FindGameObjectsWithTag("newCloneHand");
                    foreach (GameObject newCloneHand in newCloneHands)
                    {
                        newCloneHand.transform.parent = parent.transform;
                    }
                    canChangeMove = false;
                }
            }
            else
            {
                canChangeMove = true;
            }


        }

    }
}
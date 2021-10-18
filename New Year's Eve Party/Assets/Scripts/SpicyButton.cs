using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class SpicyButton : UdonSharpBehaviour
{
    public Sign sign;
    public override void Interact()
    {
        sign.spicy = true;
        sign.NextQuestions();
    }
}

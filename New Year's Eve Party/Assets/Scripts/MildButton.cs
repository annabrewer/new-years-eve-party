using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class MildButton : UdonSharpBehaviour
{
    public Sign sign;
    public override void Interact()
    {
        sign.spicy = false;
        sign.NextQuestions();
    }
}
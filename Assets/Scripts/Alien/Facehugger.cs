using UnityEngine;

namespace Alien
{
    public class Facehugger : MonoBehaviour
    {
        Animation anim;
        AnimationClip clip;
        AnimationEvent animationEvent;

        void Awake()
        {
            anim = GetComponentInParent<Animation>();

            animationEvent = new AnimationEvent();
            animationEvent.time = 3.0f;
            animationEvent.functionName = "Infect";

            clip = new AnimationClip();
            clip.legacy = true;
            clip.name = "alienEnter";
            clip.AddEvent(animationEvent);
        }

        void SetPosCurve(string property, float pos)
        {
            AnimationCurve curve = AnimationCurve.EaseInOut(0.0f, 0.0f, 2.0f, pos * 4);
            SetCurve(property, curve);
        }

        void SetCurve(string property, AnimationCurve curve)
        {
            clip.SetCurve(name, typeof(Transform), property, curve);
        }

        public void MoveTo(Human.Corpse corpse)
        {
            var diff = corpse.transform.position - transform.position;

            SetPosCurve("localPosition.x", diff.x);
            SetPosCurve("localPosition.y", diff.y);

            AnimationCurve alienEnterCurve = AnimationCurve.Linear(2.0f, 0.5f, 3.0f, 0.0f);
            SetCurve("localScale.x", alienEnterCurve);
            SetCurve("localScale.y", alienEnterCurve);

            anim.AddClip(clip, clip.name);
            anim.Play(clip.name);
        }
    }
}

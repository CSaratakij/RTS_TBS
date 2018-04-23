using System.Collections;
using UnityEngine;

namespace LD41
{
    public class BeamController : MonoBehaviour
    {
        //Hacks
        [SerializeField]
        PlayerActor player;

        [SerializeField]
        Transform target;

        [SerializeField]
        Vector2 offset;

        [SerializeField]
        Transform groundBeam;

        [SerializeField]
        Animator grounBeamAnim;


        Animator anim;


        void Awake()
        {
            _Initialize();
        }

        void _Initialize()
        {
            anim = GetComponent<Animator>();
        }

        public void Use()
        {
            Use(target.position, offset);
        }

        public void Use(Vector2 target, Vector2 offset)
        {
            //Hacks
            if (player) {
                player.RemoveHealth(14);
            }

            groundBeam.position = target + offset;
            transform.position = groundBeam.position + (Vector3.up * -0.5f);

            _ShowBeam(true);
            StartCoroutine(_Use_Beam_Callback());
        }

        IEnumerator _Use_Beam_Callback()
        {
            yield return new WaitForSeconds(1.0f);
            _ShowBeam(false);
        }

        void _ShowBeam(bool value)
        {
            if (value) {
                anim.Play("Ray");
                grounBeamAnim.Play("Use");
            }
            else {
                anim.Play("Idle");
                grounBeamAnim.Play("Idle");
            }
        }
    }
}

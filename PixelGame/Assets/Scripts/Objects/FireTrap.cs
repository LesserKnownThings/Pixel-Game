using Assets.Scripts.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Objects
{
    public class FireTrap:MonoBehaviour
    {
        private Animator anim { get => GetComponent<Animator>(); }

        private Coroutine fireRunning;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Player")
            {
                anim.SetTrigger("TurnOn");
                fireRunning = StartCoroutine(WaitBeforeDamage(collision.GetComponent<PlayerMovement>()));
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.tag == "Player")
            {
                if (fireRunning != null)
                    StopCoroutine(fireRunning);
            }
        }

        private IEnumerator WaitBeforeDamage(PlayerMovement player)
        {
            yield return new WaitForSeconds(.35f);
            player.GetHit();
            PlayerStats.GetHit();
        }

    }
}

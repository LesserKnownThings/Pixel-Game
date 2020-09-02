using Assets.Scripts.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Collecting
{
    public class CollectFruit:MonoBehaviour
    {
        Animator anim { get => GetComponent<Animator>(); }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Player")
            {
                GlobalVariables.CollectedFruits++;
                anim.SetTrigger("Destroy");
                Destroy(gameObject,.25f);
            }
        }
    }
}

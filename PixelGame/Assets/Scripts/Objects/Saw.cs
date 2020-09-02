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
    public class Saw:MonoBehaviour
    {

        public void StartMoving()
        {
            StartCoroutine(Move());
        }

        private IEnumerator Move()
        {
            while (true)
            {
                transform.Translate(-transform.right * Time.deltaTime * 15f, Space.World);
                yield return null;
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Player")
            {
                PlayerStats.GetHit();
                collision.GetComponent<PlayerMovement>().GetHit();
            }

            if(collision.tag != "Background")
            Destroy(gameObject);
        }
    }
}

using Assets.Code.Constants;
using UnityEngine;

namespace Assets.Code.Hero
{
    class ItemCollectors : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == Tags.Collectable)
            {
                var collectableItem = collision.gameObject.GetComponent<CollectableItem>();
                collectableItem.ChangeState(true);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.tag == Tags.Collectable)
            {
                var collectableItem = collision.gameObject.GetComponent<CollectableItem>();
                collectableItem.ChangeState(false);
            }
        }
    }
}

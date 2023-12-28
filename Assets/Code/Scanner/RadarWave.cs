using Assets.Code.Constants;
using UnityEngine;

namespace Assets.Code.Scanner
{
    class RadarWave : MonoBehaviour
    {
        [SerializeField] private float maxScale;
        [SerializeField] private float speedIncrease;
        private float currentScale;

        private void Update()
        {
            ChangeScale();
        }

        private void ChangeScale()
        {
            currentScale += speedIncrease * Time.deltaTime;

            transform.localScale = new Vector3(currentScale, currentScale, 1);

            if(currentScale >= maxScale)
            {
                Destroy(gameObject);
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == Tags.Ground)
            {
                var groundBorder = collision.gameObject.GetComponent<GroundBorder>();
                groundBorder.BorderMaterial.gameObject.SetActive(true);
                groundBorder.DisableBorder();
            }

            if(collision.gameObject.tag == Tags.Collectable)
            {
                var collectableBorder = collision.gameObject.GetComponent<GroundBorder>();
                collectableBorder.BorderMaterial.gameObject.SetActive(true);
                collectableBorder.DisableBorder();
            }
        }
    }
}

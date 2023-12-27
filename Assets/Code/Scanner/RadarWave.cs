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

        //private void OnTriggerStay2D(Collider2D collision)
        //{
        //    Debug.Log("111111111111111");
        //    if (collision.gameObject.tag == Tags.Ground)
        //    {
        //        Debug.Log("2222222222222");
        //        Destroy(collision.gameObject);
        //    }
        //}

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == Tags.Ground)
            {
                collision.gameObject.GetComponent<GroundBorder>().BorderMaterial.gameObject.SetActive(true);
                //Destroy(collision.gameObject);
                //Time.timeScale = 0;
                //ScreenSwitcher.ShowScreen(ScreenType.LoseScreen);
            }
        }

        //private void OnTriggerExit2D(Collider2D collision)
        //{
        //    if (collision.gameObject.tag == Tags.Ground)
        //    {
        //        collision.gameObject.GetComponent<GroundBorder>().BorderMaterial.gameObject.SetActive(false);
        //        //Destroy(collision.gameObject);
        //        //Time.timeScale = 0;
        //        //ScreenSwitcher.ShowScreen(ScreenType.LoseScreen);
        //    }
        //}
    }
}

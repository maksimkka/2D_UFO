using UnityEngine;

public class CollectableItem : MonoBehaviour
{
    [SerializeField] private int value;
    [SerializeField] private int speed;
    private bool isStartCollect;
    
    private Transform targetMove;

    private void Awake()
    {
        targetMove = FindObjectOfType<CollectorController>().transform;
    }

    private void Update()
    {
        MoveCoolect();
    }

    public void ChangeState(bool state)
    {
        isStartCollect = state;
    }

    public void SetTarget(Transform target)
    {
        targetMove = target;
    }

    private void MoveCoolect()
    {
        if(isStartCollect)
        {
            Vector3 direction = targetMove.position - transform.position;
            direction.Normalize();

            transform.Translate(direction * speed * Time.deltaTime);

            CheckDistance();
        }
    }

    private void CheckDistance()
    {
        var distance = Vector3.Distance(transform.position, targetMove.position);

        if (distance <= 0.5)
        {
            gameObject.SetActive(false);
            isStartCollect = false;
        }
    }
}

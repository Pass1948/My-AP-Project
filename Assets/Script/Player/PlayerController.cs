using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int hp;
    public int HP { get { return hp; } private set { hp = value; OnChangedHP?.Invoke(HP); } }
    public UnityEvent<int> OnChangedHP;
    public UnityEvent OnDied;

    private void Awake()
    {
        GameManager.UI.ShowInGameUI<InGameUI>("UI/SelectBoxUi");
    }

    public void TakeHit(int damage)
    {
        HP -= damage;

        if (HP <= 0)
        {
            OnDied?.Invoke();
            GameManager.Resource.Destroy(gameObject);
        }
    }


}

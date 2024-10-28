using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CampFire : MonoBehaviour
{
    public int damage;
    public float damageRate;

    List<IDamagaIbe> things = new List<IDamagaIbe>();

    void Start()
    {
        InvokeRepeating("DealDamage", 0, damageRate);
    }

    void DealDamage()
    {
        for(int i = 0; i < things.Count; i++)
        {
            things[i].TakePhysicalDamage(damage);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out IDamagaIbe damagaIbe))
        {
            // 인터페이스 IDamagaIbe를 가지고 있다면 리스트에 보관
            things.Add(damagaIbe);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.TryGetComponent(out IDamagaIbe damagaIbe))
        {
            things.Remove(damagaIbe);
        }
    }
}

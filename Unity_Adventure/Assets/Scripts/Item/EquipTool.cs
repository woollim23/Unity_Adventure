using UnityEngine;

public class EquipTool : Equip
{
    public float attackRate; // 공격 주기
    private bool attacking;
    public float attackDistance; // 최대 공격 가능 거리

    [Header("Resource Gathering")]
    public bool doesGatherResources; // 자원 채취 할 수 있는지

    [Header("Combat")]
    public bool doesDealDamage; // 공격 데미지를 줄 수 있는지
    public int damage; // 데미지 얼마만큼 줄건지

    private Animator animator;
    private Camera camera;

    private void Awake()
    {
        camera = Camera.main;
        animator = GetComponent<Animator>();
    }

    public override void OnAttackInput()
    {
        if (!attacking)
        {
            attacking = true;
            animator.SetTrigger("Attack");
            Invoke("OnCanAttack", attackRate);
        }
    }

    void OnCanAttack()
    {
        attacking = false;
    }

    public void OnHit()
    {
        Ray ray = camera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, attackDistance))
        {
            if (doesGatherResources && hit.collider.TryGetComponent(out Resource resource))
            {
                resource.Gather(hit.point, hit.normal);
            }

            //if (doesDealDamage && hit.collider.TryGetComponent(out IDamagable damagable))
            //{
            //    damagable.TakePhysicalDamage(damage);
            //}
        }
    }
}

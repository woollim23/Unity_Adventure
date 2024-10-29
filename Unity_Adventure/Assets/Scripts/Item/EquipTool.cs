using UnityEngine;

public class EquipTool : Equip
{
    public float attackRate; // ���� �ֱ�
    private bool attacking;
    public float attackDistance; // �ִ� ���� ���� �Ÿ�

    [Header("Resource Gathering")]
    public bool doesGatherResources; // �ڿ� ä�� �� �� �ִ���

    [Header("Combat")]
    public bool doesDealDamage; // ���� �������� �� �� �ִ���
    public int damage; // ������ �󸶸�ŭ �ٰ���

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

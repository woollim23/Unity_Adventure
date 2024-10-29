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
}

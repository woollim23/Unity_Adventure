using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerController controller;

    private void Awake()
    {
        // 1. 캐릭터 매니저에 접근. 없는 것을 확인하고 매니저 생성
        CharacterManager.Instance.Player = this;
        controller = GetComponent<PlayerController>();
    }
}

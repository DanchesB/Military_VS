using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]
public class Ally : MonoBehaviour
{
    PlayerView playerView;
    [field: SerializeField]public Weapon Gun { get; private set; }
    //������ �������� ��������� ��� ���� � ����������� �� ��������� � ������, ��� ��� �������� ���������� ����
    Vector2 directionMultiplier;
    public void Init()
    {
        playerView = new(GetComponent<Animator>());
    }
    public void SetCorrectAnimation(Vector2 direction)
    {
        direction += directionMultiplier;
        playerView.AnimationMove(direction);
    }
}

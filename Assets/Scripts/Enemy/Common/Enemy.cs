using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private int _xpForKilling = 10;

    public int XpForKilling { get => _xpForKilling; }
}
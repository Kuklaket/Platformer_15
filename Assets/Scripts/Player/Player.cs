using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(Jumper))]
[RequireComponent(typeof(CharacterAnimator))]
public class Player : MonoBehaviour
{
    [SerializeField] private Collector _collector;
}
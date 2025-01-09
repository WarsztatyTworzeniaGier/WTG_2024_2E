using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Data/PlayerData", order =0)]
public class PlayerData : ScriptableObject
{
    [Header("Data")]
    [SerializeField]
    private string playerName = "Mariusz pierwszy";

    [SerializeField]
    private int startHealth = 3;

    [Header("Movement")]

    [SerializeField]
    private float moveSpeed = 1.4f;

    [SerializeField]
    private float jumpPower = 10f;

    [SerializeField]
    private int maxJumps = 2;

    [SerializeField]
    private float raycastDistance = 0.6f;

    [SerializeField]
    private LayerMask groundMask;

    public string PlayerName { get => playerName; set => playerName = value; }
    public int StartHealth { get => startHealth; set => startHealth = value; }
    public float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }
    public float JumpPower { get => jumpPower; set => jumpPower = value; }
    public int MaxJumps { get => maxJumps; set => maxJumps = value; }
    public float RaycastDistance { get => raycastDistance; set => raycastDistance = value; }
    public LayerMask GroundMask { get => groundMask; set => groundMask = value; }


    private void OnValidate()
    {
        Debug.Log("Onvalidate");
    }
}

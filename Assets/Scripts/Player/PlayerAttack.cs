using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ComboState
{
    NONE,
    PUNCH_1,
    PUNCH_2,
    PUNCH_3,
    KICK_1,
    KICK_2
}

public class PlayerAttack : MonoBehaviour
{
    private CharacterAnimation playerAnimation;

    private bool activateTimerToReset;

    private float defaultComboTimer = 0.4f;
    private float currentComboTimer;

    private ComboState currentComboState;

    // Start is called before the first frame update
    void Awake()
    {
        playerAnimation = GetComponentInChildren<CharacterAnimation>();
    }

    void Start()
    {
        currentComboTimer = defaultComboTimer;
        currentComboState = ComboState.NONE;
    }

    // Update is called once per frame
    void Update()
    {
        ComboAttacks();
        ResetComboState();
    }

    void ComboAttacks()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {

            if (currentComboState == ComboState.PUNCH_3 || currentComboState == ComboState.KICK_1 || currentComboState == ComboState.KICK_2) return;

            currentComboState++;
            activateTimerToReset = true;
            currentComboTimer = defaultComboTimer;

            if (currentComboState == ComboState.PUNCH_1)
            {
                playerAnimation.Punch_1();
            }
            if (currentComboState == ComboState.PUNCH_2)
            {
                playerAnimation.Punch_2();
            }
            if (currentComboState == ComboState.PUNCH_3)
            {
                playerAnimation.Punch_3();
            }
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            if(currentComboState == ComboState.KICK_2 || currentComboState == ComboState.PUNCH_3) return;

            if(currentComboState == ComboState.NONE || currentComboState == ComboState.PUNCH_1 || currentComboState == ComboState.PUNCH_2)
            {
                currentComboState = ComboState.KICK_1;
            }
            else if(currentComboState == ComboState.KICK_1)
            {
                currentComboState++;
            }

            activateTimerToReset = true;
            currentComboTimer = defaultComboTimer;

            if(currentComboState == ComboState.KICK_1)
            {
                playerAnimation.Kick_1();
            }
            if (currentComboState == ComboState.KICK_2)
            {
                playerAnimation.Kick_2();
            }
        }
    }

    void ResetComboState()
    {
        if(activateTimerToReset)
        {
            currentComboTimer -= Time.deltaTime; 

            if(currentComboTimer <= 0)
            {
                currentComboState = ComboState.NONE;

                activateTimerToReset = false;
                currentComboTimer = defaultComboTimer;
            }
        }
    }
}

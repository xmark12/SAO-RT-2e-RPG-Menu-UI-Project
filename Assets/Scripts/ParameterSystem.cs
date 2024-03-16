using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ParameterSystem : MonoBehaviour
{
    // STR
    [SerializeField] TMP_InputField inputSTR;
    [SerializeField] TMP_Text modResultSTR;
    [SerializeField] TMP_Text baseSTR;

    // --------------------------------
    // Base/Unarmed DMG
    [SerializeField] TMP_Text unarmed;
    // --------------------------------

    // AGI
    [SerializeField] TMP_InputField inputAGI;
    [SerializeField] TMP_Text modResultAGI;
    [SerializeField] TMP_Text baseAGI;

    // --------------------------------
    // Movement Speed
    [SerializeField] TMP_Text movementSpeed;
    // Speed Charge Speed
    [SerializeField] TMP_Text speedChargeSpeed;
    // --------------------------------

    // DEX
    [SerializeField] TMP_InputField inputDEX;
    [SerializeField] TMP_Text modResultDEX;
    [SerializeField] TMP_Text baseDEX;

    // VIT
    [SerializeField] TMP_InputField inputVIT;
    [SerializeField] TMP_Text modResultVIT;
    [SerializeField] TMP_Text baseVIT;

    // --------------------------------
    // HP
    [SerializeField] TMP_Text resultHP;
    // Air
    [SerializeField] TMP_Text resultAir;
    // --------------------------------

    // PER
    [SerializeField] TMP_InputField inputPER;
    [SerializeField] TMP_Text modResultPER;
    [SerializeField] TMP_Text basePER;

    // CHA
    [SerializeField] TMP_InputField inputCHA;
    [SerializeField] TMP_Text modResultCHA;
    [SerializeField] TMP_Text baseCHA;

    // LVL, Stat Points, and Max EXP
    [SerializeField] TMP_InputField inputLVL;
    [SerializeField] TMP_Text resultStatPoints;
    [SerializeField] TMP_Text resultMaxEXP;

    // Block, Deflect, Reflect, Graze, Dodge, Counter
    [SerializeField] TMP_Text block;
    [SerializeField] TMP_Text deflect;
    [SerializeField] TMP_Text reflect;
    [SerializeField] TMP_Text graze;
    [SerializeField] TMP_Text dodge;
    [SerializeField] TMP_Text counter;

    private int paramSTR = 0;
    private int paramAGI = 0;
    private int paramDEX = 0;
    private int paramVIT = 0;
    private int paramPER = 0;
    private int paramCHA = 0;

    private int baseParamSTR = 0;
    private int baseParamAGI = 0;
    private int baseParamDEX = 0;
    private int baseParamVIT = 0;
    private int baseParamPER = 0;
    private int baseParamCHA = 0;

    private int blockVal = 0;
    private int deflectVal = 0;
    private int reflectVal = 0;
    private int grazeVal = 0;
    private int dodgeVal = 0;
    private int counterVal = 0;

    private int unarmedVal = 0;

    void Update()
    {
        // LVL; does not account for negative levels as of now
        // ---------------------------------------------------
        string LVL = inputLVL.text;

        if (string.IsNullOrWhiteSpace(LVL))
        {
            resultStatPoints.text = "No Level Given";
            resultStatPoints.color = Color.red;

            resultMaxEXP.text = "No Level Given";
            resultMaxEXP.color = Color.red;

            baseSTR.text = "N/A";
            baseSTR.color = Color.red;
            baseParamSTR = 0;

            baseAGI.text = "N/A";
            baseAGI.color = Color.red;
            baseParamAGI = 0;

            baseDEX.text = "N/A";
            baseDEX.color = Color.red;
            baseParamDEX = 0;

            baseVIT.text = "N/A";
            baseVIT.color = Color.red;
            baseParamVIT = 0;

            basePER.text = "N/A";
            basePER.color = Color.red;
            baseParamPER = 0;

            baseCHA.text = "N/A";
            baseCHA.color = Color.red;
            baseParamCHA = 0;
        }
        else
        {
            // Base Parameters
            // ------------------------------------
            baseParamSTR = int.Parse(LVL);
            baseSTR.text = baseParamSTR.ToString("N0");
            baseSTR.color = Color.white;

            baseParamAGI = int.Parse(LVL);
            baseAGI.text = baseParamAGI.ToString("N0");
            baseAGI.color = Color.white;

            baseParamDEX = int.Parse(LVL);
            baseDEX.text = baseParamDEX.ToString("N0");
            baseDEX.color = Color.white;

            baseParamVIT = int.Parse(LVL);
            baseVIT.text = baseParamVIT.ToString("N0");
            baseVIT.color = Color.white;

            baseParamPER = int.Parse(LVL);
            basePER.text = baseParamPER.ToString("N0");
            basePER.color = Color.white;

            baseParamCHA = int.Parse(LVL);
            baseCHA.text = baseParamCHA.ToString("N0");
            baseCHA.color = Color.white;

            // Stat Points
            // ------------------------------------
            int statPoints = (int.Parse(LVL) * 3) + 3;

            int currentlyInputtedStats = paramSTR + paramAGI + paramDEX + paramVIT + paramPER + paramCHA;

            if (currentlyInputtedStats > statPoints) // meaning surpassed max stat points for that level
            {
                resultStatPoints.text = "Not Enough Stat Points";
                resultStatPoints.color = Color.red;
            }
            else
            {
                int currentStats = statPoints - currentlyInputtedStats;
                resultStatPoints.text = currentStats.ToString("N0");
                resultStatPoints.color = Color.white;
            }

            // Max EXP
            // ------------------------------------
            int maxEXP = 0;

            if (int.Parse(LVL) == 1)
            {
                maxEXP = 100;
            }
            else if (int.Parse(LVL) <= 0)
            {
                maxEXP = 0;
            }
            else
            {
                maxEXP = 100 * int.Parse(LVL) * (int.Parse(LVL) - 1) * ((int.Parse(LVL) / 5) + 1);
            }

            resultMaxEXP.text = maxEXP.ToString("N0");
            resultMaxEXP.color = Color.white;
        }

        // STR
        // ---------------------------------------------------
        string STR = inputSTR.text;

        if (string.IsNullOrWhiteSpace(STR))
        {
            paramSTR = 0;
            int modSTR = (int)Mathf.Round((float)baseParamSTR / 5);
            blockVal = 12 + modSTR;
            deflectVal = 10 + modSTR;
            reflectVal = 6 + modSTR;
            unarmedVal = ((baseParamSTR + paramSTR) * 5);

            if (modSTR < 0)
            {
                modResultSTR.text = "Mod: " + modSTR;
                block.text = blockVal.ToString("N0");
                deflect.text = deflectVal.ToString("N0");
                reflect.text = reflectVal.ToString("N0");

                unarmed.text = unarmedVal.ToString("N0");
            }
            else
            {
                modResultSTR.text = "Mod: +" + modSTR;
                block.text = blockVal.ToString("N0");
                deflect.text = deflectVal.ToString("N0");
                reflect.text = reflectVal.ToString("N0");

                unarmed.text = unarmedVal.ToString("N0");
            }
        }
        else 
        {
            paramSTR = int.Parse(STR);
            int modSTR = (int)Mathf.Round((baseParamSTR+float.Parse(STR)) / 5);
            blockVal = 12 + modSTR;
            deflectVal = 10 + modSTR;
            reflectVal = 6 + modSTR;

            if (paramSTR < 0)
            {
                paramSTR = 0;
                inputSTR.text = "0";
            }

            unarmedVal = ((baseParamSTR + paramSTR) * 5);

            if (modSTR < 0)
            {
                modResultSTR.text = "Mod: " + modSTR;
                block.text = blockVal.ToString("N0");
                deflect.text = deflectVal.ToString("N0");
                reflect.text = reflectVal.ToString("N0");

                unarmed.text = unarmedVal.ToString("N0");
            }
            else
            {
                modResultSTR.text = "Mod: +" + modSTR;
                block.text = blockVal.ToString("N0");
                deflect.text = deflectVal.ToString("N0");
                reflect.text = reflectVal.ToString("N0");

                unarmed.text = unarmedVal.ToString("N0");
            }
        }

        // AGI
        // ---------------------------------------------------
        string AGI = inputAGI.text;

        if (string.IsNullOrWhiteSpace(AGI))
        {
            paramAGI = 0;
            int modAGI = (int)Mathf.Round((float)baseParamAGI / 5);
            grazeVal = 14 + modAGI;
            dodgeVal = 10 + modAGI;
            counterVal = 8 + modAGI;

            if (modAGI < 0)
            {
                modResultAGI.text = "Mod: " + modAGI;
                graze.text = grazeVal.ToString("N0");
                dodge.text = dodgeVal.ToString("N0");
                counter.text = counterVal.ToString("N0");

                movementSpeed.text = "2";
                speedChargeSpeed.text = "20";
            }
            else
            {
                modResultAGI.text = "Mod: +" + modAGI;
                graze.text = grazeVal.ToString("N0");
                dodge.text = dodgeVal.ToString("N0");
                counter.text = counterVal.ToString("N0");

                movementSpeed.text = "2";
                speedChargeSpeed.text = "20";
            }
        }
        else
        {
            paramAGI = int.Parse(AGI);
            int modAGI = (int)Mathf.Round((baseParamAGI + float.Parse(AGI)) / 5);
            grazeVal = 14 + modAGI;
            dodgeVal = 10 + modAGI;
            counterVal = 8 + modAGI;

            if (paramAGI < 0)
            {
                paramAGI = 0;
                inputAGI.text = "0";
            }

            if (modAGI < 0)
            {
                modResultAGI.text = "Mod: " + modAGI;
                graze.text = grazeVal.ToString("N0");
                dodge.text = dodgeVal.ToString("N0");
                counter.text = counterVal.ToString("N0");

                movementSpeed.text = "2";
                if (paramAGI < 20)
                {
                    speedChargeSpeed.text = "20";
                }
                else
                {
                    speedChargeSpeed.text = paramAGI.ToString("N0");
                }
            }
            else
            {
                modResultAGI.text = "Mod: +" + modAGI;
                graze.text = grazeVal.ToString("N0");
                dodge.text = dodgeVal.ToString("N0");
                counter.text = counterVal.ToString("N0");

                movementSpeed.text = "2";
                if (paramAGI < 20)
                {
                    speedChargeSpeed.text = "20";
                }
                else
                {
                    speedChargeSpeed.text = paramAGI.ToString("N0");
                }
            }
        }

        // DEX
        // ---------------------------------------------------
        string DEX = inputDEX.text;

        if (string.IsNullOrWhiteSpace(DEX))
        {
            paramDEX = 0;
            int modDEX = (int)Mathf.Round((float)baseParamDEX / 5);
            if (modDEX < 0)
            {
                modResultDEX.text = "Mod: " + modDEX;
            }
            else
            {
                modResultDEX.text = "Mod: +" + modDEX;
            }
        }
        else
        {
            paramDEX = int.Parse(DEX);
            int modDEX = (int)Mathf.Round((baseParamDEX + float.Parse(DEX)) / 5);

            if (paramDEX < 0)
            {
                paramDEX = 0;
                inputDEX.text = "0";
            }

            if (modDEX < 0)
            {
                modResultDEX.text = "Mod: " + modDEX;
            }
            else
            {
                modResultDEX.text = "Mod: +" + modDEX;
            }
        }

        // VIT
        // ---------------------------------------------------
        string VIT = inputVIT.text;

        if (string.IsNullOrWhiteSpace(VIT))
        {
            paramVIT = 0;
            int modVIT = (int)Mathf.Round((float)baseParamVIT / 5);
            if (modVIT < 0)
            {
                modResultVIT.text = "Mod: " + modVIT;
            }
            else
            {
                modResultVIT.text = "Mod: +" + modVIT;
            }
        }
        else
        {
            paramVIT = int.Parse(VIT);
            int modVIT = (int)Mathf.Round((baseParamVIT + float.Parse(VIT)) / 5);

            if (paramVIT < 0)
            {
                paramVIT = 0;
                inputVIT.text = "0";
            }

            if (modVIT < 0)
            {
                modResultVIT.text = "Mod: " + modVIT;
            }
            else
            {
                modResultVIT.text = "Mod: +" + modVIT;
            }
        }

        // HP
        // ---------------------------------------------------
        int HP = ((baseParamVIT + paramVIT) * 150) + 100;
        resultHP.text = HP.ToString("N0");

        // Air
        // ---------------------------------------------------
        int Air = ((baseParamVIT + paramVIT) * 10) + 100;
        resultAir.text = Air.ToString("N0");

        // PER
        // ---------------------------------------------------
        string PER = inputPER.text;

        if (string.IsNullOrWhiteSpace(PER))
        {
            paramPER = 0;
            int modPER = (int)Mathf.Round((float)baseParamPER / 5);

            if (modPER < 0)
            {
                modResultPER.text = "Mod: " + modPER;
            }
            else
            {
                modResultPER.text = "Mod: +" + modPER;
            }
        }
        else
        {
            paramPER = int.Parse(PER);
            int modPER = (int)Mathf.Round((baseParamPER + float.Parse(PER)) / 5);

            if (paramPER < 0)
            {
                paramPER = 0;
                inputPER.text = "0";
            }

            if (modPER < 0)
            {
                modResultPER.text = "Mod: " + modPER;
            }
            else
            {
                modResultPER.text = "Mod: +" + modPER;
            }
        }

        // CHA
        // ---------------------------------------------------
        string CHA = inputCHA.text;

        if (string.IsNullOrWhiteSpace(CHA))
        {
            paramCHA = 0;
            int modCHA = (int)Mathf.Round((float)baseParamCHA / 5);
            if (modCHA < 0)
            {
                modResultCHA.text = "Mod: " + modCHA;
            }
            else
            {
                modResultCHA.text = "Mod: +" + modCHA;
            }
        }
        else
        {
            paramCHA = int.Parse(CHA);
            int modCHA = (int)Mathf.Round((baseParamCHA + float.Parse(CHA)) / 5);

            if (paramCHA < 0)
            {
                paramCHA = 0;
                inputCHA.text = "0";
            }

            if (modCHA < 0)
            {
                modResultCHA.text = "Mod: " + modCHA;
            }
            else
            {
                modResultCHA.text = "Mod: +" + modCHA;
            }
        }
    }
}

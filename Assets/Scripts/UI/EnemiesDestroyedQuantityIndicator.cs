using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemiesDestroyedQuantityIndicator : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    public void SetNewEnemiesDestoedCount(int newValue)
    {
        _text.text = newValue.ToString();
    }
}

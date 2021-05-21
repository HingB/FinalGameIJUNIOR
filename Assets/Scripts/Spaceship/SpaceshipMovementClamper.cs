using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipMovementClamper : MonoBehaviour
{
    [SerializeField] private Vector2 _maxPosition;
    [SerializeField] private Vector2 _minPosition;

    private void Update()
    {
        ClapmPosition();
    }

    private void ClapmPosition()
    {
        Vector2 position = transform.position;

        position.x = Mathf.Clamp(position.x, _minPosition.x, _maxPosition.x);
        position.y = Mathf.Clamp(position.y, _minPosition.y, _maxPosition.y);

        transform.position = position;
    }
}

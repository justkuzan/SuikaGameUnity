using System;
using UnityEngine;

public class ZoneDetector : MonoBehaviour
{
    public enum ZoneType {GameOver, Warning}

    [SerializeField] private ZoneType zoneType;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Flower"))
        {
            SendSignal(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Flower"))
        {
            SendSignal(false);
        }
    }

    private void SendSignal(bool isInZone)
    {
        if (zoneType == ZoneType.GameOver)
        {
            GameEvents.OnZoneStatusChanged?.Invoke(isInZone);
        }
        else if (zoneType == ZoneType.Warning)
        {
            GameEvents.OnWarningZoneStatusChanged?.Invoke(isInZone);
        }
    }
}

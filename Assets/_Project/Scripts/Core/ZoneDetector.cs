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
        switch (zoneType)
        {
            case ZoneType.GameOver:
                GameEvents.OnZoneStatusChanged?.Invoke(isInZone);
                break;
            case ZoneType.Warning:
                GameEvents.OnWarningZoneStatusChanged?.Invoke(isInZone);
                break;
        }
    }
}

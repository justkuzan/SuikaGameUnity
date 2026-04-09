using UnityEngine;

public class Flower : MonoBehaviour
{
    public SpriteRenderer flowerSprite;
    public CircleCollider2D flowerCollider;
    public int FlowerLevel => _data.flowerLevel;
    
    private FlowerData _data;

    public void SetData(FlowerData data)
    {
        _data = data;
        
        flowerSprite.sprite = _data.flowerSprite;
        flowerCollider.radius = _data.colliderRadius;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.TryGetComponent<Flower>(out Flower other);
        if (other != null)
        {
            if (other.FlowerLevel != FlowerLevel) return;

            if (this.gameObject.GetInstanceID() < other.gameObject.GetInstanceID())
            {
                GameEvents.OnFlowersCollided?.Invoke(_data.nextLevelData, collision.GetContact(0).point);
                Destroy(this.gameObject);
                Destroy(other.gameObject);
            }
        }
    }
}

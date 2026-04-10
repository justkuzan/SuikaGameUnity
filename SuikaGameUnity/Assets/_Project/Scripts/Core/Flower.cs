using UnityEngine;

public class Flower : MonoBehaviour
{
    public SpriteRenderer flowerSprite;
    public CircleCollider2D flowerCollider;
    public Rigidbody2D flowerRB;
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
        if (flowerRB.bodyType != RigidbodyType2D.Dynamic) return;
        
        collision.gameObject.TryGetComponent<Flower>(out Flower other);
        if (other != null)
        {   
            if (other.FlowerLevel != FlowerLevel) return;

            if (this.gameObject.GetInstanceID() < other.gameObject.GetInstanceID())
            {
                GameEvents.OnFlowersCollided?.Invoke(_data, _data.nextLevelData, collision.GetContact(0).point);
                Destroy(this.gameObject);
                Destroy(other.gameObject);
            }
        }
    }
    
    public void SetPhysics(bool isPassive)
    {
        if (isPassive)
        {
            flowerRB.bodyType = RigidbodyType2D.Kinematic;
             gameObject.layer = LayerMask.NameToLayer("FlowerPreview");
        }
        else
        {
            flowerRB.bodyType = RigidbodyType2D.Dynamic;
            gameObject.layer = LayerMask.NameToLayer("Flower");
        }
    }
}

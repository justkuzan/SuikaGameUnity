using UnityEngine;

public class Flower : MonoBehaviour
{
    public SpriteRenderer flowerSprite;
    public CircleCollider2D flowerCollider;
    public Rigidbody2D flowerRB;
    private FlowerData _data;
    private bool _isMerging = false;
    public int FlowerLevel => _data.flowerLevel;
    public bool IsMerging => _isMerging;
    

    public void SetData(FlowerData data)
    {
        _data = data;
        
        flowerSprite.sprite = _data.flowerSprite;
        flowerCollider.radius = _data.colliderRadius;
        flowerRB.mass = _data.flowerMass;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (flowerRB.bodyType != RigidbodyType2D.Dynamic || _isMerging) return;

        if (collision.gameObject.TryGetComponent<Flower>(out Flower other))
        {
            if (other.FlowerLevel != FlowerLevel || other.IsMerging) return;
            {   
                if (other.FlowerLevel != FlowerLevel) return;

                if (this.gameObject.GetEntityId() < other.gameObject.GetEntityId())
                {
                    _isMerging = true;
                    other.SetMergingStatus(true); 
                    
                    GameEvents.OnFlowersCollided?.Invoke(_data, _data.nextLevelData, collision.GetContact(0).point);
                    Destroy(this.gameObject);
                    Destroy(other.gameObject);
                }
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
    
    public void SetMergingStatus(bool status) 
    {
        _isMerging = status;
    }
}

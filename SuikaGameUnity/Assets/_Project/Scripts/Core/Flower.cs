using UnityEngine;

public class Flower : MonoBehaviour
{
    public SpriteRenderer flowerSprite;
    public CircleCollider2D flowerCollider;
    public int flowerLevel;

    public void SetData(FlowerData data)
    {
        flowerSprite.sprite = data.flowerSprite;
        flowerCollider.radius = data.colliderRadius;
        flowerLevel = data.flowerLevel;
    }
}

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
    
    // private void OnCollisionEnter2D(Collision2D collision)
    // {
    //     if (collision.gameObject.TryGetComponent(out Flower otherFlower))
    //     {
    //         if (otherFlower.flowerLevel == this.flowerLevel)
    //         {
    //             // Чтобы не сработало дважды, мерджит только тот, у кого ID объекта меньше
    //             if (this.gameObject.GetInstanceID() < otherFlower.gameObject.GetInstanceID())
    //             {
    //                 // Вызываем событие мерджа через SignalBus
    //                 // GameEvents.OnMerge?.Invoke(this.data.nextLevelData, collision.contacts[0].point);
    //                 Destroy(this.gameObject);
    //                 Destroy(otherFlower.gameObject);
    //             }
    //         }
    //     }
    // }
}

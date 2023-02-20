using Unity.Entities;
using UnityEngine;
using Unity.Mathematics;

public class PlayerInputData : MonoBehaviour , IConvertGameObjectToEntity
{
    public float speed;
    public MonoBehaviour shootAction;
    public MonoBehaviour jumpAction;

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        dstManager.AddComponentData(entity, new InputData());
        dstManager.AddComponentData(entity, new MoveData() { Speed = speed / 100 });

        if (shootAction != null && shootAction is IShoot)
        {
            dstManager.AddComponentData(entity, new ShootData());
        }
        if (jumpAction != null && shootAction is IJump)
        {
            dstManager.AddComponentData(entity, new JunpData());
        }
    }
}

public struct InputData : IComponentData
{
    public float2 move;
    public float shoot;
    public float jump;
}

public struct MoveData : IComponentData
{
    public float Speed;
}

public struct ShootData : IComponentData
{

}

public struct JunpData : IComponentData
{

}
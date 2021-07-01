using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public class FollowEntity : MonoBehaviour
{
    public Entity entityToFollow;
    public float3 offSet = float3.zero;

    private EntityManager manager;

    private void Awake()
    {
        manager = World.DefaultGameObjectInjectionWorld.EntityManager;
    }

    private void LateUpdate()
    {
        if(entityToFollow == null) { return; }

        Translation trans = manager.GetComponentData<Translation>(entityToFollow);
        transform.position = trans.Value + offSet;
    }
}

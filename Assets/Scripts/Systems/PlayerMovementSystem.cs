using Unity.Mathematics;
using Unity.Entities;
using Unity.Transforms;
using Unity.Jobs;
using Unity.Physics;
using Unity.Physics.Systems;
using UnityEngine;

class PlayerMovementSystem : SystemBase
{

    protected override void OnUpdate()
    {
        Entities.ForEach((ref PhysicsVelocity velocity,ref Rotation rotation,in MoveData moveData) =>
        {
            
            float w = Quaternion.identity.w;
            rotation.Value = new Quaternion(0f,0f,0f,w);
            
            if(moveData.rightKey == true)
            {
                velocity.Linear = new float3(1f * moveData.speed, 0f, 0f);
            }
            else if(moveData.leftKey == true)
            {
                velocity.Linear = new float3(-1f * moveData.speed, 0f, 0f);
            }
            else if (moveData.upKey == true)
            {
                velocity.Linear = new float3(0f, 0f, 1f * moveData.speed);
            }
            else if (moveData.backKey == true)
            {
                velocity.Linear = new float3(0f, 0f, -1f * moveData.speed);
            }
          
        }).Schedule();
    }
  
}

using Unity.Entities;
using Unity.Jobs;
using UnityEngine;
using Unity.Physics.Systems;
using Unity.Physics;
using Unity.Burst;
using Unity.Collections;
using System;
[UpdateAfter(typeof(WaitForEndOfFrame))]
public class CollisionTrigger : JobComponentSystem
{
    BuildPhysicsWorld buildPhysicsWorld;
    StepPhysicsWorld stepPhysicsWorld;
    public EntityManager entityManager = new EntityManager();
    EndSimulationEntityCommandBufferSystem endSimulationEntityCommandBufferSystem;

    CollisionDetect colliosn;

    protected override void OnCreate()
    {
        entityManager = new EntityManager();
        buildPhysicsWorld = World.GetOrCreateSystem<BuildPhysicsWorld>();
        stepPhysicsWorld = World.GetOrCreateSystem<StepPhysicsWorld>();

        entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
        endSimulationEntityCommandBufferSystem = World.GetExistingSystem<EndSimulationEntityCommandBufferSystem>();

       

        //colliosn.Collided += IfColided;
    }

    [BurstCompile]
    private struct CollisionDetect : ICollisionEventsJob
    {
        public ComponentDataFromEntity<PhysicsVelocity> physicsVelocity;
        [ReadOnly] public ComponentDataFromEntity<FoodTag> foodTag;
        [ReadOnly] public ComponentDataFromEntity<PlayerTag> playerTag;
        
        Entity entityA;
        Entity entityB ;
        
        public void Execute(CollisionEvent collisionEvent)
        {
            entityA = collisionEvent.EntityA;
             entityB = collisionEvent.EntityB;


            //if (foodTag.Exists(entityA) && foodTag.Exists(entityB))
            //{
            //    Debug.Log("Collide with Something Same");
            //    return;
            //}
            
            if (foodTag.Exists(entityA) && playerTag.Exists(entityB))
            {
           // Debug.Log("Food Entity : " + entityA + "Collide With Player " + entityB);

                DestroyEntity.GetEntity(entityA);
                DestroyEntity.entityDestroy = true;
                
            }
            else if (playerTag.Exists(entityA) && foodTag.Exists(entityB))
            {
                // Debug.Log("Player Entity : " + entityA + "Collide With Food " + entityB);
                DestroyEntity.GetEntity(entityB);
                DestroyEntity.entityDestroy = true;

            }

        }

    }


    //protected override JobHandle OnUpdate(JobHandle inputDeps)
    //{
    //    CollisionDetect colliosn = new CollisionDetect();
    //    //colliosn.
    //    //var ecb = endSimulationEntityCommandBufferSystem.CreateCommandBuffer().ToConcurrent();
    //    JobHandle jobHandle = new CollisionDetect
    //    {
    //        physicsVelocity = GetComponentDataFromEntity<PhysicsVelocity>(),
    //        foodTag = GetComponentDataFromEntity<FoodTag>(true),
    //        playerTag = GetComponentDataFromEntity<PlayerTag>(true),


    //    }.Schedule(stepPhysicsWorld.Simulation, ref buildPhysicsWorld.PhysicsWorld, inputDeps);
    //    endSimulationEntityCommandBufferSystem.AddJobHandleForProducer(inputDeps);
    //    return jobHandle;
    //}




    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
         colliosn = new CollisionDetect
        {
            physicsVelocity = GetComponentDataFromEntity<PhysicsVelocity>(),
            foodTag = GetComponentDataFromEntity<FoodTag>(true),
            playerTag = GetComponentDataFromEntity<PlayerTag>(true),


        };

        //var ecb = endSimulationEntityCommandBufferSystem.CreateCommandBuffer().ToConcurrent();
        JobHandle jobHandle = colliosn.Schedule(stepPhysicsWorld.Simulation, ref buildPhysicsWorld.PhysicsWorld, inputDeps);
        
        endSimulationEntityCommandBufferSystem.AddJobHandleForProducer(inputDeps);
        return jobHandle;
    }

   
}


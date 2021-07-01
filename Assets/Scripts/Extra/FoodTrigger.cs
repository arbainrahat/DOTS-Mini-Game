//using Unity.Physics.Systems;
//using Unity.Burst;
//using Unity.Entities;
//using Unity.Jobs;
//using Unity.Physics;
//using Unity.Collections;
//using UnityEngine;

//[UpdateAfter(typeof(EndFramePhysicsSystem))]
//public class FoodTrigger : JobComponentSystem
//{
    

//    [BurstCompile]
//    struct CollisionEventJob : ITriggerEventsJob
//    {
//        //public ComponentDataFromEntity<PhysicsVelocity> phsicsVelocityEntity;

//      [ReadOnly] public ComponentDataFromEntity<FoodTag> foodTag;
//      [ReadOnly]  public ComponentDataFromEntity<PlayerTag> playerTag;

//        public void Execute(TriggerEvent triggerEvent)
//        {
//            Entity entityA = triggerEvent.EntityA;
//            Entity entityB = triggerEvent.EntityB;
            
            

//            if (foodTag.Exists(entityA) && foodTag.Exists(entityB))
//            {
//                return;
//            }

//            if (foodTag.Exists(entityA) && playerTag.Exists(entityB))
//            {
//                Debug.Log("Food Entity : " + entityA + "Collide With Player " + entityB );
                
//            }
//            else if(playerTag.Exists(entityA) && foodTag.Exists(entityB))
//            {
//               Debug.Log("Player Entity : " + entityA + "Collide With Food " + entityB);
                
//                DestroyEntity.entityDestroy = true;
//                DestroyEntity.GetEntity(entityB);
//            }


            


//            //if (phsicsVelocityEntity.HasComponent(triggerEvent.EntityA))
//            //{
//            //    UnityEngine.Debug.Log("Entity A is " + triggerEvent.EntityA + "Trigger");
//            //}
//            //if (phsicsVelocityEntity.HasComponent(triggerEvent.EntityB))
//            //{
//            //    UnityEngine.Debug.Log("Entity B is " + triggerEvent.EntityB + "Trigger");
//            //}

//        }

       
//    }

//    private BuildPhysicsWorld buildPhysicsWorld;
//    private StepPhysicsWorld stepPhysicsWorld;

//    protected override void OnCreate()
//    {
//        buildPhysicsWorld = World.GetOrCreateSystem<BuildPhysicsWorld>();
//        stepPhysicsWorld = World.GetOrCreateSystem<StepPhysicsWorld>();

       
//    }

//    protected override JobHandle OnUpdate(JobHandle inputDep)
//    {
//        CollisionEventJob collisionEventJob = new CollisionEventJob();
        
//          collisionEventJob.foodTag = GetComponentDataFromEntity<FoodTag>(true);
//          collisionEventJob.playerTag = GetComponentDataFromEntity<PlayerTag>(true);

    

//        return collisionEventJob.Schedule(stepPhysicsWorld.Simulation, ref buildPhysicsWorld.PhysicsWorld, inputDep);
//    }




//}

using Unity.Entities;
using Unity.Jobs;
using Unity.Transforms;
using UnityEngine;





    public class EntitySpwanerSystem : SystemBase
    {

        private float spwanTimer = 2.5f;


        EndSimulationEntityCommandBufferSystem endSimulationEntityCommandBufferSystem;

        protected override void OnCreate()
        {
            endSimulationEntityCommandBufferSystem = World.GetExistingSystem<EndSimulationEntityCommandBufferSystem>();
        }

        protected override void OnUpdate()
        {

        float posX = Random.Range(-40f, 40f);
        float posZ = Random.Range(-40f, 40f);
        
        spwanTimer -= Time.DeltaTime;

            var ecb = endSimulationEntityCommandBufferSystem.CreateCommandBuffer().ToConcurrent();


          if (spwanTimer > 0)
          {
            Entities.ForEach((int entityInQueryIndex, in EntityPrefabData entityPrefab) =>
            {
                
                Entity spwan = ecb.Instantiate(entityInQueryIndex, entityPrefab.prefabEntity);

                ecb.SetComponent(entityInQueryIndex, spwan, new Translation { Value = new Unity.Mathematics.float3(posX, 0.5f, posZ) });



                // EntityManager.SetComponentData(spwan, new Translation { Value = new Unity.Mathematics.float3(posX, 0.5f, posZ) }); 
                // EntityManager.Instantiate(entityPrefab.prefabEntity);


            }).ScheduleParallel();
          }
            endSimulationEntityCommandBufferSystem.AddJobHandleForProducer(this.Dependency);

        }

    }

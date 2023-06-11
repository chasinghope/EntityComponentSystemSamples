using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using UnityEngine;

[UpdateInGroup(typeof(TestSystemGroup))]
public partial struct TestCubeSpawnerSystem : ISystem
{
    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        EntityCommandBuffer ecb = new EntityCommandBuffer(Allocator.TempJob);



        foreach (var (cubePrefab, prefab) in SystemAPI.Query<EnabledRefRW<Test_CubePrefab>, RefRO<Test_CubePrefab>>())
        {
            //new TestCubeSpawnerJob
            //{
            //    Count = 3,
            //    ecb = ecb,
            //}.Schedule(state.Dependency);

            for (int i = 0; i < 4; i++)
            {
                Entity e = ecb.Instantiate(prefab.ValueRO.CubePrefab);
                ecb.AddComponent(e, new Test_CC { Value = -10f, dir = 1 });
            }



            cubePrefab.ValueRW = !cubePrefab.ValueRO;
            Debug.Log("aaaa");
        }

        state.Dependency.Complete();
        ecb.Playback(state.EntityManager);
        ecb.Dispose();
    }


}


//[BurstCompile]
//public partial struct TestCubeSpawnerJob : IJobEntity
//{
//    public int Count;
//    public EntityCommandBuffer ecb;
//    [BurstCompile]
//    public void Execute(TestCubeSpawnAspect testCubeSpawnAspect)
//    {
//        for (int i = 0; i < Count; i++)
//        {
//            Entity e = ecb.CreateEntity();
//            ecb.AddComponent(e, new Test_CC { Value = -10f, dir = 1 });
//        }
//    }
//}


using Unity.Burst;
using Unity.Entities;


[UpdateInGroup(typeof(TestSystemGroup))]
public partial struct TesCC_System : ISystem
{
    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        float deltaTime =  SystemAPI.Time.DeltaTime;

        bool hasTestAA = SystemAPI.TryGetSingleton<Test_AA>(out Test_AA testAA);
        if (hasTestAA)
        {
            new TestCC_Job
            {
                Speed = testAA.Value,
                DeltaTime = deltaTime,
            }.ScheduleParallel();
        }
    }
}


[BurstCompile]
public partial struct TestCC_Job : IJobEntity
{
    public float Speed;
    public float DeltaTime;

    [BurstCompile]
    public void Execute(ref Test_CC testCC)
    {
        if(testCC.Value > 100)
        {
            testCC.dir *= -1;
        }
        else if (testCC.Value < 0)
        {
            testCC.dir *= -1;
        }

        testCC.Value = testCC.Value + testCC.dir * Speed * DeltaTime;
    }
}
using Unity.Entities;
using UnityEngine;
using Unity.Physics;


class PlayerInputSystem : SystemBase
{

    public string directionBtn;
    bool isRightKeyPressed;

    protected override void OnUpdate()
    {
        float deltaTime = Time.DeltaTime;
        

        Entities.ForEach((ref PhysicsVelocity velocity, ref MoveData moveData, in InputData inputData) =>
        {
            //bool isRightKeyPressed = false;
            //bool isLeftKeyPressed = false;
            //bool isUpKeyPressed = false;
            //bool isDownKeyPressed = false;
            moveData.rightKey = false;
            moveData.leftKey = false;
            moveData.upKey = false;
            moveData.backKey = false;

            if (Input.GetKey(inputData.rightKey))
            {
                //isRightKeyPressed = true;
                moveData.rightKey = true;
            }
            else if (Input.GetKey(inputData.leftKey))
            {
                moveData.leftKey = true;
               // isLeftKeyPressed = true;
            }
            else if (Input.GetKey(inputData.upKey))
            {
                //isUpKeyPressed = true;
                moveData.upKey = true;
            }
            else if (Input.GetKey(inputData.downKey))
            {
                // isDownKeyPressed = true;
                moveData.backKey = true;
            }




            //if (isRightKeyPressed == true)
            //{
            //    moveData.rightKey = true;
            //}
            //else
            //{
            //    moveData.rightKey = false; 
            //}

            //if (isLeftKeyPressed)
            //{
            //    moveData.leftKey = true;
            //}
            //else
            //{
            //    moveData.leftKey = false;
            //}

            //if (isUpKeyPressed)
            //{
            //    moveData.upKey = true;
            //}
            //else
            //{
            //    moveData.upKey = false;
            //}

            //if (isDownKeyPressed)
            //{
            //    moveData.backKey = true;
            //}
            //else
            //{
            //    moveData.backKey = false;
            //}

        }).Run();
    }
   
}
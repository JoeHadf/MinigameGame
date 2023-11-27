using UnityEditor.SceneTemplate;
using UnityEngine;

namespace Games
{
    public class SquareTheCircle : Game
    {
        private GameObject circlePrefab;
        private GameObject squarePrefab;
        
        private SquareBehaviour[] squareBehaviours;

        public SquareTheCircle() : base(GameName.SquareTheCircle)
        {
            circlePrefab = Resources.Load("Games/SquareTheCircle/Circle", typeof(GameObject)) as GameObject;
            squarePrefab = Resources.Load("Games/SquareTheCircle/Square", typeof(GameObject)) as GameObject;
        }

        protected override void SetUpEasy()
        {
            int squareCount = 1;
            SpawnObjects(squareCount,out SquareBehaviour[] behaviours);
            squareBehaviours = behaviours;
        }

        protected override void SetUpMedium()
        {
            int squareCount = 2;
            SpawnObjects(squareCount,out SquareBehaviour[] behaviours);
            squareBehaviours = behaviours;
        }

        protected override void SetUpHard()
        {
            int squareCount = 3;
            SpawnObjects(squareCount,out SquareBehaviour[] behaviours);
            squareBehaviours = behaviours;
        }

        private void SpawnObjects(int squareCount, out SquareBehaviour[] behaviours)
        {
            SpawnCircle();
            behaviours = SpawnSquares(squareCount);
        }

        private void SpawnCircle()
        {
            Vector3 circlePos = ScreenSpaceCalculator.GetRandomPosition();
            objectSpawner.Spawn(circlePrefab, circlePos);
        }

        private SquareBehaviour[] SpawnSquares(int squareCount)
        {
            SquareBehaviour[] behaviours = new SquareBehaviour[squareCount];

            for (int i = 0; i < squareCount; i++)
            {
                behaviours[i] = SpawnSquare();
            }

            return behaviours;
        }

        private SquareBehaviour SpawnSquare()
        {
            Vector3 squarePos = ScreenSpaceCalculator.GetRandomPosition();
            GameObject square = objectSpawner.Spawn(squarePrefab, squarePos);
            return square.GetComponent<SquareBehaviour>();
        } 

        public override bool IsSuccess()
        {
            foreach (var currentBehaviour in squareBehaviours)
            {
                if (!currentBehaviour.isHit)
                {
                    return false;
                }
            }

            return true;
        }
    }
}

using UnityEditor.SceneTemplate;
using UnityEngine;

namespace Games
{
    public class SquareTheCircle : Game
    {
        private GameObject circle;
        private GameObject square;
        
        public SquareTheCircle(GameObject parent) : base(GameType.Regular, GameName.SquareTheCircle, parent)
        {
        
        }

        public override void SetUpGame()
        {
            Vector2 Bounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
            float minX = -Bounds.x;
            float maxX = Bounds.x;
            float minY = -Bounds.y;
            float maxY = Bounds.y;

            float circleX = Random.Range(minX, maxX);
            float circleY = Random.Range(minY, maxY);
            Vector3 circlePos = new Vector3(circleX, circleY, 0);
            
;           float squareX = Random.Range(minX, maxX);
            float squareY = Random.Range(minY, maxY);
            Vector3 squarePos = new Vector3(squareX, squareY, 0);
            
            GameObject circlePrefab = Resources.Load("Games/SquareTheCircle/Circle", typeof(GameObject)) as GameObject;
            circle = GameObject.Instantiate(circlePrefab, circlePos, Quaternion.identity, objectsParent.transform);
            
            GameObject squarePrefab = Resources.Load("Games/SquareTheCircle/Square", typeof(GameObject)) as GameObject;
            square = GameObject.Instantiate(squarePrefab, squarePos, Quaternion.identity, objectsParent.transform);
        }

        public override GameSuccessState GetSuccessState()
        {
            Collider2D circleCollider = circle.GetComponent<Collider2D>();
            Collider2D squareCollider = square.GetComponent<Collider2D>();

            if (circleCollider.IsTouching(squareCollider))
            {
                return GameSuccessState.Success;
            }
            else
            {
                return GameSuccessState.Failure;
            }
        }
    }
}

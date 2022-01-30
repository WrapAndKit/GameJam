using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using UnityEngine;

namespace Assets.Scripts.Additional
{
    public class BatMovementStrategy: IStrategy
    {
        private Rigidbody2D rb;
        private Collider2D coll;
        private float direction = 1.0f;
        public float speed = 1f;
        private LayerMask walls = LayerMask.GetMask("Walls");

        public BatMovementStrategy(GameObject bat)
        {
            rb = bat.GetComponent<Rigidbody2D>();
            coll = bat.GetComponent<Collider2D>();
        }

        private int times = 0;
        public void Execute(float deltaTime)
        {
            if (coll.IsTouchingLayers(walls) && times > 3)
            {
                direction *= -1f;
                times = 0;
            }
            else
            {
                times += 1;
            }
            Vector2 move = rb.position;
            move.y += direction * speed * deltaTime;
            rb.MovePosition(move);  
        }
    }

    public class SkeletonMovementStrategy: IStrategy
    {
        private GameObject skeleton;
        private Rigidbody2D rb;
        private Collider2D coll;
        private float direction = 1.0f;
        public float speed = 1f;
        private LayerMask walls = LayerMask.GetMask("Walls");

        public SkeletonMovementStrategy(GameObject _skeleton)
        {
            skeleton = _skeleton;
            rb = skeleton.GetComponent<Rigidbody2D>();
            coll = skeleton.GetComponent<Collider2D>();
        }

        private int times = 0;
        public void Execute(float deltaTime)
        {
            if (coll.IsTouchingLayers(walls) && times > 3)
            {
                direction *= -1f;
                times = 0;
            }
            else
            {
                times += 1;
            }
            Vector2 move = rb.position;            
            move.x += direction * speed * deltaTime;
            
            rb.MovePosition(move);
        }
    }

    public class SkeletonLazyStrategy : IStrategy 
    {
        private string[] speeches = new string[] { 
            "Привет", 
            "Проверка"
        };
        private static System.Random ramdomizer = new System.Random();
        private float speechRange = 10f;
        private float timeFromLastSpeech = 0f;
        public void Execute(float deltaTime)
        {
            if(timeFromLastSpeech >= speechRange)
            {
                var index = ramdomizer.Next(0, speeches.Length);
                Debug.Log(speeches[index]);
                timeFromLastSpeech = 0f;
            }
            else
            {
                timeFromLastSpeech += deltaTime;
            }
        }
    }

}

using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace CGeers.Silverlight.GameEngine
{
    public class CollisionManager
    {
        private static Dictionary<Type, List<Type>> _collisionMap = 
            new Dictionary<Type, List<Type>>();

        #region Singleton Pattern

        // Static members are lazily initialized.
        // .NET guarantees thread safety for static initialization.
        private readonly static CollisionManager _instance = 
            new CollisionManager();

        // Make the constructor private to hide it. 
        // This class adheres to the singleton pattern.
        private CollisionManager()
        { }

        /// <summary>
        /// Return the single instance of the CollisionManager type.
        /// </summary>
        /// <returns>CollisionManager</returns> 
        public static CollisionManager GetInstance()
        {
            return _instance;
        }

        #endregion

        private static void AddToCollissionMap(Type target, Type projectile)
        {
            if (!_collisionMap.ContainsKey(target))
            {
                _collisionMap.Add(target, new List<Type>());
            }
            if (!_collisionMap[target].Contains(projectile))
            {
                _collisionMap[target].Add(projectile);
            }
        }

        public static void Register<Target, Projectile>()
            where Target : Sprite
            where Projectile : Sprite
        {
            Type targetType = typeof(Target);
            Type projectileType = typeof(Projectile);

            AddToCollissionMap(targetType, projectileType);
            AddToCollissionMap(projectileType, targetType);
        }

        public void DetectCollisions()
        { 
            GameSurface surface = GameSurface.GetInstance();
            List<Sprite> sprites = new List<Sprite>(surface.Sprites);
            for (int i = 0; i < sprites.Count; i++)
            {
                Sprite projectile = sprites[i];

                for (int j = i + 1; j < sprites.Count; j++)
                {
                    Sprite target = sprites[j];

                    Type projectileType = projectile.GetType();
                    Type targetType = target.GetType();

                    bool checkForCollission = _collisionMap.ContainsKey(projectileType) &&
                                              _collisionMap[projectileType].Contains(targetType);

                    if (checkForCollission)
                    {
                        // Simple collision check
                        Sprite sprite = projectile as Sprite;
                        Rect rect1 = projectile.BoundsRect;
                        Rect rect2 = target.BoundsRect;
                        rect1.Intersect(rect2);

                        if (rect1 != Rect.Empty)
                        {
                            projectile.Collision(target);
                            target.Collision(projectile);
                        }
                    }
                }
            }           
        }
    }
}

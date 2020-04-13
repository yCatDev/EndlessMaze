﻿namespace CoreEngine
{
    public class GameObjectID
    {
       

        public override int GetHashCode()
        {
            return id;
        }

        private int id;

        public GameObjectID()
        {
            id = GameObjectIDsStore.GetNext();
        }

        public static bool operator ==(GameObjectID a, GameObjectID b) => a.id == b.id;
        public static bool operator !=(GameObjectID a, GameObjectID b) => a.id != b.id;
        
        protected bool Equals(GameObjectID other)
        {
            return id == other.id;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((GameObjectID) obj);
        }
    }

    public static class GameObjectIDsStore
    {
        private static int counter = 0;
        public static int GetNext() => counter++;
    }
}
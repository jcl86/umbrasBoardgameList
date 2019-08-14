using System;

namespace GameParser.Core
{
    public class Entity
    {
        private readonly int id;
        private readonly string name;

        public Entity(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public override bool Equals(object obj)
        {
            return obj is Entity entity &&
                   id == entity.id;
        }

        public override int GetHashCode() => HashCode.Combine(id);
        

        public override string ToString() => name;
    }
}

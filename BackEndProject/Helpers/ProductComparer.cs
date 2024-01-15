using BackEndProject.Entities;
using System.Diagnostics.CodeAnalysis;

namespace BackEndProject.Helpers
{
    public class ProductComparer : IEqualityComparer<Product>
    {
        public bool Equals(Product? x, Product? y)
        {
            if (x.Id == y.Id) return true;
            return false;
        }

        public int GetHashCode([DisallowNull] Product obj)
        {
            throw new NotImplementedException();
        }
    }
}

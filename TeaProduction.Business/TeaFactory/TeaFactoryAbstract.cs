namespace TeaProduction.Business.TeaFactory
{
    public abstract class TeaFactoryAbstract<T> where T : new()
    {
        public virtual void Produce(int countPackage)
        {
            // some default implementation
        }

        public virtual string? GetSpecialPropertiesOfTea()
        {
            return null;
        }
        public virtual string? GetTheLocationOfTeaFactory()
        {
            return null;
        }

        public virtual T GetTeaForReview()
        {
            return new T();
        }
    }
}

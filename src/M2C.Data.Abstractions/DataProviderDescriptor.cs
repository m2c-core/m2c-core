using System;
using System.Collections.Generic;
using System.Text;

namespace M2C.Data.Abstractions
{
    public class DataProviderDescriptor
    {

        public DataProviderDescriptor(
            Type modelType,
            Type dataProviderType,
            DataProviderLifetime lifetime)
            :this(modelType,dataProviderType)
        {
            if (modelType == null)
            {
                throw new ArgumentNullException(nameof(modelType));
            }

            if (dataProviderType == null)  
            {
                throw new ArgumentNullException(nameof(dataProviderType));
            }

            Lifetime = lifetime;
        }

        private DataProviderDescriptor(Type modelType, Type dataProviderType)
        {
            ModelType = modelType;
            DataProviderType = dataProviderType;
        }

        public DataProviderDescriptor()
        {

        }







        public Type ModelType { get; private set; }

        public Type DataProviderType { get; private set; }

        public DataProviderLifetime Lifetime { get; private set; }

        public object DataProviderInstance { get; set; }



        public static DataProviderDescriptor Describe(Type modelType, Type dataProviderType, DataProviderLifetime lifetime)
        {
            return new DataProviderDescriptor(modelType, dataProviderType, lifetime);
        }








    }
}

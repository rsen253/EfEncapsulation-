using StructureMap;
using System.Data.Entity;
using MvcSalesApp.Data;

namespace MvcSalesApp.Web.DependencyResolution {
    using StructureMap.Configuration.DSL;
    using StructureMap.Graph;
	
    public class DefaultRegistry : Registry {
        #region Constructors and Destructors

        public DefaultRegistry() {
            Scan(
                scan => {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
					scan.With(new ControllerConvention());
                });
            //For<IExample>().Use<Example>();

            For<DbContext>().Use<OrderSystemContext>().Transient();
        }

        #endregion
    }
}
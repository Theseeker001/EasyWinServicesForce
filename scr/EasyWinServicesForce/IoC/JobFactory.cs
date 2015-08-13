﻿namespace EasyWinServicesForce.IoC
{
    using System;
    using Autofac;

    using Quartz;
    using Quartz.Spi;

    internal class JobFactory : IJobFactory
    {
        private readonly IContainer _container;

        /// <summary>
        /// Initialises a new instance of the SampleJobFactory class.
        /// </summary>
        /// <param name="container">IoC container instance.</param>
        public JobFactory(IContainer container)
        {
            if (container == null)
                throw new ArgumentNullException("container");

            this._container = container;
        }

        /// <summary>
        /// Creates a new job resolved from the IoC container.
        /// </summary>
        /// <param name="bundle">Trigger fired bundle instance.</param>
        /// <param name="scheduler">Scheduler instance.</param>
        /// <returns>Returns a new job resolved from the IoC container.</returns>
        public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
        {
            if (bundle == null)
                throw new ArgumentNullException("bundle");

            return (IJob)this._container.Resolve(bundle.JobDetail.JobType); // #1
        }

        /// <summary>
        /// Allows the the job factory to destroy/cleanup the job if needed.
        /// </summary>
        /// <param name="job">Job instance.</param>
        public void ReturnJob(IJob job)
        {
        }
    }
}

// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefaultRegistry.cs" company="Web Advanced">
// Copyright 2012 Web Advanced (www.webadvanced.com)
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0

// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Reflection;
using AutoMapper;
using MediatR;
using StructureMap;
using StructureMap.Graph;
using StructureMap.Pipeline;
using WebAPI_Learning_1.Interfaces;
using WebAPI_Learning_1.Requests.Decorators;

namespace WebAPI_Learning_1.DependencyResolution
{
    public class DefaultRegistry : Registry
    {
        #region Constructors and Destructors

        public DefaultRegistry()
        {
            Scan(
                scan =>
                {
                    scan.TheCallingAssembly();
                    scan.AssemblyContainingType(typeof (LoggingHandler<,>));
                    scan.WithDefaultConventions();


                    scan.AddAllTypesOf(typeof (IRequestHandler<,>));
                    scan.AddAllTypesOf(typeof (IAsyncRequestHandler<,>));
                    scan.AddAllTypesOf(typeof (INotificationHandler<>));
                    scan.AddAllTypesOf(typeof (IAsyncNotificationHandler<>));

                    scan.AddAllTypesOf(typeof (IAuthorizer<>));

                    var handlerType = For(typeof (IRequestHandler<,>));
                    handlerType.DecorateAllWith(typeof (LoggingHandler<,>), DoesNotHaveAttribute(typeof (DoNotLog)));
                    handlerType.DecorateAllWith(typeof (AuthorizeHandler<,>), HasAttribute(typeof (Authorize)));

                    var asyncHandlerType = For(typeof (IAsyncRequestHandler<,>));
                    asyncHandlerType.DecorateAllWith(typeof (LoggingHandlerAsync<,>),
                        DoesNotHaveAttribute(typeof (DoNotLog)));
                    asyncHandlerType.DecorateAllWith(typeof (AuthorizeHandlerAsync<,>), HasAttribute(typeof (Authorize)));

                });

            For<SingleInstanceFactory>().Use<SingleInstanceFactory>(ctx => t => ctx.GetInstance(t));
            For<MultiInstanceFactory>().Use<MultiInstanceFactory>(ctx => t => ctx.GetAllInstances(t));
            For<IMediator>().Use<Mediator>();

            MappingConfig.Register();
            For<IMapper>().Use(_ => MappingConfig.Instance);
        }

        private static Func<Instance, bool> DoesNotHaveAttribute(Type attr)
        {
            return instance => !ContainsAttribute(attr, instance);
        }

        private static Func<Instance, bool> HasAttribute(Type attr)
        {
            return instance => ContainsAttribute(attr, instance);
        }

        private static bool ContainsAttribute(Type attr, Instance instance)
        {
            var type = instance.ReturnedType ?? instance.GetType();
            return type.GetCustomAttribute(attr, false) != null;
        }

        #endregion
    }
}
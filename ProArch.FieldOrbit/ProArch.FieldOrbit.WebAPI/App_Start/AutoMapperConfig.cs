﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using ProArch.FieldOrbit.WebAPI.App_Start.Profiles;

namespace ProArch.FieldOrbit.WebAPI.App_Start
{
    /// <summary>
    /// Configures mapping between view models, models.
    /// </summary>
    public static class AutoMapperConfig
    {
        /// <summary>
        /// Configures mapping between view models, domain models.
        /// </summary>
        public static void Configure()
        {
            Mapper.Initialize(a =>
            {
                var profileTypes = typeof(BaseProfile).Assembly.GetTypes().Where(type => type.IsSubclassOf(typeof(BaseProfile)));

                foreach (var type in profileTypes)
                {
                    a.AddProfile((BaseProfile)Activator.CreateInstance(type));
                }
            });
            Mapper.AssertConfigurationIsValid();
        }
    }
}
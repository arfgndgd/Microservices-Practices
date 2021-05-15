﻿// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace FreeCourse.IdentityServer
{
    public static class Config
    {
        //Aşağıdaki her ApiScopeu için bir Api kaynağı yaratıyoruz
        //bunu sonradan ekledik (Startup.cs içinde tanımlamak gerekiyor)
        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
            new ApiResource("resource_catalog"){Scopes={"catalog_fullpermission"}},
             new ApiResource("photo_stock_catalog"){Scopes={"photo_stock_fullpermission"}},
             new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
        };


        //bunlar birer get propertysidir 
        public static IEnumerable<IdentityResource> IdentityResources =>
                   new IdentityResource[]
                   {
                   };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("catalog_fullpermission","Catalog API için full erişim"),
                new ApiScope("photo_stock_fullpermission","Photo Stock için full erişim"),
                new ApiScope(IdentityServerConstants.LocalApi.ScopeName) //kendisine istek yapması
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client
                {
                    ClientName ="Asp.Net Core Mvc",
                    ClientId="WebMvcClient",
                    ClientSecrets = {new Secret("secret".Sha256())}, //şifre
                    AllowedGrantTypes = {GrantType.ClientCredentials}, //akış tipi
                    AllowedScopes = { "catalog_fullpermission", "photo_stock_fullpermission", IdentityServerConstants.LocalApi.ScopeName } //hangi scope istek yapabilir (ApiScope)
                    
                
                }
            };
    }
}
﻿// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using IdentityServer4;
using IdentityServer4.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace StsServerIdentity
{
    public class Config
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email()
            };
        }

        public static IEnumerable<ApiScope> GetApiScopes()
        {
            return new List<ApiScope>
            {
                new ApiScope("ScopeAspNetCoreODataServiceApi", "OData API AspNetCoreOData.Service")
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("AspNetCoreODataServiceApi")
                {
                    DisplayName = "OData API AspNetCoreOData.Service",
                    ApiSecrets =
                    {
                        new Secret("AspNetCoreODataServiceApiSecret".Sha256())
                    },
                    Scopes = { "ScopeAspNetCoreODataServiceApi"},
                    UserClaims = { "role", "admin", "user" }
                }
            };
        }

        public static IEnumerable<Client> GetClients(IConfigurationSection authConfigurations)
        {
            return new List<Client>
            {
                new Client
                {
                    ClientName = "AspNetCoreOData.Client",
                    ClientId = "AspNetCoreODataClient",
                    ClientSecrets = {new Secret("AspNetCoreODataClientSecret".Sha256()) },
                    AllowedGrantTypes = GrantTypes.Hybrid,
                    AllowOfflineAccess = true,
                    RequireConsent = true,
                    RequirePkce = false,
                    AccessTokenLifetime = 86400,
                    RedirectUris = {
                        "https://localhost:44388/signin-oidc"
                    },
                    PostLogoutRedirectUris = {
                        "https://localhost:44388/signout-callback-oidc"
                    },
                    AllowedCorsOrigins = new List<string>
                    {
                        "https://localhost:44388"
                    },
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.OfflineAccess,
                        "ScopeAspNetCoreODataServiceApi",
                        "role"
                    }
                }
            };
        }
    }
}
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.PowerShell.PSResourceGet.UtilClasses;

namespace Microsoft.PowerShell.PSResourceGet.Cmdlets
{
    internal class ResponseUtilFactory
    {
        public static ResponseUtil GetResponseUtil(PSRepositoryInfo repository)
        {
            PSRepositoryInfo.APIVersion repoApiVersion = repository.ApiVersion;
            ResponseUtil currentResponseUtil = null;

            switch (repoApiVersion)
            {
                case PSRepositoryInfo.APIVersion.v2:
                    currentResponseUtil = new V2ResponseUtil(repository);
                    break;

                case PSRepositoryInfo.APIVersion.v3:
                    currentResponseUtil = new V3ResponseUtil(repository);
                    break;

                case PSRepositoryInfo.APIVersion.local:
                    currentResponseUtil = new LocalResponseUtil(repository);
                    break;

                case PSRepositoryInfo.APIVersion.nugetServer:
                    currentResponseUtil = new NuGetServerResponseUtil(repository);
                    break;

                case PSRepositoryInfo.APIVersion.acr:
                    currentResponseUtil = new ACRResponseUtil(repository);
                    break;

                case PSRepositoryInfo.APIVersion.unknown:
                    break;
            }

            return currentResponseUtil;
        }
    }
}

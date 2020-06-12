﻿
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information

using System;

using DotNetNuke.Authentication.Google.Components;
using DotNetNuke.Services.Authentication;
using DotNetNuke.Services.Authentication.OAuth;
using DotNetNuke.Services.Exceptions;

namespace DotNetNuke.Authentication.Google
{
    public partial class Settings : OAuthSettingsBase
    {
        protected override string AuthSystemApplicationName
        {
            get { return "Google"; }
        }
    }
}

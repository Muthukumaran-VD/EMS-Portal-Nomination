// <copyright file="PageBase.cs" company="VueData">
// Copyright (c) VueData. All rights reserved.
// </copyright>

using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.JSInterop;

namespace EMSPortal.Shared
{
    public class PageBase : ComponentBase
    {
        protected bool ShowLoader { get; set; } = false;

    }
}